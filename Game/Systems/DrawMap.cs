namespace BadGuys.Systems
{
	public static class DrawMap
	{
		public static void Delegate(Environment environment)
		{
			environment.Window.Draw(environment.Map);
		}
	}
}