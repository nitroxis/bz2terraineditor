namespace BZ2TerrainEditor
{
	partial class AboutDialog
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
			this.authorLabel = new System.Windows.Forms.LinkLabel();
			this.titleLabel = new System.Windows.Forms.Label();
			this.iconsLabel = new System.Windows.Forms.LinkLabel();
			this.thanksLabel = new System.Windows.Forms.Label();
			this.versionLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// authorLabel
			// 
			this.authorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.authorLabel.LinkArea = new System.Windows.Forms.LinkArea(11, 8);
			this.authorLabel.Location = new System.Drawing.Point(12, 45);
			this.authorLabel.Name = "authorLabel";
			this.authorLabel.Size = new System.Drawing.Size(198, 13);
			this.authorLabel.TabIndex = 4;
			this.authorLabel.TabStop = true;
			this.authorLabel.Text = "Created by Nitroxis.";
			this.authorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.authorLabel.UseCompatibleTextRendering = true;
			this.authorLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.authorLabel_LinkClicked);
			// 
			// titleLabel
			// 
			this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titleLabel.Location = new System.Drawing.Point(12, 9);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(198, 13);
			this.titleLabel.TabIndex = 1;
			this.titleLabel.Text = "BattleZone II Terrain Editor";
			this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// iconsLabel
			// 
			this.iconsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.iconsLabel.LinkArea = new System.Windows.Forms.LinkArea(9, 17);
			this.iconsLabel.Location = new System.Drawing.Point(15, 58);
			this.iconsLabel.Name = "iconsLabel";
			this.iconsLabel.Size = new System.Drawing.Size(198, 13);
			this.iconsLabel.TabIndex = 0;
			this.iconsLabel.TabStop = true;
			this.iconsLabel.Text = "Icons by Yusuke Kamiyamane.";
			this.iconsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.iconsLabel.UseCompatibleTextRendering = true;
			this.iconsLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.iconsLabel_LinkClicked);
			// 
			// thanksLabel
			// 
			this.thanksLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.thanksLabel.Location = new System.Drawing.Point(12, 71);
			this.thanksLabel.Name = "thanksLabel";
			this.thanksLabel.Size = new System.Drawing.Size(198, 13);
			this.thanksLabel.TabIndex = 3;
			this.thanksLabel.Text = "Thanks to Nielk1 and BlackDragon.";
			this.thanksLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// versionLabel
			// 
			this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.versionLabel.Location = new System.Drawing.Point(12, 22);
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size(198, 23);
			this.versionLabel.TabIndex = 5;
			this.versionLabel.Text = "Version {0}.{1}.";
			this.versionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// AboutDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(222, 93);
			this.Controls.Add(this.versionLabel);
			this.Controls.Add(this.thanksLabel);
			this.Controls.Add(this.titleLabel);
			this.Controls.Add(this.iconsLabel);
			this.Controls.Add(this.authorLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutDialog";
			this.ShowInTaskbar = false;
			this.Text = "About";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.LinkLabel authorLabel;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.LinkLabel iconsLabel;
		private System.Windows.Forms.Label thanksLabel;
		private System.Windows.Forms.Label versionLabel;
	}
}