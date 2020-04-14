using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGuys.Systems
{
	public static class MoveCamera
	{
		public static void Delegate(Environment environment)
		{
			var camera = environment.Camera;
			camera.Center = environment.Player.Position;
			environment.Window.SetView(camera);
		}
	}
}
