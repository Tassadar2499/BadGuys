using BadGuys.Engine.Utils;
using System.Linq;

namespace BadGuys.Systems
{
	public static class MoveZombies
	{
		public static void Delegate(Environment environment)
		{
			var zombies = environment.Zombies;
			foreach (var zombie in environment.Zombies)
			{
				var player = environment.Player;

				if (zombie.Center.GetLength(player.Center) <= zombie.Radius + player.Radius)
					continue;

				if (zombies.Skip(zombies.IndexOf(zombie) + 1).Any(z => zombie.Center.GetLength(z.Center) <= zombie.Radius + z.Radius))
					continue;

				zombie.Position += zombie.Velocity;
			}
		}
	}
}