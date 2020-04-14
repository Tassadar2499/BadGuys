using BadGuys.Entities;
using BadGuys.Entities.Weapons;
using BadGuys.Map;
using SFML.Graphics;
using System.Collections.Generic;

namespace BadGuys
{
	public class Environment
	{
		public View Camera { get; set; }
		public RenderWindow Window { get; private set; }
		public GameMap Map { get; set; }
		public Player Player { get; set; }

		public List<Zombie> Zombies
			= new List<Zombie>();

		public List<Bullet> Bullets
			= new List<Bullet>();

		public Environment(RenderWindow renderWindow)
		{
			Window = renderWindow;
		}
	}
}