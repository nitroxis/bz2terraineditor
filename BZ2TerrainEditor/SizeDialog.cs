using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BZ2TerrainEditor
{
	public partial class SizeDialog : Form
	{
		#region Fields

		private int selectedSize;
		
		#endregion

		#region Properties

		public int SelectedSize
		{
			get { return this.selectedSize; }
		}

		#endregion

		#region Constructors

		public SizeDialog()
		{
			this.InitializeComponent();
		}

		#endregion

		#region Methods

		private void okButton_Click(object sender, EventArgs e)
		{
			this.selectedSize = (int)this.valueSelector.Value;
			this.DialogResult = DialogResult.OK;
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		#endregion
	}
}
