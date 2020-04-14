using SFML.Audio;
using System.Collections.Generic;

namespace BadGuys.Engine.Managers
{
	internal class SoundManager
	{
		private readonly Dictionary<string, SoundBuffer> _soundBuffers;

		public SoundManager()
		{
			_soundBuffers = new Dictionary<string, SoundBuffer>();
		}

		public void LoadSoundBuffer(params string[] pathes)
		{
			foreach (var path in pathes)
			{
				Logger.Log("Loading sound " + path);
				var sound = new SoundBuffer(path);
				_soundBuffers.Add(path, sound);
			}
		}

		public SoundBuffer this[string filePath]
		{
			get
			{
				if (!_soundBuffers.ContainsKey(filePath))
					LoadSoundBuffer(filePath);

				return _soundBuffers[filePath];
			}
		}
	}
}