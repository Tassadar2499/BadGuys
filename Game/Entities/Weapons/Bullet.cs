using System;
using BadGuys.Engine.Utils;
using Newtonsoft.Json;
using SFML.Graphics;
using SFML.System;

namespace BadGuys.Entities.Weapons
{
	public class Bullet : Drawable
	{
		public RectangleShape Body { get; set; }
		public float Speed { get; set; }
		public Timer Timer { get; set; }
		public Vector2f MovementUnitVector { get; set; }

		public Bullet(Vector2f position, Vector2f moveUnitVector) :
		this
		(
			new RectangleShape(new Vector2f(30f, 2f))
			{
				Position = position,
				FillColor = Color.Yellow
			},
			moveUnitVector,
			Time.FromSeconds(4f),
			60f
		)
		{

		}

		public Bullet(RectangleShape body, Vector2f moveUnitVector, Time liveTime, float speed)
		{
			Body = body ?? throw new ArgumentNullException(nameof(body));
			Speed = speed;
			Timer = new Timer(liveTime);
			MovementUnitVector = moveUnitVector;
			Body.Rotation = moveUnitVector.GetAngle();
		}

		public void Draw(RenderTarget target, RenderStates states)
		{
			Body.Draw(target, states);
		}

		public Bullet Clone()
		{
			return new Bullet(Body, MovementUnitVector, Timer.Interval, Speed);
		}
	}
}