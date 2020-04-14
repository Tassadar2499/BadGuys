namespace BadGuys.Systems
{
	public static class DrawPlayer
	{
		public static void Delegate(Environment environment)
		{
			environment.Window.Draw(environment.Player);
		}
	}
}