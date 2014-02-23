namespace BZ2TerrainEditor
{
	partial class HeightMapRangeDialog
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
			this.infoLabel = new System.Windows.Forms.Label();
			this.minimumSelector = new System.Windows.Forms.NumericUpDown();
			this.maximumSelector = new System.Windows.Forms.NumericUpDown();
			this.minimumLabel = new System.Windows.Forms.Label();
			this.maximumLabel = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.minimumSelector)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.maximumSelector)).BeginInit();
			this.SuspendLayout();
			// 
			// infoLabel
			// 
			this.infoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.infoLabel.Location = new System.Drawing.Point(12, 9);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(310, 26);
			this.infoLabel.TabIndex = 1;
			this.infoLabel.Text = "Please enter the size of the terrain.";
			// 
			// minimumSelector
			// 
			this.minimumSelector.Location = new System.Drawing.Point(84, 38);
			this.minimumSelector.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
			this.minimumSelector.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
			this.minimumSelector.Name = "minimumSelector";
			this.minimumSelector.Size = new System.Drawing.Size(238, 20);
			this.minimumSelector.TabIndex = 2;
			this.minimumSelector.ValueChanged += new System.EventHandler(this.minimumSelector_ValueChanged);
			// 
			// maximumSelector
			// 
			this.maximumSelector.Location = new System.Drawing.Point(84, 64);
			this.maximumSelector.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
			this.maximumSelector.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
			this.maximumSelector.Name = "maximumSelector";
			this.maximumSelector.Size = new System.Drawing.Size(238, 20);
			this.maximumSelector.TabIndex = 3;
			this.maximumSelector.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
			this.maximumSelector.ValueChanged += new System.EventHandler(this.maximumSelector_ValueChanged);
			// 
			// minimumLabel
			// 
			this.minimumLabel.Location = new System.Drawing.Point(12, 38);
			this.minimumLabel.Name = "minimumLabel";
			this.minimumLabel.Size = new System.Drawing.Size(66, 20);
			this.minimumLabel.TabIndex = 4;
			this.minimumLabel.Text = "Minimum:";
			this.minimumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// maximumLabel
			// 
			this.maximumLabel.Location = new System.Drawing.Point(12, 64);
			this.maximumLabel.Name = "maximumLabel";
			this.maximumLabel.Size = new System.Drawing.Size(66, 20);
			this.maximumLabel.TabIndex = 4;
			this.maximumLabel.Text = "Maximum:";
			this.maximumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(12, 90);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(152, 25);
			this.cancelButton.TabIndex = 5;
			this.cancelButton.Text = "&Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(170, 90);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(152, 25);
			this.okButton.TabIndex = 6;
			this.okButton.Text = "&OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// HeightMapRangeDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 127);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.maximumLabel);
			this.Controls.Add(this.minimumLabel);
			this.Controls.Add(this.maximumSelector);
			this.Controls.Add(this.minimumSelector);
			this.Controls.Add(this.infoLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HeightMapRangeDialog";
			this.Text = "Height Map Range";
			((System.ComponentModel.ISupportInitialize)(this.minimumSelector)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.maximumSelector)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label infoLabel;
		private System.Windows.Forms.NumericUpDown minimumSelector;
		private System.Windows.Forms.NumericUpDown maximumSelector;
		private System.Windows.Forms.Label minimumLabel;
		private System.Windows.Forms.Label maximumLabel;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
	}
}