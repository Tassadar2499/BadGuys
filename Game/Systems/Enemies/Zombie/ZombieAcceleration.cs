using BadGuys.Engine.Utils;

namespace BadGuys.Systems
{
	internal class ZombieAcceleration
	{
		public static void Delegate(Environment environment)
		{
			var playerPosition = environment.Player.Sprite.Position;
			foreach (var zombie in environment.Zombies)
			{
				//TODO: Сделать ускорение через += до максимальной скорости на прямой
				var movementVector = zombie.Position.GetUnitVectorTo(playerPosition);

				//if (zombie.Velocity.GetLength() <= zombie.MaximumSpeed)
				//	zombie.Velocity += movementVector * zombie.Speed;

				zombie.Velocity = movementVector * zombie.Speed;
			}
		}
	}
}
