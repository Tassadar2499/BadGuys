using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BadGuys.Map
{
	public static class TileSetLoader
	{
		// 1 строка - путь до текстуры
		// 2 строка - размер тайла
		// Далее до конца файла в каждой строчке по 8 целых чисел через пробел - координаты x и y
		// За пустую строку в конце файла отрежу ноги)
		//TODO: заменить на JSON
		public static (Texture, int, List<Vector2f[]>) LoadFromFile(string path)
		{
			var quads = new List<Vector2f[]>();

			using var stream = new StreamReader(path);
			var kek = stream.ReadLine(); ////АААЛОООО БЛЯЯЯДЬ КТО ТАК ДЕЛАЕТ?
			var texture = new Texture("Resources/Assets/Img/tileset.png");
			var tileSize = int.Parse(stream.ReadLine());

			while (!stream.EndOfStream)
			{
				var coords = stream.ReadLine()
					.Split(' ')
					.Select(int.Parse)
					.ToArray();

				if (coords.Length != 8)
					throw new Exception("Не правильный формат файла");

				quads.Add(CoordsToQuad(coords));
			}

			return (texture, tileSize, quads);
		}

		private static Vector2f[] CoordsToQuad(int[] array)
		{
			if (array == null || array.Length != 8)
				throw new ArgumentNullException(nameof(array), @"array is null");

			var result = new Vector2f[4];

			for (var i = 0; i < 4; i++)
				result[i] = new Vector2f(array[i * 2], array[i * 2 + 1]);

			return result;
		}
	}
}