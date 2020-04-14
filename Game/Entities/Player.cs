using BadGuys.Engine.Utils;
using Microsoft.Win32.SafeHandles;
using SFML.Graphics;
using SFML.System;
using System;
using System.Runtime.InteropServices;
using BadGuys.Entities.Weapons;
using Newtonsoft.Json;

namespace BadGuys.Entities
{
	public class Player : Drawable, IDisposable
	{
		public int Mass { get; set; }
		/// <summary>
		/// Коэфицент гашения импульса
		/// </summary>
		public int PulseExtinsionCoefficient { get; set; }
		public float Speed { get; set; }
		[JsonIgnore]
		public Sprite Sprite { get; set; }
		[JsonIgnore]
		public IWeapon Weapon { get; set; }
		[JsonIgnore]
		public Vector2f Position 
			=> Sprite.Position;
		[JsonIgnore]
		public Vector2f Center
			=> new Vector2f(
				Sprite.Position.X + Sprite.GetLocalBounds().Width, 
				Sprite.Position.Y + Sprite.GetLocalBounds().Height
			);
		[JsonIgnore]
		public float Radius
			=> Sprite.GetLocalBounds().Width;

		public Player(Sprite sprite, float speed, IWeapon weapon)
		{
			Sprite = sprite;
			Speed = speed;
			Weapon = weapon;
		}

		[JsonConstructor]
		public Player(float speed, string playerSpritePath, Vector2f playerPosition, int mass)
		{			
			Speed = speed;

			var sprite = new Sprite(Program.TextureManager[playerSpritePath])
			{
				Position = playerPosition
			};
			sprite.Origin = (Vector2f)sprite.Texture.Size / 2.0f;

			Sprite = sprite;
			Mass = mass;
		}

		public void Draw(RenderTarget target, RenderStates states)
		{
			Weapon.Draw(target, states);
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
		/// Скрытая реализация Dispose
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
				return;

			if (disposing)
			{
				_handle?.Dispose();
				Sprite?.Dispose();
				Weapon?.Dispose();
			}

			_disposed = true;
		}

		#endregion Dispose
	}
}