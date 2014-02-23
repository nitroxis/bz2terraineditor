using System;

namespace BZ2TerrainEditor
{
	/// <summary>
	/// Defines the different terrain cell types.
	/// </summary>
	[Flags]
	public enum CellType : byte
	{
		Flat = 0x0,
		Cliff = 0x1,
		Water = 0x2,
		Building = 0x4,
		Lava = 0x8,
		Sloped = 0x10
	}
}
