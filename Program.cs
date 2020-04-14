using BadGuys.Engine;
using BadGuys.Engine.Managers;
using SFML.Graphics;
using SFML.Window;
using System;

namespace BadGuys
{
	internal static class Program
	{
		public static RenderWindow Window;
		public static Environment Environment;
		public static SystemsManager UpdateSystemsManager;
		public static SystemsManager DrawSystemsManager;
		public static TextureManager TextureManager;
		public static SoundManager SoundManager;

		private static void Main()
		{
			TextureManager = InitilizateTextureManager();
			Window = CreateRenderWindow(800, 600);

			SoundManager = InitilizateSoundManager();
			Environment = ObjectsCreator.CreateEnvironment(Window);
			UpdateSystemsManager = InitilizateUpdateSystemManager();
			DrawSystemsManager = InitilizateDrawSystemManager();

			while (Window.IsOpen)
			{
				UpdateSystemsManager.Invoke(Environment);

				Window.Clear();
				DrawSystemsManager.Invoke(Environment);
				Window.Display();
			}

			Logger.FlushContent();

			Window?.Dispose();
		}

		public static RenderWindow CreateRenderWindow(uint width, uint height)
		{
			var window = new RenderWindow(new VideoMode(width, height), "Bad Guys");
			window.Closed += WindowCloseHandler;
			window.SetFramerateLimit(60);

			return window;
		}

		private static void WindowCloseHandler(object sender, EventArgs e)
		{
			(sender as RenderWindow)?.Close();
			Logger.Log("Close window");
		}

		private static SystemsManager InitilizateUpdateSystemManager()
		{
			return new SystemsManager(
					   Systems.DispatchWindowEvents.Delegate,
					   Systems.MovePlayer.Delegate,
					   Systems.MoveCamera.Delegate,
					   Systems.RotatePlayer.Delegate,

					   Systems.MachineGunShoot.Delegate,
					   Systems.MoveBullets.Delegate,
					   Systems.BulletHitZombie.Delegate,

					   Systems.ZombieAcceleration.Delegate,
					   Systems.ZombieCollision.Delegate,
					   Systems.ZombiesCollisionPlayer.Delegate,
					   Systems.MoveZombies.Delegate,
					   Systems.RotateZombieToPlayer.Delegate
				   );
		}

		private static SystemsManager InitilizateDrawSystemManager()
		{
			return new SystemsManager(
					   Systems.DrawMap.Delegate,
					   Systems.DrawPlayer.Delegate,
					   Systems.DrawBullet.Delegate,
					   Systems.DrawZombies.Delegate
				   );
		}

		private static TextureManager InitilizateTextureManager()
		{
			var manager = new TextureManager();

			//

			return manager;
		}

		private static SoundManager InitilizateSoundManager()
		{
			var manager = new SoundManager();

			manager.LoadSoundBuffer("Resources/sound/gunshot.wav");

			return manager;
		}
	}
}
