using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGuys.Game.Entities
{
	public class Particle : Drawable
	{
		public Sprite _sprite;

		public Vector2f MovementUnitVector { get; set; }
		public float MovementSpeed { get; set; }
		public Vector2f MovementAccelerationUnitVector { get; set; }
		public float MovementAcceleration { get; set; }
		public float RotationSpeed { get; set; }
		public float RotationAcceleration { get; set; }

		public Particle(Sprite sprite)
		{
			_sprite = sprite;
		}

		public void Draw(RenderTarget target, RenderStates states)
		{
			target.Draw(_sprite, states);
		}
	}
}
