using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace BadGuys.Engine.Managers
{
	internal class TextureManager
	{
		private readonly Dictionary<string, Texture> _textures
			= new Dictionary<string, Texture>();

		public Texture Load(string filePath)
		{
			Logger.Log("Loading texture " + filePath + "...");

			var texture = new Texture(filePath);
			_textures.Add(filePath, texture);
			return texture;
		}

		public void LoadAll(params string[] filePathes)
		{
			foreach (var path in filePathes)
				Load(path);
		}

		public void Remove(string filePath)
		{
			_textures.Remove(filePath);
		}

		public void RemoveAll(params string[] filePathes)
		{
			foreach (var path in filePathes)
				Remove(path);
		}

		public Texture this[string filePath]
		{
			get => _textures.ContainsKey(filePath)
					? _textures[filePath]
					: Load(filePath);

			set => _textures[filePath] = value;
		}
	}
}
