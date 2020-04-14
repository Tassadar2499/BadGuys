using BadGuys.Engine.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGuys.Systems
{
	public static class RotateZombieToPlayer
	{
		public static void Delegate(Environment environment)
		{
			var player = environment.Player;
			foreach (var zombie in environment.Zombies)
			{
				if (zombie.Center.GetLength(player.Center) <= zombie.Radius + player.Radius)
					continue;

				zombie.Sprite.Rotation = zombie.Position.GetAngle(environment.Player.Position);
			}
		}
	}
}
