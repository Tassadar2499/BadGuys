using SFML.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGuys.Engine
{
	public sealed class GameSound : Sound
	{
		private static readonly HashSet<GameSound> _gameSoundsHashSet
			= new HashSet<GameSound>();

		public GameSound(SoundBuffer soundBuffer)
			: base(soundBuffer)
		{
			_gameSoundsHashSet.Add(this);
		}

		private bool IsDisposed = false;
		protected override void Destroy(bool disposing)
		{
			if (IsDisposed) return;
			if (disposing)
			{
				_gameSoundsHashSet.Remove(this);
			}
			IsDisposed = true;
			base.Destroy(disposing);
		}
	}
}
