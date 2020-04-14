using SFML.System;
using SFML.Window;

namespace BadGuys.Engine.Utils
{
	public static class MouseExtension
	{
		//TODO: Запоминать для каждого кадра, а не вычислять занова
		public static Vector2f Position
			=> Program.Window.MapPixelToCoords(Mouse.GetPosition(Program.Window));
	}
}