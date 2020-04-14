using BadGuys.Engine.Utils;
using Newtonsoft.Json;
using SFML.Graphics;
using SFML.System;
using System;

namespace BadGuys.Entities
{
	[Serializable]
	public class Zombie : Drawable
	{
		[JsonIgnore]
		public Sprite Sprite { get; set; }
		public float Pulse => (Mass * Velocity).GetLength();
		public int Mass { get; set; }
		/// <summary>
		/// Коэфицент гашения импульса
		/// </summary>
		public int PulseExtinsionCoefficient { get; set; }
		public float Speed { get; set; }
		/// <summary>
		/// Максимальная предельная скорость зомби
		/// </summary>
		public float MaximumSpeed { get; set; }
		public float Radius { get; set; }
		public Vector2f Velocity { get; set; }
		public string SpritePath { get; set; }
		public Vector2f Direction { get; set; }
		public Vector2f StartPosition { get; set; }
		[JsonIgnore]
		public Vector2u Size => Sprite.Texture.Size;
		[JsonIgnore]
		public Vector2f Position
		{
			get => Sprite.Position;
			set	{ Sprite.Position = value; }
		}
		[JsonIgnore]
		public Vector2f Center => new Vector2f(
				Sprite.Position.X + Sprite.GetLocalBounds().Width,
				Sprite.Position.Y + Sprite.GetLocalBounds().Height
			);

		public Zombie(Sprite sprite, float radius, float speed)
		{
			Sprite = sprite;
			Speed = speed;
			Radius = radius;
			Velocity = new Vector2f(0, 0);
		}

		[JsonConstructor]
		public Zombie(string spritePath, float radius, float speed, Vector2f velocity, Vector2f startPosition, int mass, int pulseExtinsionCoefficient, float maximumSpeed)
		{
			SpritePath = spritePath;
			Sprite = new Sprite(Program.TextureManager[spritePath])
			{
				Scale = new Vector2f(0.75f, 0.75f)
			};
			Radius = radius;
			Speed = speed;
			Velocity = velocity;
			StartPosition = startPosition;
			Position = startPosition;
			Direction = Position.GetUnitVectorTo(new Vector2f(0, -1)).RotateAt(Position, 45f);
			Mass = mass;
			PulseExtinsionCoefficient = pulseExtinsionCoefficient;
			MaximumSpeed = maximumSpeed;
		}

		public void Draw(RenderTarget target, RenderStates states)
		{
			Sprite.Draw(target, states);
		}
	}
}