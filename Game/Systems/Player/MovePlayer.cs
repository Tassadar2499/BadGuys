using BadGuys.Entities;
using SFML.System;
using SFML.Window;

namespace BadGuys.Systems
{
	public static class MovePlayer
	{
		public static void Delegate(Environment environment)
		{
			var player = environment.Player;

			void MovePlayer(Vector2f vector)
			{
				player.Sprite.Position += vector;
				player.Weapon.Position += vector;
			}

			if (Keyboard.IsKeyPressed(Keyboard.Key.A))
				MovePlayer(new Vector2f(-player.Speed, 0));
			if (Keyboard.IsKeyPressed(Keyboard.Key.D))
				MovePlayer(new Vector2f(player.Speed, 0));
			if (Keyboard.IsKeyPressed(Keyboard.Key.W))
				MovePlayer(new Vector2f(0, -player.Speed));
			if (Keyboard.IsKeyPressed(Keyboard.Key.S))
				MovePlayer(new Vector2f(0, player.Speed));
		}
	}
}