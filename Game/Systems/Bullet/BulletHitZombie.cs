using BadGuys.Entities;
using BadGuys.Entities.Weapons;
using BadGuys.Engine.Utils;
using System.Collections.Generic;
using System.Linq;

namespace BadGuys.Systems
{
	public static class BulletHitZombie
	{
		public static void Delegate(Environment environment)
		{
			environment.Bullets.RemoveAll(bullet => CheckBulletCollision(bullet, environment.Zombies));
		}

		private static bool CheckBulletCollision(Bullet bullet, List<Zombie> zombies)
			=> zombies.Any(z => bullet.Body.Position.InCircle(z.Position, z.Size.X / 2));
	}
}