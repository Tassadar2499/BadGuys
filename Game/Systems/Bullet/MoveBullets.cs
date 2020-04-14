using System.Threading.Tasks;
using BadGuys.Entities.Weapons;

namespace BadGuys.Systems
{
	public static class MoveBullets
	{
		public static void Delegate(Environment environment)
		{
			environment.Bullets.RemoveAll(bullet => bullet.Timer.Ticked);

			Parallel.ForEach(environment.Bullets, MoveBullet);
		}

		private static void MoveBullet(Bullet bullet)
		{
			bullet.Body.Position += bullet.MovementUnitVector * bullet.Speed;
			bullet.Timer.Update();
		}
	}
}