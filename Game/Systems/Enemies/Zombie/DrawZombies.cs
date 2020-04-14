namespace BadGuys.Systems
{
	public static class DrawZombies
	{
		public static void Delegate(Environment environment)
		{
			environment.Zombies.ForEach(zombie => environment.Window.Draw(zombie));
		}
	}
}