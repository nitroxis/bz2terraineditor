using System;
using System.Windows.Forms;

namespace BZ2TerrainEditor
{
	public partial class HeightMapRangeDialog : Form
	{
		#region Fields

		private short minimum;
		private short maximum;

		#endregion

		#region Properties

		public short Minimum
		{
			get { return this.minimum; }
		}

		public short Maximum
		{
			get { return this.maximum; }
		}

		#endregion

		#region Constructors

		public HeightMapRangeDialog()
		{
			this.InitializeComponent();
		}

		#endregion

		#region Methods

		private void minimumSelector_ValueChanged(object sender, EventArgs e)
		{
			this.maximumSelector.Minimum = this.minimumSelector.Value;
		}

		private void maximumSelector_ValueChanged(object sender, EventArgs e)
		{
			this.minimumSelector.Maximum = this.maximumSelector.Value;
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			this.minimum = (short)this.minimumSelector.Value;
			this.maximum = (short)this.maximumSelector.Value;
			this.DialogResult = DialogResult.OK;
		}

		#endregion

	}
}
