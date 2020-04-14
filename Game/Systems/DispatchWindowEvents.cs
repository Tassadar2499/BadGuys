namespace BadGuys.Systems
{
	public static class DispatchWindowEvents
	{
		public static void Delegate(Environment environment)
		{
			environment.Window.DispatchEvents();
		}
	}
}