using System;
using System.Windows.Forms;

namespace BZ2TerrainEditor
{
	/// <summary>
	/// Main class.
	/// </summary>
	public static class Program
	{
		private static int editorInstances;

		/// <summary>
		/// Gets or sets the number of editor instances.
		/// The application will exit when the number of instaces equals 0.
		/// </summary>
		public static int EditorInstances
		{
			get { return editorInstances; }
			set
			{
				editorInstances = value;
				if (editorInstances == 0)
				{
					Application.Exit();
				}
			}
		}
	
		/// <summary>
		/// Entry point.
		/// </summary>
		[STAThread]
		public static void Main()
		{
			Application.EnableVisualStyles();
			Editor editor = new Editor();
			editor.Show();
			Application.Run();
		}
	}
}
