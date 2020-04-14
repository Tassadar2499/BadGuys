using BadGuys.Engine.Utils;

namespace BadGuys.Systems
{
	public static class RotatePlayer
	{
		public static void Delegate(Environment environment)
		{
			var player = environment.Player;
			var angle = MouseExtension.Position.GetAngle(player.Sprite.Position);
			player.Sprite.Rotation = angle;
			player.Weapon.Rotation = angle;
		}
	}
}