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

		/// <summary>
		/// The width of the terrain.
		/// </summary>
		public readonly int Width;
		/// <summary>
		/// The height of the terrain.
		/// </summary>
		public readonly int Height;

		/// <summary>
		/// The height map.
		/// </summary>
		public readonly short[,] HeightMap;

		/// <summary>
		/// The RGB color map.
		/// </summary>
		public readonly RGB[,] ColorMap;

		/// <summary>
		/// The normal map.
		/// </summary>
		public readonly byte[,] NormalMap;

		/// <summary>
		/// The alpha map for layer 1.
		/// </summary>
		public readonly byte[,] AlphaMap1;

		/// <summary>
		/// The alpha map for layer 2.
		/// </summary>
		public readonly byte[,] AlphaMap2;

		/// <summary>
		/// The alpha map for layer 3.
		/// </summary>
		public readonly byte[,] AlphaMap3;

		/// <summary>
		/// The cliff map?
		/// </summary>
		public readonly CellType[,] CellMap;

		/// <summary>
		/// Cluster info.
		/// Bits 0-3:   Tile index for layer 0.
		/// Bits 4-7:   Tile index for layer 1.
		/// Bits 8-11:  Tile index for layer 2.
		/// Bits 12-15: Tile index for layer 3.
		/// Bit 16:     Cluster Visibility for layer 0.
		/// Bit 17:     Cluster Visibility for layer 1.
		/// Bit 18:     Cluster Visibility for layer 2.
		/// Bit 19:     Cluster Visibility for layer 3.
		/// Bits 20-23: Cluster owner team.
		/// Bits 24-25: Cluster build type.
		/// </summary>
		public readonly uint[,] InfoMap;

		private short heightMapMin;
		private short heightMapMax;

		#endregion

		#region Properties

		public short HeightMapMin
		{
			get { return this.heightMapMin; }	
		}

		public short HeightMapMax
		{
			get { return this.heightMapMax; }
		}

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
			this.CellMap = new CellType[width, height];
			this.InfoMap = new uint[width / 4, height / 4];

			this.Clear();

			this.heightMapMin = short.MaxValue;
			this.heightMapMax = short.MinValue;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Updates the min/max values.
		/// </summary>
		public void UpdateMinMax()
		{
			this.heightMapMin = short.MaxValue;
			this.heightMapMax = short.MinValue;
			for (int y = 0; y < this.Height; y++)
			{
				for (int x = 0; x < this.Width; x++)
				{
					if (this.HeightMap[x, y] < this.heightMapMin) this.heightMapMin = this.HeightMap[x, y];
					if (this.HeightMap[x, y] > this.heightMapMax) this.heightMapMax = this.HeightMap[x, y];
				}
			}
		}

		/// <summary>
		/// Writes the terrain to the specified file.
		/// </summary>
		/// <param name="fileName">The name of the file.</param>
		public void Write(string fileName)
		{
			Stream stream = File.Create(fileName);
			this.Write(stream);
			stream.Close();
		}
		
		/// <summary>
		/// Writes the terrain to the specified stream.
		/// </summary>
		/// <param name="stream">The destination stream.</param>
		public void Write(Stream stream)
		{
			BinaryWriter writer = new BinaryWriter(stream);

			writer.Write(0x52524554u); // 'TERR'
			writer.Write(0x00000003u); // version
			writer.Write((ushort)(0x10000 - this.Width / 2)); // not sure what these two are.
			writer.Write((ushort)(0x10000 - this.Height / 2)); // ^
			writer.Write((ushort)(this.Width / 2));
			writer.Write((ushort)(this.Height / 2));

			for (int y = 0; y < this.Height; y += 4)
			{
				for (int x = 0; x < this.Width; x += 4)
				{
					// height map
					for (int cy = 0; cy < 4; cy++)
					{
						for (int cx = 0; cx < 4; cx++)
						{
							writer.Write(this.HeightMap[x + cx, y + cy]);
						}
					}

					// normal map
					for (int cy = 0; cy < 4; cy++)
					{
						for (int cx = 0; cx < 4; cx++)
						{
							writer.Write(this.NormalMap[x + cx, y + cy]);
						}
					}

					// color map
					for (int cy = 0; cy < 4; cy++)
					{
						for (int cx = 0; cx < 4; cx++)
						{
							writer.Write(this.ColorMap[x + cx, y + cy].R);
							writer.Write(this.ColorMap[x + cx, y + cy].G);
							writer.Write(this.ColorMap[x + cx, y + cy].B);
						}
					}

					// alpha map 1
					for (int cy = 0; cy < 4; cy++)
					{
						for (int cx = 0; cx < 4; cx++)
						{
							writer.Write(this.AlphaMap1[x + cx, y + cy]);
						}
					}

					// alpha map 2
					for (int cy = 0; cy < 4; cy++)
					{
						for (int cx = 0; cx < 4; cx++)
						{
							writer.Write(this.AlphaMap2[x + cx, y + cy]);
						}
					}

					// alpha map 3
					for (int cy = 0; cy < 4; cy++)
					{
						for (int cx = 0; cx < 4; cx++)
						{
							writer.Write(this.AlphaMap3[x + cx, y + cy]);
						}
					}

					// cliff map
					for (int cy = 0; cy < 4; cy++)
					{
						for (int cx = 0; cx < 4; cx++)
						{
							writer.Write((byte)this.CellMap[x + cx, y + cy]);
						}
					}

					// info map
					writer.Write(this.InfoMap[x / 4, y / 4]);
				}
			}
		}

		/// <summary>
		/// Clears the terrain.
		/// </summary>
		public void Clear()
		{
			for (int y = 0; y < this.Height; y++)
			{
				for (int x = 0; x < this.Width; x++)
				{
					this.HeightMap[x, y] = 0;
					this.NormalMap[x, y] = 0;
					this.ColorMap[x, y].R = this.ColorMap[x, y].G = this.ColorMap[x, y].B = 255;
					this.AlphaMap1[x, y] = this.AlphaMap2[x, y] = this.AlphaMap3[x, y] = 0;
					this.CellMap[x, y] = 0;
				}	
			}

			for (int y = 0; y < this.Height / 4; y++)
			{
				for (int x = 0; x < this.Width / 4; x++)
				{
					this.InfoMap[x, y] = 0;
				}
			}
		}

		/// <summary>
		/// Reads a terrain from the specified file.
		/// </summary>
		/// <param name="fileName">The name of the file.</param>
		/// <returns></returns>
		public static Terrain Read(string fileName)
		{
			Stream stream = File.OpenRead(fileName);
			try
			{
				Terrain terrain = Read(stream);
				return terrain;
			}
			finally
			{
				stream.Close();
			}
		}

		/// <summary>
		/// Reads a terrain from a stream.
		/// </summary>
		/// <param name="stream">The data stream.</param>
		/// <returns></returns>
		public static Terrain Read(Stream stream)
		{
			BinaryReader reader = new BinaryReader(stream);

			if (reader.ReadUInt32() != 0x52524554u) // 'TERR'
				throw new Exception("Invalid magic number.");

			int version = reader.ReadInt32();

			if(version < 1 || version > 3)
				throw new NotSupportedException(string.Format("Version {0} is not supported.", version));

			reader.ReadUInt16(); // some other width?
			reader.ReadUInt16(); // some other height?

			int width = reader.ReadUInt16() * 2;
			int height = reader.ReadUInt16() * 2;

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
							if (value < terrain.heightMapMin) terrain.heightMapMin = value;
							if (value > terrain.heightMapMax) terrain.heightMapMax = value;
						}
						if (version < 3) reader.ReadInt16();
					}
					if (version < 3) reader.ReadBytes(10);

					// normal map
					for (int cy = 0; cy < 4; cy++)
					{
						for (int cx = 0; cx < 4; cx++)
						{
							terrain.NormalMap[x + cx, y + cy] = reader.ReadByte();
						}
						if (version < 3) reader.ReadByte();
					}
					if (version < 3) reader.ReadBytes(5);

					// color map
					for (int cy = 0; cy < 4; cy++)
					{
						for (int cx = 0; cx < 4; cx++)
						{
							terrain.ColorMap[x + cx, y + cy].R = reader.ReadByte();
							terrain.ColorMap[x + cx, y + cy].G = reader.ReadByte();
							terrain.ColorMap[x + cx, y + cy].B = reader.ReadByte();
						}
						if (version < 3) reader.ReadBytes(3);
					}
					if (version < 3) reader.ReadBytes(15);

					// alpha map 1
					for (int cy = 0; cy < 4; cy++)
					{
						for (int cx = 0; cx < 4; cx++)
						{
							terrain.AlphaMap1[x + cx, y + cy] = reader.ReadByte();
						}
						if (version < 3) reader.ReadByte();
					}
					if (version < 3) reader.ReadBytes(5);

					// alpha map 2
					for (int cy = 0; cy < 4; cy++)
					{
						for (int cx = 0; cx < 4; cx++)
						{
							terrain.AlphaMap2[x + cx, y + cy] = reader.ReadByte();
						}
						if (version < 3) reader.ReadByte();
					}
					if (version < 3) reader.ReadBytes(5);

					// alpha map 3
					for (int cy = 0; cy < 4; cy++)
					{
						for (int cx = 0; cx < 4; cx++)
						{
							terrain.AlphaMap3[x + cx, y + cy] = reader.ReadByte();
						}
						if (version < 3) reader.ReadByte();
					}
					if (version < 3) reader.ReadBytes(5);

					// cliff map
					for (int cy = 0; cy < 4; cy++)
					{
						for (int cx = 0; cx < 4; cx++)
						{
							terrain.CellMap[x + cx, y + cy] = (CellType)reader.ReadByte();
						}
						if (version < 3) reader.ReadByte();
					}
					if (version < 3) reader.ReadBytes(5);

					// info map
					terrain.InfoMap[x / 4, y / 4] = reader.ReadUInt32();

					// ???
					if (version < 3) reader.ReadBytes(25);
					if (version == 2) reader.ReadByte();
				}
			}

			return terrain;
		}

		public void Translate(int translation)
		{
			for (int y = 0; y < this.Height; y++)
			{
				for (int x = 0; x < this.Width; x++)
				{
					int newValue = this.HeightMap[x, y];
					newValue += translation;

					if (newValue < short.MinValue)
						newValue = short.MinValue;
					else if (newValue > short.MaxValue)
						newValue = short.MaxValue;

					this.HeightMap[x, y] = (short)newValue;
				}
			}

			this.UpdateMinMax();
		}

		#endregion
	}
}
