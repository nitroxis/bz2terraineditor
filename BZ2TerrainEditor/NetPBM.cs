using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace BZ2TerrainEditor
{
	/// <summary>
	/// NetPBM implementations.
	/// </summary>
	public static class NetPBM
	{
		#region Methods

		private static string readToken(Stream stream)
		{
			StringBuilder str = new StringBuilder();

			while (true)
			{
				int c = stream.ReadByte();

				if (c < 0)
					break;
					
				if (char.IsWhiteSpace((char)c))
				{
					if (str.Length > 0)
						break;
				}
				else
				{
					str.Append((char)c);
				}
			}

			return str.ToString();
		}

		public static void WriteHeightmap(Stream stream, Terrain terrain)
		{
			StreamWriter writer = new StreamWriter(stream, Encoding.ASCII, 4096, true);

			writer.WriteLine("P2");
			writer.WriteLine("{0} {1}", terrain.Width.ToString(CultureInfo.InvariantCulture), terrain.Height.ToString(CultureInfo.InvariantCulture));
			writer.WriteLine("65535");

			for (int y = 0; y < terrain.Height; y++)
			{
				for (int x = 0; x < terrain.Width; x++)
				{
					writer.Write(((int)terrain.HeightMap[x, y] - terrain.HeightMapMin).ToString(CultureInfo.InvariantCulture));
					writer.Write(" ");
				}
				writer.WriteLine();
			}

			writer.Close();
		}

		public static void ReadHeightmap(Stream stream, Terrain terrain)
		{
			string header = readToken(stream);
			if (header != "P2")
				throw new NotSupportedException("Formats other than ASCII graymaps (P2) are not supported.");

			int width = int.Parse(readToken(stream), CultureInfo.InvariantCulture);
			if (width != terrain.Width)
				throw new Exception("Width mismatch.");

			int height = int.Parse(readToken(stream), CultureInfo.InvariantCulture);
			if (height != terrain.Height)
				throw new Exception("Height mismatch.");

			readToken(stream); // max.

			for (int y = 0; y < terrain.Height; y++)
			{
				for (int x = 0; x < terrain.Width; x++)
				{
					int value = int.Parse(readToken(stream), CultureInfo.InvariantCulture);
					if (value < 0 || value > 65535)
						throw new InvalidDataException("Invalid value.");

					value += short.MinValue;
					terrain.HeightMap[x, y] = (short)value;
				}
			}
			
			terrain.UpdateMinMax();
			
			int translation = -terrain.HeightMapMin;

			if (terrain.HeightMapMax + translation > short.MaxValue)
				translation = short.MaxValue - terrain.HeightMapMax;

			if (translation > 0)
				terrain.Translate(translation);
		}

		#endregion
	}
}
