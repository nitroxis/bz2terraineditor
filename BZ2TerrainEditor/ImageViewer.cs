using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BZ2TerrainEditor
{
	public partial class ImageViewer : Form
	{
		#region Fields

		private readonly Image image;
		private InterpolationMode filter;

		#endregion

		#region Properties

		#endregion

		#region Constructors

		public ImageViewer(Image image, string title)
		{
			this.InitializeComponent();
			this.image = image;
			this.filter = InterpolationMode.Bilinear;
			this.contextMenuFilterBilinear.Checked = true;

			this.ClientSize = image.Size;
			while (this.ClientSize.Width > 512 || this.ClientSize.Height > 512)
				this.ClientSize = new Size(this.ClientSize.Width / 2, this.ClientSize.Height / 2);

			this.Text = string.Format("{0} ({1}x{2})", title, image.Width, image.Height);
		}


		#endregion

		#region Methods

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if (e.KeyCode == Keys.Escape)
				this.Close();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.Clear(this.BackColor);
			e.Graphics.InterpolationMode = this.filter;

			float factor = Math.Min((float)this.ClientSize.Width / (float)this.image.Width, (float)this.ClientSize.Height / (float)this.image.Height);
			int width = (int)(this.image.Width * factor);
			int height = (int)(this.image.Height * factor);

			e.Graphics.DrawImage(this.image, this.ClientSize.Width / 2 - width / 2, this.ClientSize.Height / 2 - height / 2, width, height);
		}

		private void contextMenuFilterNearest_Click(object sender, EventArgs e)
		{
			this.filter = InterpolationMode.NearestNeighbor;
			this.Invalidate();
			this.contextMenuFilterBilinear.Checked = this.contextMenuFilterBicubic.Checked = false;
			this.contextMenuFilterNearest.Checked = true;
		}

		private void contextMenuFilterBilinear_Click(object sender, EventArgs e)
		{
			this.filter = InterpolationMode.Bilinear;
			this.Invalidate();
			this.contextMenuFilterNearest.Checked = this.contextMenuFilterBilinear.Checked = false;
			this.contextMenuFilterBilinear.Checked = true;
		}

		private void contextMenuFilterBicubic_Click(object sender, EventArgs e)
		{
			this.filter = InterpolationMode.Bicubic;
			this.Invalidate();
			this.contextMenuFilterNearest.Checked = this.contextMenuFilterBilinear.Checked = false;
			this.contextMenuFilterBicubic.Checked = true;
		}

		#endregion


	}
}
