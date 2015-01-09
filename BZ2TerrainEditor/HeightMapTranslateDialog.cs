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
	public partial class HeightMapTranslateDialog : Form
	{
		#region Fields

		private short value;
		
		#endregion

		#region Properties

		public short Value
		{
			get { return this.value; }
		}

		#endregion

		#region Constructors

		public HeightMapTranslateDialog()
		{
			this.InitializeComponent();
		}
		
		#endregion

		#region Methods
		
		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
		
		private void okButton_Click(object sender, EventArgs e)
		{
			this.value = (short)this.valueSelector.Value;
			this.DialogResult = DialogResult.OK;
		}
		
		#endregion
	}
}
