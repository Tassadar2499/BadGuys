using BadGuys.Engine.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BadGuys.Systems
{
	public static class ZombieCollision
	{
		public static void Delegate(Environment e)
		{
			var creatures = e.Zombies;

			Parallel.ForEach(creatures, currentZombie =>
			{
				foreach (var secondZombie in creatures.Skip(creatures.IndexOf(currentZombie) + 1))
				{
					var currentZombieCenter = currentZombie.Center;
					var secondZombieCenter = secondZombie.Center;

					if (currentZombieCenter.GetLength(secondZombieCenter) <= currentZombie.Radius + secondZombie.Radius)
					{
						var summaryPulse = currentZombie.Pulse + secondZombie.Pulse;
						var directionVector = currentZombieCenter.GetUnitVectorTo(secondZombieCenter);
						var pulseVector = directionVector * summaryPulse;

						currentZombie.Position -= pulseVector / (currentZombie.Mass * currentZombie.PulseExtinsionCoefficient);
						secondZombie.Position += pulseVector / (secondZombie.Mass * secondZombie.PulseExtinsionCoefficient);
					}
				}
			});
		}
	}
}
