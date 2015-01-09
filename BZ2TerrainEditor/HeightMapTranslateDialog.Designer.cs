namespace BZ2TerrainEditor
{
	partial class HeightMapTranslateDialog
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
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.valueLabel = new System.Windows.Forms.Label();
			this.valueSelector = new System.Windows.Forms.NumericUpDown();
			this.infoLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.valueSelector)).BeginInit();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(12, 64);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(152, 25);
			this.cancelButton.TabIndex = 10;
			this.cancelButton.Text = "&Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(170, 64);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(152, 25);
			this.okButton.TabIndex = 11;
			this.okButton.Text = "&OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// valueLabel
			// 
			this.valueLabel.Location = new System.Drawing.Point(12, 38);
			this.valueLabel.Name = "valueLabel";
			this.valueLabel.Size = new System.Drawing.Size(66, 20);
			this.valueLabel.TabIndex = 9;
			this.valueLabel.Text = "Value:";
			this.valueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// valueSelector
			// 
			this.valueSelector.Location = new System.Drawing.Point(84, 38);
			this.valueSelector.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
			this.valueSelector.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
			this.valueSelector.Name = "valueSelector";
			this.valueSelector.Size = new System.Drawing.Size(238, 20);
			this.valueSelector.TabIndex = 8;
			// 
			// infoLabel
			// 
			this.infoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.infoLabel.Location = new System.Drawing.Point(12, 9);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(310, 26);
			this.infoLabel.TabIndex = 7;
			this.infoLabel.Text = "Positive numbers will increase the height, negative numbers will decrease the hei" +
    "ght.";
			// 
			// HeightMapTranslateDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 101);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.valueLabel);
			this.Controls.Add(this.valueSelector);
			this.Controls.Add(this.infoLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HeightMapTranslateDialog";
			this.ShowInTaskbar = false;
			this.Text = "Height Map Translation";
			((System.ComponentModel.ISupportInitialize)(this.valueSelector)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label valueLabel;
		private System.Windows.Forms.NumericUpDown valueSelector;
		private System.Windows.Forms.Label infoLabel;
	}
}