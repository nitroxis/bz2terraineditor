using System;
using System.IO;

namespace BZ2TerrainEditor
{
	/// <summary>
	/// Represents a BattleZone II terrain.
	/// </summary>
	public class Terrain
	{
		#region Fields

		public readonly int Width;
		public readonly int Height;

		public readonly short[,] HeightMap;
		public readonly RGB[,] ColorMap;
		public readonly byte[,] NormalMap;
		public readonly byte[,] AlphaMap1;
		public readonly byte[,] AlphaMap2;
		public readonly byte[,] AlphaMap3;
		public readonly byte[,] CliffMap;
		public readonly uint[,] InfoMap;

		private short HeightMapLowest;
		private short HeightMapHeighest;

		#endregion

		#region Properties

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new Terrain.
		/// </summary>
		public Terrain(int width, int height)
		{
			if (width % 4 != 0) throw new ArgumentException("Width must be a multiple of 4.", "width");
			if (height % 4 != 0) throw new ArgumentException("Height must be a multiple of 4.", "height");
			
			this.Width = width;
			this.Height = height;

			this.HeightMap = new short[width, height];
			this.ColorMap = new RGB[width, height];
			this.NormalMap = new byte[width, height];
			this.AlphaMap1 = new byte[width, height];
			this.AlphaMap2 = new byte[width, height];
			this.AlphaMap3 = new byte[width, height];
			this.CliffMap = new byte[width, height];
			this.InfoMap = new uint[width / 4, height / 4];

			this.HeightMapLowest = short.MaxValue;
			this.HeightMapHeighest = short.MinValue;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Loads a terrain from the specified file.
		/// </summary>
		/// <param name="fileName">The name of the file.</param>
		/// <returns></returns>
		public static Terrain Load(string fileName)
		{
			Stream stream = File.OpenRead(fileName);
			try
			{
				Terrain terrain = Load(stream);
				return terrain;
			}
			finally
			{
				stream.Close();
			}
		}

		/// <summary>
		/// Loads a terrain from a stream.
		/// </summary>
		/// <param name="stream">The data stream.</param>
		/// <returns></returns>
		public static Terrain Load(Stream stream)
		{
			BinaryReader reader = new BinaryReader(stream);

			if (reader.ReadUInt32() != 0x52524554u)
				throw new Exception("Invalid magic number.");

			reader.ReadUInt32(); // version?
			reader.ReadUInt16(); // width?
			reader.ReadUInt16(); // height?

			int width = reader.ReadUInt16();
			int height = reader.ReadUInt16();

			Terrain terrain = new Terrain(width, height);

			for (int y = 0; y < height; y += 4)
			{
				for (int x = 0; x < width; x += 4)
				{
					// height map
					for (int cy = 0; cy < 4; cy++)
					{
						for (int cx = 0; cx < 4; cx++)
						{
							short value = reader.ReadInt16();
							terrain.HeightMap[x + cx, y + cy] = value;
							if (value < terrain.HeightMapLowest) terrain.HeightMapLowest = value;
							if (value > terrain.HeightMapHeighest) terrain.HeightMapHeighest = value;
						}
					}

					// normal map
					for (int cy = 0; cy < 4; cy++)
					{
						for (int cx = 0; cx < 4; cx++)
						{
							terrain.NormalMap[x + cx, y + cy] = reader.ReadByte();
						}
					}

					// color map
					for (int cy = 0; cy < 4; cy++)
					{
						for (int cx = 0; cx < 4; cx++)
						{
							terrain.ColorMap[x + cx, y + cy].R = reader.ReadByte();
							terrain.ColorMap[x + cx, y + cy].G = reader.ReadByte();
							terrain.ColorMap[x + cx, y + cy].B = reader.ReadByte();
						}
					}

					// alpha map 1
					for (int cy = 0; cy < 4; cy++)
					{
						for (int cx = 0; cx < 4; cx++)
						{
							terrain.AlphaMap1[x + cx, y + cy] = reader.ReadByte();
						}
					}

					// alpha map 2
					for (int cy = 0; cy < 4; cy++)
					{
						for (int cx = 0; cx < 4; cx++)
						{
							terrain.AlphaMap2[x + cx, y + cy] = reader.ReadByte();
						}
					}

					// alpha map 3
					for (int cy = 0; cy < 4; cy++)
					{
						for (int cx = 0; cx < 4; cx++)
						{
							terrain.AlphaMap3[x + cx, y + cy] = reader.ReadByte();
						}
					}

					// cliff map
					for (int cy = 0; cy < 4; cy++)
					{
						for (int cx = 0; cx < 4; cx++)
						{
							terrain.CliffMap[x + cx, y + cy] = reader.ReadByte();
						}
					}

					// info map
					terrain.InfoMap[x / 4, y / 4] = reader.ReadUInt32();
				}
			}

			return terrain;
		}

		#endregion
	}
}
