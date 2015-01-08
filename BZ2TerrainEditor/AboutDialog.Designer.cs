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
			this.versionLabel = new System.Windows.Forms.Label();
			this.iconsLabel = new System.Windows.Forms.LinkLabel();
			this.thanksLabel = new System.Windows.Forms.Label();
			this.closeButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// authorLabel
			// 
			this.authorLabel.AutoSize = true;
			this.authorLabel.LinkArea = new System.Windows.Forms.LinkArea(3, 8);
			this.authorLabel.Location = new System.Drawing.Point(125, 25);
			this.authorLabel.Name = "authorLabel";
			this.authorLabel.Size = new System.Drawing.Size(60, 17);
			this.authorLabel.TabIndex = 4;
			this.authorLabel.TabStop = true;
			this.authorLabel.Text = "by Nitroxis.";
			this.authorLabel.UseCompatibleTextRendering = true;
			this.authorLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.authorLabel_LinkClicked);
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titleLabel.Location = new System.Drawing.Point(12, 9);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(162, 13);
			this.titleLabel.TabIndex = 1;
			this.titleLabel.Text = "BattleZone II Terrain Editor";
			// 
			// versionLabel
			// 
			this.versionLabel.AutoSize = true;
			this.versionLabel.Location = new System.Drawing.Point(12, 25);
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size(76, 13);
			this.versionLabel.TabIndex = 2;
			this.versionLabel.Text = "Version {0}.{1}";
			// 
			// iconsLabel
			// 
			this.iconsLabel.AutoSize = true;
			this.iconsLabel.LinkArea = new System.Windows.Forms.LinkArea(9, 17);
			this.iconsLabel.Location = new System.Drawing.Point(12, 42);
			this.iconsLabel.Name = "iconsLabel";
			this.iconsLabel.Size = new System.Drawing.Size(159, 17);
			this.iconsLabel.TabIndex = 0;
			this.iconsLabel.TabStop = true;
			this.iconsLabel.Text = "Icons by Yusuke Kamiyamane.";
			this.iconsLabel.UseCompatibleTextRendering = true;
			this.iconsLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.iconsLabel_LinkClicked);
			// 
			// thanksLabel
			// 
			this.thanksLabel.AutoSize = true;
			this.thanksLabel.Location = new System.Drawing.Point(12, 59);
			this.thanksLabel.Name = "thanksLabel";
			this.thanksLabel.Size = new System.Drawing.Size(177, 13);
			this.thanksLabel.TabIndex = 3;
			this.thanksLabel.Text = "Thanks to Nielk1 and BlackDragon.";
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(12, 75);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(173, 25);
			this.closeButton.TabIndex = 0;
			this.closeButton.Text = "Close";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// AboutDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(197, 112);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.thanksLabel);
			this.Controls.Add(this.versionLabel);
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
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.LinkLabel authorLabel;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Label versionLabel;
		private System.Windows.Forms.LinkLabel iconsLabel;
		private System.Windows.Forms.Label thanksLabel;
		private System.Windows.Forms.Button closeButton;
	}
}