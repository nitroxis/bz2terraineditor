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
			this.tileMap0Preview.Image = this.generateTileMapImage(this.terrain.InfoMap, 0);
			this.tileMap1Preview.Image = this.generateTileMapImage(this.terrain.InfoMap, 1);
			this.tileMap2Preview.Image = this.generateTileMapImage(this.terrain.InfoMap, 2);
			this.tileMap3Preview.Image = this.generateTileMapImage(this.terrain.InfoMap, 3);
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

		private Bitmap generateCellTypeImage(CellType[,] map, CellType typeMask)
		{
			int width = map.GetUpperBound(0) + 1;
			int height = map.GetUpperBound(1) + 1;

			byte[] buffer = new byte[width * height * 3];

			int i = 0;
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					byte color = (map[x, y] & typeMask) != 0 ? (byte)255 : (byte)0;
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

		private Bitmap generateTileMapImage(uint[,] map, int layer)
		{
			int width = map.GetUpperBound(0) + 1;
			int height = map.GetUpperBound(1) + 1;
			int shift = layer * 4;

			byte[] buffer = new byte[width * height * 3];
			
			int i = 0;
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					int v = (byte)((map[x, y] >> shift) & 0xF);
					byte color = (byte)(v | (v << 4));
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

		private static Bitmap resizeBitmap(Bitmap bitmap, int width, int height)
		{
			Bitmap rescaled = new Bitmap(width, height, bitmap.PixelFormat);
			Graphics g = Graphics.FromImage(rescaled);
			g.DrawImage(bitmap, 0, 0, width, height);
			return rescaled;
		}

		private Bitmap loadBitmap()
		{
			return this.loadBitmap(this.terrain.Width, this.terrain.Height);
		}

		private Bitmap loadBitmap(int width, int height)
		{
			try
			{
				OpenFileDialog dialog = new OpenFileDialog();
				dialog.InitialDirectory = Properties.Settings.Default.OpenFileInitialDirectory;
				dialog.Filter = imageFileFilter;
				if (dialog.ShowDialog() != DialogResult.OK)
					return null;

				Bitmap bitmap = new Bitmap(dialog.FileName);
				if (bitmap.Width == width && bitmap.Height == height)
					return bitmap;

				if (MessageBox.Show("The selected bitmap has a different size than the terrain and has to be rescaled.", "Import", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
					return null;

				return resizeBitmap(bitmap, width, height);
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Failed to load bitmap: {0}.", ex.Message));
				return null;
			}
		}

		private void saveImage(Image image)
		{
			try
			{
				SaveFileDialog dialog = new SaveFileDialog();
				dialog.Filter = imageFileFilter;
				dialog.InitialDirectory = Properties.Settings.Default.SaveFileInitialDirectory;
				if (dialog.ShowDialog() != DialogResult.OK)
					return;

				image.Save(dialog.FileName);
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Failed to save image: {0}.", ex.Message));
			}
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

		#region Menu

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
						this.currentFile = new FileInfo(dialog.FileName);
						Properties.Settings.Default.OpenFileInitialDirectory = this.currentFile.DirectoryName;

						this.initialize();
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

			this.updateTitle();
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

		#endregion

		#region Height Map

		private void heightMapPreview_Click(object sender, EventArgs e)
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

			Bitmap bitmap = this.loadBitmap();
			if (bitmap == null)
				return;

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

			this.saveImage(this.heightMapPreview.Image);
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

		private void colorMapPreview_Click(object sender, EventArgs e)
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

			Bitmap bitmap = this.loadBitmap();
			if (bitmap == null)
				return;

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

			this.saveImage(this.colorMapPreview.Image);
		}

		#endregion

		#region Normal Map

		private void normalMapPreview_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			ImageViewer viewer = new ImageViewer(this.normalMapPreview.Image, "Normal Map");
			this.forms.Add(viewer);
			viewer.Show();
		}

		private void normalMapImport_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			Bitmap bitmap = this.loadBitmap();
			if (bitmap == null)
				return;

			BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
			byte[] buffer = new byte[data.Height * data.Stride];
			Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

			for (int y = 0; y < data.Height; y++)
				for (int x = 0; x < data.Width; x++)
					terrain.NormalMap[x, y] = buffer[y * data.Stride + x * 3];

			this.changed = true;
			this.initialize();
		}
		
		private void normalMapExport_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			this.saveImage(this.normalMapPreview.Image);
		}

		#endregion

		#region Cell Type Map

		private void cellMapPreview_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			ImageViewer viewer = new ImageViewer(this.cellMapPreview.Image, "Cell Type Map");
			this.forms.Add(viewer);
			viewer.Show();
		}

		private void cellMapImportCliff_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			Bitmap bitmap = this.loadBitmap();
			if (bitmap == null)
				return;

			BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
			byte[] buffer = new byte[data.Height * data.Stride];
			Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

			for (int y = 0; y < data.Height; y++)
				for (int x = 0; x < data.Width; x++)
					terrain.CellMap[x, y] = (terrain.CellMap[x, y] & ~CellType.Cliff) | (buffer[y * data.Stride + x * 3] > 127 ? CellType.Cliff : 0);

			this.changed = true;
			this.initialize();
		}

		private void cellMapExportCliff_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			this.saveImage(generateCellTypeImage(this.terrain.CellMap, CellType.Cliff));
		}

		private void cellMapImportWater_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			Bitmap bitmap = this.loadBitmap();
			if (bitmap == null)
				return;

			BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
			byte[] buffer = new byte[data.Height * data.Stride];
			Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

			for (int y = 0; y < data.Height; y++)
				for (int x = 0; x < data.Width; x++)
					terrain.CellMap[x, y] = (terrain.CellMap[x, y] & ~CellType.Water) | (buffer[y * data.Stride + x * 3] > 127 ? CellType.Water : 0);

			this.changed = true;
			this.initialize();
		}

		private void cellMapExportWater_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			this.saveImage(generateCellTypeImage(this.terrain.CellMap, CellType.Water));
		}

		private void cellMapImportBuilding_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			Bitmap bitmap = this.loadBitmap();
			if (bitmap == null)
				return;

			BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
			byte[] buffer = new byte[data.Height * data.Stride];
			Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

			for (int y = 0; y < data.Height; y++)
				for (int x = 0; x < data.Width; x++)
					terrain.CellMap[x, y] = (terrain.CellMap[x, y] & ~CellType.Building) | (buffer[y * data.Stride + x * 3] > 127 ? CellType.Building : 0);

			this.changed = true;
			this.initialize();
		}

		private void cellMapExportBuilding_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			this.saveImage(generateCellTypeImage(this.terrain.CellMap, CellType.Building));
		}

		private void cellMapImportLava_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			Bitmap bitmap = this.loadBitmap();
			if (bitmap == null)
				return;

			BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
			byte[] buffer = new byte[data.Height * data.Stride];
			Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

			for (int y = 0; y < data.Height; y++)
				for (int x = 0; x < data.Width; x++)
					terrain.CellMap[x, y] = (terrain.CellMap[x, y] & ~CellType.Lava) | (buffer[y * data.Stride + x * 3] > 127 ? CellType.Lava : 0);

			this.changed = true;
			this.initialize();
		}

		private void cellMapExportLava_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			this.saveImage(generateCellTypeImage(this.terrain.CellMap, CellType.Lava));
		}

		private void cellMapImportSloped_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			Bitmap bitmap = this.loadBitmap();
			if (bitmap == null)
				return;

			BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
			byte[] buffer = new byte[data.Height * data.Stride];
			Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

			for (int y = 0; y < data.Height; y++)
				for (int x = 0; x < data.Width; x++)
					terrain.CellMap[x, y] = (terrain.CellMap[x, y] & ~CellType.Sloped) | (buffer[y * data.Stride + x * 3] > 127 ? CellType.Sloped : 0);

			this.changed = true;
			this.initialize();
		}

		private void cellMapExportSloped_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			this.saveImage(generateCellTypeImage(this.terrain.CellMap, CellType.Sloped));
		}
		
		#endregion

		#region Alpha Map 1

		private void alphaMap1Preview_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			ImageViewer viewer = new ImageViewer(this.alphaMap1Preview.Image, "Alpha Map (Layer 1)");
			this.forms.Add(viewer);
			viewer.Show();
		}

		private void alphaMap1Import_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			Bitmap bitmap = this.loadBitmap();
			if (bitmap == null)
				return;

			BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
			byte[] buffer = new byte[data.Height * data.Stride];
			Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

			for (int y = 0; y < data.Height; y++)
				for (int x = 0; x < data.Width; x++)
					terrain.AlphaMap1[x, y] = buffer[y * data.Stride + x * 3];

			this.changed = true;
			this.initialize();
		}

		private void alphaMap1Export_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			this.saveImage(this.alphaMap1Preview.Image);
		}

		#endregion

		#region Alpha Map 2

		private void alphaMap2Preview_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			ImageViewer viewer = new ImageViewer(this.alphaMap2Preview.Image, "Alpha Map (Layer 2)");
			this.forms.Add(viewer);
			viewer.Show();
		}

		private void alphaMap2Import_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			Bitmap bitmap = this.loadBitmap();
			if (bitmap == null)
				return;

			BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
			byte[] buffer = new byte[data.Height * data.Stride];
			Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

			for (int y = 0; y < data.Height; y++)
				for (int x = 0; x < data.Width; x++)
					terrain.AlphaMap2[x, y] = buffer[y * data.Stride + x * 3];

			this.changed = true;
			this.initialize();
		}
		
		private void alphaMap2Export_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			this.saveImage(this.alphaMap2Preview.Image);
		}

		#endregion
		
		#region Alpha Map 3

		private void alphaMap3Preview_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			ImageViewer viewer = new ImageViewer(this.alphaMap3Preview.Image, "Alpha Map (Layer 3)");
			this.forms.Add(viewer);
			viewer.Show();
		}

		private void alphaMap3Import_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			Bitmap bitmap = this.loadBitmap();
			if (bitmap == null)
				return;

			BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
			byte[] buffer = new byte[data.Height * data.Stride];
			Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

			for (int y = 0; y < data.Height; y++)
				for (int x = 0; x < data.Width; x++)
					terrain.AlphaMap3[x, y] = buffer[y * data.Stride + x * 3];

			this.changed = true;
			this.initialize();
		}

		private void alphaMap3Export_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			this.saveImage(this.alphaMap3Preview.Image);
		}

		#endregion

		#region Tile Map

		private void importTileMap(int layer)
		{
			if (this.terrain == null)
				return;

			Bitmap bitmap = this.loadBitmap(this.terrain.InfoMap.GetUpperBound(0) + 1, this.terrain.InfoMap.GetUpperBound(1) + 1);
			if (bitmap == null)
				return;

			BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
			byte[] buffer = new byte[data.Height * data.Stride];
			Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

			int shift = layer * 4;
			uint mask = ~(0xFu << shift);

			for (int y = 0; y < data.Height; y++)
				for (int x = 0; x < data.Width; x++)
					terrain.InfoMap[x, y] = (terrain.InfoMap[x, y] & mask) | (uint)(buffer[y * data.Stride + x * 3] >> 4) << shift;

			this.changed = true;
			this.initialize();
		}

		private void tileMap0Preview_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			ImageViewer viewer = new ImageViewer(this.tileMap0Preview.Image, "Tile Map (Layer 0)");
			this.forms.Add(viewer);
			viewer.Show();
		}

		private void tileMap0Import_Click(object sender, EventArgs e)
		{
			this.importTileMap(0);
		}

		private void tileMap0Export_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			this.saveImage(this.tileMap0Preview.Image);
		}


		private void tileMap1Preview_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			ImageViewer viewer = new ImageViewer(this.tileMap1Preview.Image, "Tile Map (Layer 1)");
			this.forms.Add(viewer);
			viewer.Show();
		}

		private void tileMap1Import_Click(object sender, EventArgs e)
		{
			this.importTileMap(1);
		}

		private void tileMap1Export_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			this.saveImage(this.tileMap1Preview.Image);
		}

		
		private void tileMap2Preview_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			ImageViewer viewer = new ImageViewer(this.tileMap2Preview.Image, "Tile Map (Layer 2)");
			this.forms.Add(viewer);
			viewer.Show();
		}

		private void tileMap2Import_Click(object sender, EventArgs e)
		{
			this.importTileMap(2);
		}

		private void tileMap2Export_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			this.saveImage(this.tileMap2Preview.Image);
		}

		
		private void tileMap3Preview_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			ImageViewer viewer = new ImageViewer(this.tileMap3Preview.Image, "Tile Map (Layer 3)");
			this.forms.Add(viewer);
			viewer.Show();
		}

		private void tileMap3Import_Click(object sender, EventArgs e)
		{
			this.importTileMap(3);
		}

		private void tileMap3Export_Click(object sender, EventArgs e)
		{
			if (this.terrain == null)
				return;

			this.saveImage(this.tileMap3Preview.Image);
		}
		
		#endregion

		#endregion
		
		#endregion
	}
}
