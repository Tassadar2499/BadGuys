using System;
using SFML.Graphics;
using SFML.System;

namespace BadGuys.Entities.Weapons
{
	public interface IWeapon : IDisposable, Drawable
	{
		Vector2f Position { get; set; }
		float Rotation { get; set; }
	}
}
