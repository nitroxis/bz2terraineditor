namespace BZ2TerrainEditor
{
	partial class Editor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
			this.menu = new System.Windows.Forms.MenuStrip();
			this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
			this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
			this.menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.menuFileSeperator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.tools = new System.Windows.Forms.ToolStrip();
			this.toolsNew = new System.Windows.Forms.ToolStripButton();
			this.toolsOpen = new System.Windows.Forms.ToolStripButton();
			this.toolsSave = new System.Windows.Forms.ToolStripButton();
			this.toolsSaveAs = new System.Windows.Forms.ToolStripButton();
			this.heightMapGroup = new System.Windows.Forms.GroupBox();
			this.heightMapToolbar = new System.Windows.Forms.ToolStrip();
			this.heightMapShow = new System.Windows.Forms.ToolStripButton();
			this.heightMapImport = new System.Windows.Forms.ToolStripButton();
			this.heightMapExport = new System.Windows.Forms.ToolStripButton();
			this.heightMapPreview = new System.Windows.Forms.PictureBox();
			this.colorMapGroup = new System.Windows.Forms.GroupBox();
			this.colorMapToolbar = new System.Windows.Forms.ToolStrip();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.colorMapPreview = new System.Windows.Forms.PictureBox();
			this.normalMapGroup = new System.Windows.Forms.GroupBox();
			this.normalMapToolbar = new System.Windows.Forms.ToolStrip();
			this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.normalMapPreview = new System.Windows.Forms.PictureBox();
			this.cliffMapGroup = new System.Windows.Forms.GroupBox();
			this.cliffMapToolbar = new System.Windows.Forms.ToolStrip();
			this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
			this.cliffMapPreview = new System.Windows.Forms.PictureBox();
			this.alphaMap1Group = new System.Windows.Forms.GroupBox();
			this.alphaMap1Toolbar = new System.Windows.Forms.ToolStrip();
			this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
			this.alphaMap1Preview = new System.Windows.Forms.PictureBox();
			this.alphaMap2Group = new System.Windows.Forms.GroupBox();
			this.alphaMap2Toolbar = new System.Windows.Forms.ToolStrip();
			this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
			this.alphaMap2Preview = new System.Windows.Forms.PictureBox();
			this.alphaMap3Group = new System.Windows.Forms.GroupBox();
			this.alphaMap3Toolbar = new System.Windows.Forms.ToolStrip();
			this.toolStripButton18 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton16 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton17 = new System.Windows.Forms.ToolStripButton();
			this.alphaMap3Preview = new System.Windows.Forms.PictureBox();
			this.menu.SuspendLayout();
			this.tools.SuspendLayout();
			this.heightMapGroup.SuspendLayout();
			this.heightMapToolbar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.heightMapPreview)).BeginInit();
			this.colorMapGroup.SuspendLayout();
			this.colorMapToolbar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.colorMapPreview)).BeginInit();
			this.normalMapGroup.SuspendLayout();
			this.normalMapToolbar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.normalMapPreview)).BeginInit();
			this.cliffMapGroup.SuspendLayout();
			this.cliffMapToolbar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cliffMapPreview)).BeginInit();
			this.alphaMap1Group.SuspendLayout();
			this.alphaMap1Toolbar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.alphaMap1Preview)).BeginInit();
			this.alphaMap2Group.SuspendLayout();
			this.alphaMap2Toolbar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.alphaMap2Preview)).BeginInit();
			this.alphaMap3Group.SuspendLayout();
			this.alphaMap3Toolbar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.alphaMap3Preview)).BeginInit();
			this.SuspendLayout();
			// 
			// menu
			// 
			this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile});
			this.menu.Location = new System.Drawing.Point(0, 0);
			this.menu.Name = "menu";
			this.menu.Size = new System.Drawing.Size(1110, 24);
			this.menu.TabIndex = 0;
			this.menu.Text = "mainMenu";
			// 
			// menuFile
			// 
			this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileNew,
            this.menuFileOpen,
            this.menuFileSave,
            this.menuFileSaveAs,
            this.menuFileSeperator1,
            this.menuFileExit});
			this.menuFile.Name = "menuFile";
			this.menuFile.Size = new System.Drawing.Size(37, 20);
			this.menuFile.Text = "&File";
			// 
			// menuFileNew
			// 
			this.menuFileNew.Image = global::BZ2TerrainEditor.Properties.Resources.map;
			this.menuFileNew.Name = "menuFileNew";
			this.menuFileNew.Size = new System.Drawing.Size(152, 22);
			this.menuFileNew.Text = "&New...";
			this.menuFileNew.Click += new System.EventHandler(this.newTerrain);
			// 
			// menuFileOpen
			// 
			this.menuFileOpen.Image = global::BZ2TerrainEditor.Properties.Resources.folder_open;
			this.menuFileOpen.Name = "menuFileOpen";
			this.menuFileOpen.Size = new System.Drawing.Size(152, 22);
			this.menuFileOpen.Text = "&Open...";
			this.menuFileOpen.Click += new System.EventHandler(this.openTerrain);
			// 
			// menuFileSave
			// 
			this.menuFileSave.Image = global::BZ2TerrainEditor.Properties.Resources.disk_black;
			this.menuFileSave.Name = "menuFileSave";
			this.menuFileSave.Size = new System.Drawing.Size(152, 22);
			this.menuFileSave.Text = "&Save";
			this.menuFileSave.Click += new System.EventHandler(this.saveTerrain);
			// 
			// menuFileSaveAs
			// 
			this.menuFileSaveAs.Image = global::BZ2TerrainEditor.Properties.Resources.disks_black;
			this.menuFileSaveAs.Name = "menuFileSaveAs";
			this.menuFileSaveAs.Size = new System.Drawing.Size(152, 22);
			this.menuFileSaveAs.Text = "&Save As...";
			this.menuFileSaveAs.Click += new System.EventHandler(this.saveAsTerrain);
			// 
			// menuFileSeperator1
			// 
			this.menuFileSeperator1.Name = "menuFileSeperator1";
			this.menuFileSeperator1.Size = new System.Drawing.Size(149, 6);
			// 
			// menuFileExit
			// 
			this.menuFileExit.Image = global::BZ2TerrainEditor.Properties.Resources.cross;
			this.menuFileExit.Name = "menuFileExit";
			this.menuFileExit.Size = new System.Drawing.Size(152, 22);
			this.menuFileExit.Text = "&Exit";
			this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
			// 
			// tools
			// 
			this.tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsNew,
            this.toolsOpen,
            this.toolsSave,
            this.toolsSaveAs});
			this.tools.Location = new System.Drawing.Point(0, 24);
			this.tools.Name = "tools";
			this.tools.Size = new System.Drawing.Size(1110, 25);
			this.tools.TabIndex = 9;
			this.tools.Text = "toolStrip1";
			// 
			// toolsNew
			// 
			this.toolsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolsNew.Image = global::BZ2TerrainEditor.Properties.Resources.map;
			this.toolsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolsNew.Name = "toolsNew";
			this.toolsNew.Size = new System.Drawing.Size(23, 22);
			this.toolsNew.Text = "New...";
			this.toolsNew.Click += new System.EventHandler(this.newTerrain);
			// 
			// toolsOpen
			// 
			this.toolsOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolsOpen.Image = global::BZ2TerrainEditor.Properties.Resources.folder_open;
			this.toolsOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolsOpen.Name = "toolsOpen";
			this.toolsOpen.Size = new System.Drawing.Size(23, 22);
			this.toolsOpen.Text = "Open...";
			this.toolsOpen.Click += new System.EventHandler(this.openTerrain);
			// 
			// toolsSave
			// 
			this.toolsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolsSave.Image = global::BZ2TerrainEditor.Properties.Resources.disk_black;
			this.toolsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolsSave.Name = "toolsSave";
			this.toolsSave.Size = new System.Drawing.Size(23, 22);
			this.toolsSave.Text = "Save";
			this.toolsSave.Click += new System.EventHandler(this.saveTerrain);
			// 
			// toolsSaveAs
			// 
			this.toolsSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolsSaveAs.Image = global::BZ2TerrainEditor.Properties.Resources.disks_black;
			this.toolsSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolsSaveAs.Name = "toolsSaveAs";
			this.toolsSaveAs.Size = new System.Drawing.Size(23, 22);
			this.toolsSaveAs.Text = "Save As...";
			this.toolsSaveAs.Click += new System.EventHandler(this.saveAsTerrain);
			// 
			// heightMapGroup
			// 
			this.heightMapGroup.Controls.Add(this.heightMapToolbar);
			this.heightMapGroup.Controls.Add(this.heightMapPreview);
			this.heightMapGroup.Location = new System.Drawing.Point(12, 52);
			this.heightMapGroup.Name = "heightMapGroup";
			this.heightMapGroup.Size = new System.Drawing.Size(268, 306);
			this.heightMapGroup.TabIndex = 10;
			this.heightMapGroup.TabStop = false;
			this.heightMapGroup.Text = "Height Map";
			// 
			// heightMapToolbar
			// 
			this.heightMapToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.heightMapToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heightMapShow,
            this.heightMapImport,
            this.heightMapExport});
			this.heightMapToolbar.Location = new System.Drawing.Point(3, 16);
			this.heightMapToolbar.Name = "heightMapToolbar";
			this.heightMapToolbar.Size = new System.Drawing.Size(262, 25);
			this.heightMapToolbar.TabIndex = 2;
			this.heightMapToolbar.Text = "toolStrip2";
			// 
			// heightMapShow
			// 
			this.heightMapShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.heightMapShow.Image = ((System.Drawing.Image)(resources.GetObject("heightMapShow.Image")));
			this.heightMapShow.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.heightMapShow.Name = "heightMapShow";
			this.heightMapShow.Size = new System.Drawing.Size(23, 22);
			this.heightMapShow.Text = "Show";
			// 
			// heightMapImport
			// 
			this.heightMapImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.heightMapImport.Image = ((System.Drawing.Image)(resources.GetObject("heightMapImport.Image")));
			this.heightMapImport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.heightMapImport.Name = "heightMapImport";
			this.heightMapImport.Size = new System.Drawing.Size(23, 22);
			this.heightMapImport.Text = "Import";
			// 
			// heightMapExport
			// 
			this.heightMapExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.heightMapExport.Image = ((System.Drawing.Image)(resources.GetObject("heightMapExport.Image")));
			this.heightMapExport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.heightMapExport.Name = "heightMapExport";
			this.heightMapExport.Size = new System.Drawing.Size(23, 22);
			this.heightMapExport.Text = "Export";
			// 
			// heightMapPreview
			// 
			this.heightMapPreview.BackColor = System.Drawing.Color.Black;
			this.heightMapPreview.Location = new System.Drawing.Point(6, 44);
			this.heightMapPreview.Name = "heightMapPreview";
			this.heightMapPreview.Size = new System.Drawing.Size(256, 256);
			this.heightMapPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.heightMapPreview.TabIndex = 1;
			this.heightMapPreview.TabStop = false;
			// 
			// colorMapGroup
			// 
			this.colorMapGroup.Controls.Add(this.colorMapToolbar);
			this.colorMapGroup.Controls.Add(this.colorMapPreview);
			this.colorMapGroup.Location = new System.Drawing.Point(286, 52);
			this.colorMapGroup.Name = "colorMapGroup";
			this.colorMapGroup.Size = new System.Drawing.Size(268, 306);
			this.colorMapGroup.TabIndex = 10;
			this.colorMapGroup.TabStop = false;
			this.colorMapGroup.Text = "Color Map";
			// 
			// colorMapToolbar
			// 
			this.colorMapToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.colorMapToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton1,
            this.toolStripButton2});
			this.colorMapToolbar.Location = new System.Drawing.Point(3, 16);
			this.colorMapToolbar.Name = "colorMapToolbar";
			this.colorMapToolbar.Size = new System.Drawing.Size(262, 25);
			this.colorMapToolbar.TabIndex = 2;
			this.colorMapToolbar.Text = "toolStrip2";
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton3.Text = "Show";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "Import";
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton2.Text = "Export";
			// 
			// colorMapPreview
			// 
			this.colorMapPreview.BackColor = System.Drawing.Color.Black;
			this.colorMapPreview.Location = new System.Drawing.Point(6, 44);
			this.colorMapPreview.Name = "colorMapPreview";
			this.colorMapPreview.Size = new System.Drawing.Size(256, 256);
			this.colorMapPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.colorMapPreview.TabIndex = 1;
			this.colorMapPreview.TabStop = false;
			// 
			// normalMapGroup
			// 
			this.normalMapGroup.Controls.Add(this.normalMapToolbar);
			this.normalMapGroup.Controls.Add(this.normalMapPreview);
			this.normalMapGroup.Location = new System.Drawing.Point(560, 52);
			this.normalMapGroup.Name = "normalMapGroup";
			this.normalMapGroup.Size = new System.Drawing.Size(268, 306);
			this.normalMapGroup.TabIndex = 10;
			this.normalMapGroup.TabStop = false;
			this.normalMapGroup.Text = "Normal Map";
			// 
			// normalMapToolbar
			// 
			this.normalMapToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.normalMapToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton6,
            this.toolStripButton4,
            this.toolStripButton5});
			this.normalMapToolbar.Location = new System.Drawing.Point(3, 16);
			this.normalMapToolbar.Name = "normalMapToolbar";
			this.normalMapToolbar.Size = new System.Drawing.Size(262, 25);
			this.normalMapToolbar.TabIndex = 2;
			this.normalMapToolbar.Text = "toolStrip2";
			// 
			// toolStripButton6
			// 
			this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
			this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton6.Name = "toolStripButton6";
			this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton6.Text = "Show";
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton4.Text = "Import";
			// 
			// toolStripButton5
			// 
			this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
			this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton5.Name = "toolStripButton5";
			this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton5.Text = "Export";
			// 
			// normalMapPreview
			// 
			this.normalMapPreview.BackColor = System.Drawing.Color.Black;
			this.normalMapPreview.Location = new System.Drawing.Point(6, 44);
			this.normalMapPreview.Name = "normalMapPreview";
			this.normalMapPreview.Size = new System.Drawing.Size(256, 256);
			this.normalMapPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.normalMapPreview.TabIndex = 1;
			this.normalMapPreview.TabStop = false;
			// 
			// cliffMapGroup
			// 
			this.cliffMapGroup.Controls.Add(this.cliffMapToolbar);
			this.cliffMapGroup.Controls.Add(this.cliffMapPreview);
			this.cliffMapGroup.Location = new System.Drawing.Point(834, 52);
			this.cliffMapGroup.Name = "cliffMapGroup";
			this.cliffMapGroup.Size = new System.Drawing.Size(268, 306);
			this.cliffMapGroup.TabIndex = 10;
			this.cliffMapGroup.TabStop = false;
			this.cliffMapGroup.Text = "Cliff Map";
			// 
			// cliffMapToolbar
			// 
			this.cliffMapToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.cliffMapToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton9,
            this.toolStripButton7,
            this.toolStripButton8});
			this.cliffMapToolbar.Location = new System.Drawing.Point(3, 16);
			this.cliffMapToolbar.Name = "cliffMapToolbar";
			this.cliffMapToolbar.Size = new System.Drawing.Size(262, 25);
			this.cliffMapToolbar.TabIndex = 2;
			this.cliffMapToolbar.Text = "toolStrip2";
			// 
			// toolStripButton9
			// 
			this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
			this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton9.Name = "toolStripButton9";
			this.toolStripButton9.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton9.Text = "Show";
			// 
			// toolStripButton7
			// 
			this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
			this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton7.Name = "toolStripButton7";
			this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton7.Text = "Import";
			// 
			// toolStripButton8
			// 
			this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
			this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton8.Name = "toolStripButton8";
			this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton8.Text = "Export";
			// 
			// cliffMapPreview
			// 
			this.cliffMapPreview.BackColor = System.Drawing.Color.Black;
			this.cliffMapPreview.Location = new System.Drawing.Point(6, 44);
			this.cliffMapPreview.Name = "cliffMapPreview";
			this.cliffMapPreview.Size = new System.Drawing.Size(256, 256);
			this.cliffMapPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.cliffMapPreview.TabIndex = 1;
			this.cliffMapPreview.TabStop = false;
			// 
			// alphaMap1Group
			// 
			this.alphaMap1Group.Controls.Add(this.alphaMap1Toolbar);
			this.alphaMap1Group.Controls.Add(this.alphaMap1Preview);
			this.alphaMap1Group.Location = new System.Drawing.Point(12, 364);
			this.alphaMap1Group.Name = "alphaMap1Group";
			this.alphaMap1Group.Size = new System.Drawing.Size(268, 306);
			this.alphaMap1Group.TabIndex = 10;
			this.alphaMap1Group.TabStop = false;
			this.alphaMap1Group.Text = "Alpha Map (Layer 1)";
			// 
			// alphaMap1Toolbar
			// 
			this.alphaMap1Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.alphaMap1Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton12,
            this.toolStripButton10,
            this.toolStripButton11});
			this.alphaMap1Toolbar.Location = new System.Drawing.Point(3, 16);
			this.alphaMap1Toolbar.Name = "alphaMap1Toolbar";
			this.alphaMap1Toolbar.Size = new System.Drawing.Size(262, 25);
			this.alphaMap1Toolbar.TabIndex = 2;
			this.alphaMap1Toolbar.Text = "toolStrip2";
			// 
			// toolStripButton12
			// 
			this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
			this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton12.Name = "toolStripButton12";
			this.toolStripButton12.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton12.Text = "Show";
			// 
			// toolStripButton10
			// 
			this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
			this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton10.Name = "toolStripButton10";
			this.toolStripButton10.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton10.Text = "Import";
			// 
			// toolStripButton11
			// 
			this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
			this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton11.Name = "toolStripButton11";
			this.toolStripButton11.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton11.Text = "Export";
			// 
			// alphaMap1Preview
			// 
			this.alphaMap1Preview.BackColor = System.Drawing.Color.Black;
			this.alphaMap1Preview.Location = new System.Drawing.Point(6, 44);
			this.alphaMap1Preview.Name = "alphaMap1Preview";
			this.alphaMap1Preview.Size = new System.Drawing.Size(256, 256);
			this.alphaMap1Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.alphaMap1Preview.TabIndex = 1;
			this.alphaMap1Preview.TabStop = false;
			// 
			// alphaMap2Group
			// 
			this.alphaMap2Group.Controls.Add(this.alphaMap2Toolbar);
			this.alphaMap2Group.Controls.Add(this.alphaMap2Preview);
			this.alphaMap2Group.Location = new System.Drawing.Point(286, 364);
			this.alphaMap2Group.Name = "alphaMap2Group";
			this.alphaMap2Group.Size = new System.Drawing.Size(268, 306);
			this.alphaMap2Group.TabIndex = 10;
			this.alphaMap2Group.TabStop = false;
			this.alphaMap2Group.Text = "Alpha Map (Layer 2)";
			// 
			// alphaMap2Toolbar
			// 
			this.alphaMap2Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.alphaMap2Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton15,
            this.toolStripButton13,
            this.toolStripButton14});
			this.alphaMap2Toolbar.Location = new System.Drawing.Point(3, 16);
			this.alphaMap2Toolbar.Name = "alphaMap2Toolbar";
			this.alphaMap2Toolbar.Size = new System.Drawing.Size(262, 25);
			this.alphaMap2Toolbar.TabIndex = 2;
			this.alphaMap2Toolbar.Text = "toolStrip2";
			// 
			// toolStripButton15
			// 
			this.toolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton15.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton15.Image")));
			this.toolStripButton15.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton15.Name = "toolStripButton15";
			this.toolStripButton15.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton15.Text = "Show";
			// 
			// toolStripButton13
			// 
			this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
			this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton13.Name = "toolStripButton13";
			this.toolStripButton13.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton13.Text = "Import";
			// 
			// toolStripButton14
			// 
			this.toolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton14.Image")));
			this.toolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton14.Name = "toolStripButton14";
			this.toolStripButton14.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton14.Text = "Export";
			// 
			// alphaMap2Preview
			// 
			this.alphaMap2Preview.BackColor = System.Drawing.Color.Black;
			this.alphaMap2Preview.Location = new System.Drawing.Point(6, 44);
			this.alphaMap2Preview.Name = "alphaMap2Preview";
			this.alphaMap2Preview.Size = new System.Drawing.Size(256, 256);
			this.alphaMap2Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.alphaMap2Preview.TabIndex = 1;
			this.alphaMap2Preview.TabStop = false;
			// 
			// alphaMap3Group
			// 
			this.alphaMap3Group.Controls.Add(this.alphaMap3Toolbar);
			this.alphaMap3Group.Controls.Add(this.alphaMap3Preview);
			this.alphaMap3Group.Location = new System.Drawing.Point(560, 364);
			this.alphaMap3Group.Name = "alphaMap3Group";
			this.alphaMap3Group.Size = new System.Drawing.Size(268, 306);
			this.alphaMap3Group.TabIndex = 10;
			this.alphaMap3Group.TabStop = false;
			this.alphaMap3Group.Text = "Alpha Map (Layer 3)";
			// 
			// alphaMap3Toolbar
			// 
			this.alphaMap3Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.alphaMap3Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton18,
            this.toolStripButton16,
            this.toolStripButton17});
			this.alphaMap3Toolbar.Location = new System.Drawing.Point(3, 16);
			this.alphaMap3Toolbar.Name = "alphaMap3Toolbar";
			this.alphaMap3Toolbar.Size = new System.Drawing.Size(262, 25);
			this.alphaMap3Toolbar.TabIndex = 2;
			this.alphaMap3Toolbar.Text = "toolStrip2";
			// 
			// toolStripButton18
			// 
			this.toolStripButton18.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton18.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton18.Image")));
			this.toolStripButton18.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton18.Name = "toolStripButton18";
			this.toolStripButton18.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton18.Text = "Show";
			// 
			// toolStripButton16
			// 
			this.toolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton16.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton16.Image")));
			this.toolStripButton16.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton16.Name = "toolStripButton16";
			this.toolStripButton16.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton16.Text = "Import";
			// 
			// toolStripButton17
			// 
			this.toolStripButton17.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton17.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton17.Image")));
			this.toolStripButton17.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton17.Name = "toolStripButton17";
			this.toolStripButton17.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton17.Text = "Export";
			// 
			// alphaMap3Preview
			// 
			this.alphaMap3Preview.BackColor = System.Drawing.Color.Black;
			this.alphaMap3Preview.Location = new System.Drawing.Point(6, 44);
			this.alphaMap3Preview.Name = "alphaMap3Preview";
			this.alphaMap3Preview.Size = new System.Drawing.Size(256, 256);
			this.alphaMap3Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.alphaMap3Preview.TabIndex = 1;
			this.alphaMap3Preview.TabStop = false;
			// 
			// Editor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1110, 682);
			this.Controls.Add(this.cliffMapGroup);
			this.Controls.Add(this.normalMapGroup);
			this.Controls.Add(this.colorMapGroup);
			this.Controls.Add(this.alphaMap3Group);
			this.Controls.Add(this.alphaMap2Group);
			this.Controls.Add(this.alphaMap1Group);
			this.Controls.Add(this.heightMapGroup);
			this.Controls.Add(this.tools);
			this.Controls.Add(this.menu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menu;
			this.MaximizeBox = false;
			this.Name = "Editor";
			this.Text = "Editor";
			this.menu.ResumeLayout(false);
			this.menu.PerformLayout();
			this.tools.ResumeLayout(false);
			this.tools.PerformLayout();
			this.heightMapGroup.ResumeLayout(false);
			this.heightMapGroup.PerformLayout();
			this.heightMapToolbar.ResumeLayout(false);
			this.heightMapToolbar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.heightMapPreview)).EndInit();
			this.colorMapGroup.ResumeLayout(false);
			this.colorMapGroup.PerformLayout();
			this.colorMapToolbar.ResumeLayout(false);
			this.colorMapToolbar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.colorMapPreview)).EndInit();
			this.normalMapGroup.ResumeLayout(false);
			this.normalMapGroup.PerformLayout();
			this.normalMapToolbar.ResumeLayout(false);
			this.normalMapToolbar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.normalMapPreview)).EndInit();
			this.cliffMapGroup.ResumeLayout(false);
			this.cliffMapGroup.PerformLayout();
			this.cliffMapToolbar.ResumeLayout(false);
			this.cliffMapToolbar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cliffMapPreview)).EndInit();
			this.alphaMap1Group.ResumeLayout(false);
			this.alphaMap1Group.PerformLayout();
			this.alphaMap1Toolbar.ResumeLayout(false);
			this.alphaMap1Toolbar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.alphaMap1Preview)).EndInit();
			this.alphaMap2Group.ResumeLayout(false);
			this.alphaMap2Group.PerformLayout();
			this.alphaMap2Toolbar.ResumeLayout(false);
			this.alphaMap2Toolbar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.alphaMap2Preview)).EndInit();
			this.alphaMap3Group.ResumeLayout(false);
			this.alphaMap3Group.PerformLayout();
			this.alphaMap3Toolbar.ResumeLayout(false);
			this.alphaMap3Toolbar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.alphaMap3Preview)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menu;
		private System.Windows.Forms.ToolStripMenuItem menuFile;
		private System.Windows.Forms.ToolStripMenuItem menuFileNew;
		private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
		private System.Windows.Forms.ToolStripMenuItem menuFileSave;
		private System.Windows.Forms.ToolStripMenuItem menuFileSaveAs;
		private System.Windows.Forms.ToolStripSeparator menuFileSeperator1;
		private System.Windows.Forms.ToolStripMenuItem menuFileExit;
		private System.Windows.Forms.PictureBox heightMapPreview;
		private System.Windows.Forms.ToolStrip tools;
		private System.Windows.Forms.GroupBox heightMapGroup;
		private System.Windows.Forms.ToolStrip heightMapToolbar;
		private System.Windows.Forms.ToolStripButton heightMapImport;
		private System.Windows.Forms.ToolStripButton heightMapExport;
		private System.Windows.Forms.ToolStripButton heightMapShow;
		private System.Windows.Forms.GroupBox colorMapGroup;
		private System.Windows.Forms.ToolStrip colorMapToolbar;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.PictureBox colorMapPreview;
		private System.Windows.Forms.GroupBox normalMapGroup;
		private System.Windows.Forms.ToolStrip normalMapToolbar;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
		private System.Windows.Forms.ToolStripButton toolStripButton5;
		private System.Windows.Forms.ToolStripButton toolStripButton6;
		private System.Windows.Forms.PictureBox normalMapPreview;
		private System.Windows.Forms.GroupBox cliffMapGroup;
		private System.Windows.Forms.ToolStrip cliffMapToolbar;
		private System.Windows.Forms.ToolStripButton toolStripButton7;
		private System.Windows.Forms.ToolStripButton toolStripButton8;
		private System.Windows.Forms.ToolStripButton toolStripButton9;
		private System.Windows.Forms.PictureBox cliffMapPreview;
		private System.Windows.Forms.GroupBox alphaMap1Group;
		private System.Windows.Forms.ToolStrip alphaMap1Toolbar;
		private System.Windows.Forms.ToolStripButton toolStripButton10;
		private System.Windows.Forms.ToolStripButton toolStripButton11;
		private System.Windows.Forms.ToolStripButton toolStripButton12;
		private System.Windows.Forms.PictureBox alphaMap1Preview;
		private System.Windows.Forms.GroupBox alphaMap2Group;
		private System.Windows.Forms.ToolStrip alphaMap2Toolbar;
		private System.Windows.Forms.ToolStripButton toolStripButton13;
		private System.Windows.Forms.ToolStripButton toolStripButton14;
		private System.Windows.Forms.ToolStripButton toolStripButton15;
		private System.Windows.Forms.PictureBox alphaMap2Preview;
		private System.Windows.Forms.GroupBox alphaMap3Group;
		private System.Windows.Forms.ToolStrip alphaMap3Toolbar;
		private System.Windows.Forms.ToolStripButton toolStripButton16;
		private System.Windows.Forms.ToolStripButton toolStripButton17;
		private System.Windows.Forms.ToolStripButton toolStripButton18;
		private System.Windows.Forms.PictureBox alphaMap3Preview;
		private System.Windows.Forms.ToolStripButton toolsNew;
		private System.Windows.Forms.ToolStripButton toolsOpen;
		private System.Windows.Forms.ToolStripButton toolsSave;
		private System.Windows.Forms.ToolStripButton toolsSaveAs;
	}
}