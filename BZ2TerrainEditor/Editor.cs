using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BZ2TerrainEditor
{
	public partial class Editor : Form
	{
		#region Constants

		private const string terrainFileFilter = "BZ2 terrain files (*.ter)|*.ter|All files (*.*)|*";
		private const string imageFileFilter = "Portable Network Graphics (*.png)|*.png|Bitmap (*.bmp)|*.bmp|All Files (*.*|*";

		#endregion

		#region Fields

		private Terrain terrain;
		private FileInfo currentFile;
		private bool changed;

		private readonly List<GCHandle> imageHandles;
		private readonly List<Form> forms;

		#endregion

		#region Properties

		#endregion

		#region Constructors

		public Editor()
		{
			this.InitializeComponent();
			Program.EditorInstances++;

			this.imageHandles = new List<GCHandle>();
			this.forms = new List<Form>();
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

			try
			{
				this.terrain = Terrain.Read(fileName);
			}
			catch (Exception bug)
			{
				MessageBox.Show(bug.ToString(), "Failed to load terrain.");
			}

			if (this.terrain != null)
			{
				this.initialize();
				Properties.Settings.Default.OpenFileInitialDirectory = this.currentFile.DirectoryName;
			}
			else
			{
				this.currentFile = null;
			}
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

			this.updateTitle();
			
			if (this.terrain == null)
				return;

			this.heightMapPreview.Image = this.generate16BitImage(this.terrain.HeightMap, this.terrain.HeightMapMin, this.terrain.HeightMapMax);
			this.colorMapPreview.Image = this.generateColorMapImage(this.terrain.ColorMap);
			this.normalMapPreview.Image = this.generate8BitImage(this.terrain.NormalMap);
			this.cellMapPreview.Image = this.generateCellTypeImage(this.terrain.CellMap);
			this.alphaMap1Preview.Image = this.generate8BitImage(this.terrain.AlphaMap1);
			this.alphaMap2Preview.Image = this.generate8BitImage(this.terrain.AlphaMap2);
			this.alphaMap3Preview.Image = this.generate8BitImage(this.terrain.AlphaMap3);
			this.flowLayout.Enabled = true;
		}

		/// <summary>
		/// Updates the editor title.
		/// </summary>
		private void updateTitle()
		{
			if (this.currentFile == null)
			{
				if (this.changed)
					this.Text = "Unnamed * - BattleZone II Terrain Editor";
				else
					this.Text = "Unnamed - BattleZone II Terrain Editor";
			}
			else
			{
				if (this.changed)
					this.Text = string.Format("{0} * - BattleZone II Terrain Editor", this.currentFile.Name);
				else
					this.Text = string.Format("{0} - BattleZone II Terrain Editor", this.currentFile.Name);
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

		private Bitmap generate1BitImage(byte[,] map)
		{
			int width = map.GetUpperBound(0) + 1;
			int height = map.GetUpperBound(1) + 1;

			byte[] buffer = new byte[width * height * 3];

			int i = 0;
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					buffer[i++] = (byte)(map[x, y] == 0 ? 0 : 255);
					buffer[i++] = (byte)(map[x, y] == 0 ? 0 : 255);
					buffer[i++] = (byte)(map[x, y] == 0 ? 0 : 255);
				}
			}

			GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
			Bitmap bmp = new Bitmap(width, height, width * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, handle.AddrOfPinnedObject());
			this.imageHandles.Add(handle);
			return bmp;
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
			Bitmap bmp = new Bitmap(width, height, width * 3, PixelFormat.Format24bppRgb, handle.AddrOfPinnedObject());
			this.imageHandles.Add(handle);
			return bmp;
		}

		private Bitmap generateCellTypeImage(CellType[,] map)
		{
			int width = map.GetUpperBound(0) + 1;
			int height = map.GetUpperBound(1) + 1;

			byte[] buffer = new byte[width * height * 3];

			int i = 0;
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					CellType type = map[x, y];
					if (type.HasFlag(CellType.Sloped)) buffer[i] = buffer[i + 1] = buffer[i + 2] = 63;
					if (type.HasFlag(CellType.Cliff)) buffer[i] = buffer[i + 1] = buffer[i + 2] = 127;
					if (type.HasFlag(CellType.Water)) buffer[i] = 255;
					if (type.HasFlag(CellType.Building)) buffer[i + 1] = 255;
					if (type.HasFlag(CellType.Lava)) buffer[i + 2] = 255;
					i += 3;
				}
			}

			GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
			Bitmap bmp = new Bitmap(width, height, width * 3, PixelFormat.Format24bppRgb, handle.AddrOfPinnedObject());
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
					byte color = (byte)((float)(map[x, y] - min) / (float)(max - min) * 255.0f);
					buffer[i++] = color;
					buffer[i++] = color;
					buffer[i++] = color;
				}	
			}

			GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
			Bitmap bmp = new Bitmap(width, height, width * 3, PixelFormat.Format24bppRgb, handle.AddrOfPinnedObject());
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
					dialog.Filter = terrainFileFilter;
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

			foreach (Form form in this.forms)
				form.Close();

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
			dialog.Filter = terrainFileFilter;
			dialog.InitialDirectory = Properties.Settings.Default.OpenFileInitialDirectory;
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				if (this.terrain == null)
				{
					try
					{
						this.terrain = Terrain.Read(dialog.FileName);
					}
					catch (Exception bug)
					{
						MessageBox.Show(bug.ToString(), "Failed to load terrain.");
					}

					if (this.terrain != null)
					{
						this.initialize();
						this.currentFile = new FileInfo(dialog.FileName);
						Properties.Settings.Default.OpenFileInitialDirectory = this.currentFile.DirectoryName;
					}
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
			dialog.Filter = terrainFileFilter;
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

		private void menuHelpForums_Click(object sender, EventArgs e)
		{
			Process.Start("http://bzforum.matesfamily.org/");
		}

		private void menuHelpAbout_Click(object sender, EventArgs e)
		{
			AboutDialog dialog = new AboutDialog();
			dialog.ShowDialog();
		}

		#region Height Map

		private void heightMapShow_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			ImageViewer viewer = new ImageViewer(this.heightMapPreview.Image, "Height Map");
			this.forms.Add(viewer);
			viewer.Show();
		}

		private void heightMapImport_Click(object sender, EventArgs e)
		{
			if(this.terrain == null)
				return;

			OpenFileDialog dialog = new OpenFileDialog();
			dialog.InitialDirectory = Properties.Settings.Default.OpenFileInitialDirectory;
			dialog.Filter = imageFileFilter;
			if (dialog.ShowDialog() != DialogResult.OK)
				return;

			Bitmap bitmap = new Bitmap(dialog.FileName);

			if (bitmap.Width != this.terrain.Width || bitmap.Height != this.terrain.Height)
			{
				if (MessageBox.Show("The selected bitmap has a different size than the terrain and has to be rescaled.", "Import", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
					return;

				Bitmap rescaled = new Bitmap(this.terrain.Width, this.terrain.Height, bitmap.PixelFormat);
				Graphics g = Graphics.FromImage(rescaled);
				g.DrawImage(bitmap, 0, 0, this.terrain.Width, this.terrain.Height);

				bitmap = rescaled;
			}

			HeightMapRangeDialog rangeDialog = new HeightMapRangeDialog();
			if (rangeDialog.ShowDialog() != DialogResult.OK)
				return;

			BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
			byte[] buffer = new byte[data.Height * data.Stride];
			Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

			for (int y = 0; y < data.Height; y++)
				for (int x = 0; x < data.Width; x++)
					terrain.HeightMap[x, y] = (short)((float)buffer[y * data.Stride + x * 3] * (float)(rangeDialog.Maximum - rangeDialog.Minimum) / 255.0f + (float)rangeDialog.Minimum);

			this.changed = true;
			this.terrain.UpdateMinMax();
			this.initialize();
		}

		private void heightMapExport_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Filter = imageFileFilter;
			dialog.InitialDirectory = Properties.Settings.Default.SaveFileInitialDirectory;
			if (dialog.ShowDialog() != DialogResult.OK)
				return;

			this.heightMapPreview.Image.Save(dialog.FileName);
		}

		private void heightMapImport16Bit_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			OpenFileDialog dialog = new OpenFileDialog();
			dialog.InitialDirectory = Properties.Settings.Default.OpenFileInitialDirectory;
			if (dialog.ShowDialog() != DialogResult.OK)
				return;

			FileInfo input = new FileInfo(dialog.FileName);
			if (input.Length < this.terrain.Width * this.terrain.Height * 2)
			{
				MessageBox.Show("The selected file is too small.", "Import");
				return;
			}

			using (Stream stream = input.OpenRead())
			{
				byte[] row = new byte[terrain.Width * 2];

				for (int y = 0; y < this.terrain.Height; y++)
				{
					if (stream.Read(row, 0, row.Length) < row.Length)
						throw new Exception("Unexpected end of stream.");

					for (int x = 0; x < this.terrain.Width; x++)
						this.terrain.HeightMap[x, y] = (short)(row[x * 2] | row[x * 2 + 1] << 8);
				}
			}

			this.changed = true;
			this.terrain.UpdateMinMax();
			this.initialize();
		}

		private void HeightMapExport16Bit_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			SaveFileDialog dialog = new SaveFileDialog();
			dialog.InitialDirectory = Properties.Settings.Default.SaveFileInitialDirectory;
			if (dialog.ShowDialog() != DialogResult.OK)
				return;

			FileInfo output = new FileInfo(dialog.FileName);
			using (Stream stream = output.Create())
			{
				byte[] row = new byte[terrain.Width * 2];
				
				for (int y = 0; y < this.terrain.Height; y++)
				{
					for (int x = 0; x < this.terrain.Width; x++)
					{
						row[x * 2 + 0] = unchecked((byte)(this.terrain.HeightMap[x, y] & 0xFF));
						row[x * 2 + 1] = unchecked((byte)(this.terrain.HeightMap[x, y] >> 8));
					}

					stream.Write(row, 0, row.Length);
				}
			}
		}

		#endregion

		#region Color Map

		private void colorMapShow_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			ImageViewer viewer = new ImageViewer(this.colorMapPreview.Image, "Color Map");
			this.forms.Add(viewer);
			viewer.Show();
		}

		private void colorMapImport_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			OpenFileDialog dialog = new OpenFileDialog();
			dialog.InitialDirectory = Properties.Settings.Default.OpenFileInitialDirectory;
			dialog.Filter = imageFileFilter;
			if (dialog.ShowDialog() != DialogResult.OK)
				return;

			Bitmap bitmap = new Bitmap(dialog.FileName);

			if (bitmap.Width != this.terrain.Width || bitmap.Height != this.terrain.Height)
			{
				if (MessageBox.Show("The selected bitmap has a different size than the terrain and has to be rescaled.", "Import", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
					return;

				Bitmap rescaled = new Bitmap(this.terrain.Width, this.terrain.Height, bitmap.PixelFormat);
				Graphics g = Graphics.FromImage(rescaled);
				g.DrawImage(bitmap, 0, 0, this.terrain.Width, this.terrain.Height);

				bitmap = rescaled;
			}

			BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
			byte[] buffer = new byte[data.Height * data.Stride];
			Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

			int i = 0;
			for (int y = 0; y < data.Height; y++)
			{
				for (int x = 0; x < data.Width; x++)
				{
					terrain.ColorMap[x, y].B = buffer[i++];
					terrain.ColorMap[x, y].G = buffer[i++];
					terrain.ColorMap[x, y].R = buffer[i++];
				}	
			}
			
			this.changed = true;
			this.initialize();
		}

		private void colorMapExport_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Filter = imageFileFilter;
			dialog.InitialDirectory = Properties.Settings.Default.SaveFileInitialDirectory;
			if (dialog.ShowDialog() != DialogResult.OK)
				return;

			this.colorMapPreview.Image.Save(dialog.FileName);
		}

		#endregion

		private void normalMapShow_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			ImageViewer viewer = new ImageViewer(this.normalMapPreview.Image, "Normal Map");
			this.forms.Add(viewer);
			viewer.Show();
		}

		private void cellMapShow_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			ImageViewer viewer = new ImageViewer(this.cellMapPreview.Image, "Cell Type Map");
			this.forms.Add(viewer);
			viewer.Show();
		}

		private void alphaMap1Show_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			ImageViewer viewer = new ImageViewer(this.alphaMap1Preview.Image, "Alpha Map (Layer 1)");
			this.forms.Add(viewer);
			viewer.Show();
		}

		private void alphaMap2Show_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			ImageViewer viewer = new ImageViewer(this.alphaMap2Preview.Image, "Alpha Map (Layer 2)");
			this.forms.Add(viewer);
			viewer.Show();
		}

		private void alphaMap3Show_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			ImageViewer viewer = new ImageViewer(this.alphaMap3Preview.Image, "Alpha Map (Layer 3)");
			this.forms.Add(viewer);
			viewer.Show();
		}

		#endregion

		#endregion


		
	}
}
