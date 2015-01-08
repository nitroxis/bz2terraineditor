namespace BZ2TerrainEditor
{
	partial class ImageViewer
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.contextMenuFilter = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuFilterNearest = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuFilterBilinear = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuFilterBicubic = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.contextMenuClose = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuFilter,
            this.contextMenuSeparator1,
            this.contextMenuClose});
			this.contextMenu.Name = "contextMenu";
			this.contextMenu.Size = new System.Drawing.Size(104, 54);
			// 
			// contextMenuFilter
			// 
			this.contextMenuFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuFilterNearest,
            this.contextMenuFilterBilinear,
            this.contextMenuFilterBicubic});
			this.contextMenuFilter.Name = "contextMenuFilter";
			this.contextMenuFilter.Size = new System.Drawing.Size(103, 22);
			this.contextMenuFilter.Text = "&Filter";
			// 
			// contextMenuFilterNearest
			// 
			this.contextMenuFilterNearest.Name = "contextMenuFilterNearest";
			this.contextMenuFilterNearest.Size = new System.Drawing.Size(114, 22);
			this.contextMenuFilterNearest.Text = "&Nearest";
			this.contextMenuFilterNearest.Click += new System.EventHandler(this.contextMenuFilterNearest_Click);
			// 
			// contextMenuFilterBilinear
			// 
			this.contextMenuFilterBilinear.Name = "contextMenuFilterBilinear";
			this.contextMenuFilterBilinear.Size = new System.Drawing.Size(114, 22);
			this.contextMenuFilterBilinear.Text = "&Bilinear";
			this.contextMenuFilterBilinear.Click += new System.EventHandler(this.contextMenuFilterBilinear_Click);
			// 
			// contextMenuFilterBicubic
			// 
			this.contextMenuFilterBicubic.Name = "contextMenuFilterBicubic";
			this.contextMenuFilterBicubic.Size = new System.Drawing.Size(114, 22);
			this.contextMenuFilterBicubic.Text = "&Bicubic";
			this.contextMenuFilterBicubic.Click += new System.EventHandler(this.contextMenuFilterBicubic_Click);
			// 
			// contextMenuSeparator1
			// 
			this.contextMenuSeparator1.Name = "contextMenuSeparator1";
			this.contextMenuSeparator1.Size = new System.Drawing.Size(100, 6);
			// 
			// contextMenuClose
			// 
			this.contextMenuClose.Image = global::BZ2TerrainEditor.Properties.Resources.cross1;
			this.contextMenuClose.Name = "contextMenuClose";
			this.contextMenuClose.Size = new System.Drawing.Size(103, 22);
			this.contextMenuClose.Text = "&Close";
			// 
			// ImageViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.ContextMenuStrip = this.contextMenu;
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "ImageViewer";
			this.Text = "ImageViewer";
			this.contextMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem contextMenuFilter;
		private System.Windows.Forms.ToolStripMenuItem contextMenuFilterNearest;
		private System.Windows.Forms.ToolStripMenuItem contextMenuFilterBilinear;
		private System.Windows.Forms.ToolStripSeparator contextMenuSeparator1;
		private System.Windows.Forms.ToolStripMenuItem contextMenuClose;
		private System.Windows.Forms.ToolStripMenuItem contextMenuFilterBicubic;
	}
}