using System;
using System.Windows.Forms;

namespace BZ2TerrainEditor
{
	/// <summary>
	/// Main class.
	/// </summary>
	public static class Program
	{
		/// <summary>
		/// Entry point.
		/// </summary>
		[STAThread]
		public static void Main()
		{
			Terrain terrain = Terrain.Read(@"H:\Extracted\BZ2\data.pak\missions\isdf01\isdf01.ter");
			terrain.Write(@"D:\Temp\test.ter");
		}
	}
}
