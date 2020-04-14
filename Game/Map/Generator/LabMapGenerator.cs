using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BadGuys.Map
{
	public class LabMapGenerator : IMapGenerator
	{
		public uint Seed => 0;

		private readonly TileSet _tileSet;

		public LabMapGenerator(string tileSetPath)
		{
			_tileSet = new TileSet(tileSetPath);
		}

		public (Texture, VertexArray) Generate()
		{
			const int Width = 30;
			const int Hiegth = 20;
			return (_tileSet.Texture, GenerateMap(Width, Hiegth));
		}

		private VertexArray GenerateMap(uint Width, uint Hiegth)
		{
			var result = new VertexArray(PrimitiveType.Quads, 4 * Width * Hiegth);

			var map = GenerateMap(100, 100, 8, 20);

			for (var y = 0; y < 100; y++)
			{
				for (var x = 0; x < 100; x++)
				{
					if (map[y][x] != 1) continue;

					var position = new Vector2f(x, y) * _tileSet.TileSize;
					result.AppendAll(_tileSet.BuildQuad(1, position));
				}
			}

			//for (int y = 0; y < Hiegth; y++)
			//{
			//	for (int x = 0; x < Width; x++)
			//	{
			//		var position = new Vector2f(x, y) * _tileSet.TileSize;
			//		var tileIndex = TileIndexFromPosition(x, y, (int)Width, (int)Hiegth);
			//		result.AppendAll(_tileSet.BuildQuad(tileIndex, position));
			//	}
			//}

			return result;
		}

		private class Room
		{
			public Vector2f Size;
			public readonly Vector2i Position;
			public readonly Vector2f SizeKoef;

			public Room(Vector2i pos, Vector2f koef)
			{
				Position = pos;
				Size = new Vector2f(1f, 1f);
				SizeKoef = koef;
			}

			public bool Intersects(Room other)
			{
				var currentRect = new FloatRect((Vector2f)Position - Size / 2f, Size);
				var otherRect = new FloatRect((Vector2f)other.Position - other.Size / 2f, other.Size);

				return currentRect.Intersects(otherRect);
			}

			public void Inflate()
			{
				Size += SizeKoef;
			}

			public void Deflate()
			{
				Size -= SizeKoef;
			}
		}

		private static int[][] GenerateMap(int sizeX, int sizeY, int roomMinSize, int roomCount)
		{
			var rand = new Random();
			var result = new int[sizeY][];
			for (var i = 0; i < sizeY; i++)
				result[i] = new int[sizeX];

			var rooms = new List<Room>(roomCount);
			for (var i = 0; i < roomCount; i++)
			{
				var pos = new Vector2i(rand.Next(0, sizeX), rand.Next(0, sizeY));
				var koef = new Vector2f((float)rand.NextDouble() / 2f + 0.5f, (float)rand.NextDouble() / 2f + 0.5f);
				rooms.Add(new Room(pos, koef));
			}

			var toDelete = new List<Room>();

			for (var c = 0; c < roomMinSize; c++)
			{
				for (var i = 0; i < rooms.Count; i++)
				{
					if (toDelete.Contains(rooms[i]))
						continue;

					rooms[i].Inflate();

					for (var j = 0; j < rooms.Count; j++)
					{
						if (i == j || toDelete.Contains(rooms[j]))
							continue;

						if (rooms[i].Intersects(rooms[j]))
						{
							if (rooms[j].Size.X < roomMinSize || rooms[j].Size.Y < roomMinSize)
							{
								toDelete.Add(rooms[j]);
								continue;
							}

							rooms[i].Deflate();
							break;
						}
					}
				}
			}

			foreach (var room in rooms.Where(room => !toDelete.Contains(room)))
				for (var y = room.Position.Y - (int)room.Size.Y; y < room.Position.Y + (int)room.Size.Y; y++)
					for (var x = room.Position.X - (int)room.Size.X; x < room.Position.X + (int)room.Size.X; x++)
						if (x >= 0 && y >= 0 && x < sizeX && y < sizeY)
							result[y][x] = 1;
			
			return result;
		}

		public static int TileIndexFromPosition(int x, int y, int width, int hiegth)
		{
			if (x == 0 && y == 0)
				return 0;
			if (x == width - 1 && y == 0)
				return 1;
			if (x == width - 1 && y == hiegth - 1)
				return 2;
			if (x == 0 && y == hiegth - 1)
				return 3;

			if (x == 0)
				return 4;
			if (x == width - 1)
				return 5;
			if (y == 0)
				return 6;
			if (y == hiegth - 1)
				return 7;

			return 8;
		}
	}
}