using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace BadGuys.Map
{
	public class TileSet
	{
		public Texture Texture { get; private set; }
		public int TileSize { get; private set; }

		private readonly List<Vector2f[]> _textureCoords;

		public TileSet(string path)
		{
			(Texture, TileSize, _textureCoords) = TileSetLoader.LoadFromFile(path);
		}

		public Vector2f[] this[int index]
			=> _textureCoords[index];

		public Vertex[] BuildQuad(int tileIndex, Vector2f position)
		{
			var textureCoord = _textureCoords[tileIndex];

			return new Vertex[]
			{
				new Vertex(position, textureCoord[0]),
				new Vertex(position + new Vector2f(TileSize, 0), textureCoord[1]),
				new Vertex(position + new Vector2f(TileSize, TileSize), textureCoord[2]),
				new Vertex(position + new Vector2f(0, TileSize), textureCoord[3])
			};
		}
	}
}