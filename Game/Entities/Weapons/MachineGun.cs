using BadGuys.Engine;
using BadGuys.Engine.Utils;
using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using System;
using System.Runtime.InteropServices;

namespace BadGuys.Entities.Weapons
{
	public class MachineGun : IWeapon
	{
		[JsonIgnore]
		public Timer ShootTimer { get; set; }

		[JsonIgnore]
		public Sprite Sprite { get; set; }
		
		[JsonIgnore]
		public GameSound Sound { get; set; }
		
		[JsonIgnore]
		public Vector2f Position { get => Sprite.Position; set => Sprite.Position = value; }
		
		[JsonIgnore]
		public float Rotation { get => Sprite.Rotation; set => Sprite.Rotation = value; }

		public MachineGun(Sprite sprite, string soundPath)
		{
			Sprite = sprite;
			ShootTimer = new Timer(0.15f);
			Sound = new GameSound(Program.SoundManager["Resources/sound/gunshot.wav"]);
			Sound.Volume = 1f;
		}

		[JsonConstructor]
		public MachineGun(string spritePath, string soundPath, float timeInterval, Vector2f playerPosition, Vector2f rifleOrigin)
		{
			ShootTimer = new Timer(timeInterval);

			Sprite = new Sprite(Program.TextureManager[spritePath])
			{
				Position = playerPosition,
				Origin = rifleOrigin
			};

			Sound = new GameSound(Program.SoundManager[soundPath]);
			Sound.Volume = 1f;
		}

		public void Draw(RenderTarget target, RenderStates states)
		{
			Sprite.Draw(target, states);
		}

		#region Dispose

		//Флаг - был ли метод Dispose уже вызван?
		private bool _disposed = false;

		//Создание экземпляра SafeHandle
		private readonly SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);

		/// <summary>
		/// Основная реализация метода Dispose, для очистки объекта
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Переопределение базовой скрытой реализации Dispose
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
				return;

			if (disposing)
			{
				_handle?.Dispose();
				Sprite?.Dispose();
				Sound?.Dispose();
			}

			_disposed = true;
		}

		#endregion Dispose
	}
}