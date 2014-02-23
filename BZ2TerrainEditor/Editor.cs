using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BZ2TerrainEditor
{
	public partial class Editor : Form
	{
		#region Fields

		private Terrain terrain;
		private FileInfo currentFile;
		private bool changed;

		private List<GCHandle> imageHandles;
		
		#endregion

		#region Properties

		#endregion

		#region Constructors

		public Editor()
		{
			this.InitializeComponent();
			Program.EditorInstances++;

			this.imageHandles = new List<GCHandle>();
			this.updateTitle();
		}

		public Editor(string fileName)
			: this()
		{
			this.currentFile = new FileInfo(fileName);
			if (!this.currentFile.Exists)
			{
				MessageBox.Show(string.Format("Couldn't find file \"{0}\".", fileName));
				return;
			}

			this.terrain = Terrain.Read(fileName);
			this.initialize();

			Properties.Settings.Default.OpenFileInitialDirectory = this.currentFile.DirectoryName;
		}

		public Editor(Terrain terrain)
			: this()
		{
			this.terrain = terrain;
			this.initialize();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Initializes the editor view.
		/// </summary>
		private void initialize()
		{
			this.free();

			this.heightMapPreview.Image = this.generate16BitImage(this.terrain.HeightMap, this.terrain.HeightMapLowest, this.terrain.HeightMapHeighest);
			this.colorMapPreview.Image = this.generateColorMapImage(this.terrain.ColorMap);
			this.normalMapPreview.Image = this.generate8BitImage(this.terrain.NormalMap);
			this.cliffMapPreview.Image = this.generate8BitImage(this.terrain.CliffMap);
			this.alphaMap1Preview.Image = this.generate8BitImage(this.terrain.AlphaMap1);
			this.alphaMap2Preview.Image = this.generate8BitImage(this.terrain.AlphaMap2);
			this.alphaMap3Preview.Image = this.generate8BitImage(this.terrain.AlphaMap3);

			this.updateTitle();
		}

		/// <summary>
		/// Updates the editor title.
		/// </summary>
		private void updateTitle()
		{
			if (this.currentFile == null)
			{
				if (this.changed)
					this.Text = "BattleZone II Terrain Editor - Unnamed *";
				else
					this.Text = "BattleZone II Terrain Editor - Unnamed";
			}
			else
			{
				if (this.changed)
					this.Text = string.Format("BattleZone II Terrain Editor - {0} *", this.currentFile.Name);
				else
					this.Text = string.Format("BattleZone II Terrain Editor - {0}", this.currentFile.Name);
			}
		}

		/// <summary>
		/// Frees all resources used by the editor.
		/// </summary>
		private void free()
		{
			foreach (GCHandle handle in this.imageHandles)
				handle.Free();
			this.imageHandles.Clear();
		}

		private Bitmap generate8BitImage(byte[,] map)
		{
			int width = map.GetUpperBound(0) + 1;
			int height = map.GetUpperBound(1) + 1;

			byte[] buffer = new byte[width * height * 3];

			int i = 0;
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					buffer[i++] = map[x, y];
					buffer[i++] = map[x, y];
					buffer[i++] = map[x, y];
				}
			}

			GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
			Bitmap bmp = new Bitmap(width, height, width * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, handle.AddrOfPinnedObject());
			this.imageHandles.Add(handle);
			return bmp;
		}

		private Bitmap generate16BitImage(short[,] map, short min, short max)
		{
			int width = map.GetUpperBound(0) + 1;
			int height = map.GetUpperBound(1) + 1;
			
			byte[] buffer = new byte[width * height * 3];

			int i = 0;
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					byte color = (byte)((float)(map[x, y] - min) / (float)max * 255.0f);
					buffer[i++] = color;
					buffer[i++] = color;
					buffer[i++] = color;
				}	
			}

			GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
			Bitmap bmp = new Bitmap(width, height, width * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, handle.AddrOfPinnedObject());
			this.imageHandles.Add(handle); 
			return bmp;
		}

		private Bitmap generateColorMapImage(RGB[,] map)
		{
			int width = map.GetUpperBound(0) + 1;
			int height = map.GetUpperBound(1) + 1;
			
			byte[] buffer = new byte[width * height * 3];

			int i = 0;
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					buffer[i++] = this.terrain.ColorMap[x, y].B;
					buffer[i++] = this.terrain.ColorMap[x, y].G;
					buffer[i++] = this.terrain.ColorMap[x, y].R;
				}
			}

			GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
			Bitmap bmp = new Bitmap(width, height, width * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, handle.AddrOfPinnedObject());
			this.imageHandles.Add(handle); 
			return bmp;
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);

			if (this.terrain != null && this.changed)
			{
				DialogResult result = MessageBox.Show("You have unsaved changes. Do you want to save them?", "Exit", MessageBoxButtons.YesNoCancel);
				if (result == DialogResult.Yes)
				{
					SaveFileDialog dialog = new SaveFileDialog();
					dialog.Filter = "BZ2 terrain files (*.ter)|*.ter|All files (*.*)|*";
					if (dialog.ShowDialog() == DialogResult.OK)
					{
						this.terrain.Write(dialog.FileName);
					}
				}
				else if (result == DialogResult.Cancel)
				{
					e.Cancel = true;
				}
			}
		}

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			this.free();

			base.OnFormClosed(e);
			Program.EditorInstances--;
		}

		#region Event Handlers

		private void newTerrain(object sender, EventArgs e)
		{
			SizeDialog dialog = new SizeDialog();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				Editor editor = new Editor(new Terrain(dialog.SelectedSize, dialog.SelectedSize));
				this.Close();
				editor.Show();
			}
		}

		private void openTerrain(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "BZ2 terrain files (*.ter)|*.ter|All files (*.*)|*";
			dialog.InitialDirectory = Properties.Settings.Default.OpenFileInitialDirectory;
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				if (this.terrain == null)
				{
					this.currentFile = new FileInfo(dialog.FileName);
					Properties.Settings.Default.OpenFileInitialDirectory = this.currentFile.DirectoryName;
					this.terrain = Terrain.Read(dialog.FileName);
					this.initialize();
				}
				else
				{
					Editor editor = new Editor(dialog.FileName);
					editor.Show();
				}
			}
		}

		private void saveTerrain(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			if (this.currentFile == null)
			{
				this.saveAsTerrain(sender, e);
				return;
			}

			terrain.Write(this.currentFile.FullName);
			this.changed = false;
		}

		private void saveAsTerrain(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Filter = "BZ2 terrain files (*.ter)|*.ter|All files (*.*)|*";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				this.currentFile = new FileInfo(dialog.FileName);
				this.terrain.Write(this.currentFile.FullName);
				this.changed = false;
			}
		}
		
		private void menuFileExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		#endregion

		#endregion

	}
}
