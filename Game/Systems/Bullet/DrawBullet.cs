namespace BadGuys.Systems
{
	/// <summary>
	/// Дефолтная отрисовка пуль
	/// </summary>
	public static class DrawBullet
	{
		public static void Delegate(Environment environment)
		{
			environment.Bullets.ForEach(bullet => environment.Window.Draw(bullet.Body));
		}
	}
}