using BadGuys.Engine.Utils;
using System.Threading.Tasks;

namespace BadGuys.Systems
{
	public static class ZombiesCollisionPlayer
	{
		public static void Delegate(Environment environment)
		{
			var zombies = environment.Zombies;
			var player = environment.Player;

			Parallel.ForEach(zombies, zombie =>
			{
				var zombieCenter = zombie.Center;
				var playerCenter = player.Center;

				if (zombieCenter.GetLength(playerCenter) <= zombie.Radius + player.Radius)
				{
					var summaryPulse = ((zombie.Mass + player.Mass) * zombie.Velocity).GetLength();
					var directionVector = zombieCenter.GetUnitVectorTo(playerCenter);
					var pulseVector = directionVector * summaryPulse;

					zombie.Position -= pulseVector / (zombie.Mass * zombie.PulseExtinsionCoefficient);
				}
			});
		}
	}
}