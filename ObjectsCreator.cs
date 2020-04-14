using BadGuys.Entities;
using BadGuys.Entities.Weapons;
using BadGuys.Map;
using Newtonsoft.Json;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System.IO;

namespace BadGuys
{
	public static class ObjectsCreator
	{
		public static Environment CreateEnvironment(RenderWindow window)
		{
			var player = CreatePlayer();
			return new Environment(window)
			{
				Player = player,
				Map = new GameMap(new LabMapGenerator("Resources/img/tileset.txt")),
				Zombies = CreateZombies(),
				Camera = new View(player.Position, new Vector2f(1600f, 1200f))
			};
		}

		private static Player CreatePlayer()
		{
			var player = GetObjectFromSettings<Player>("Player");
			player.Weapon = GetObjectFromSettings<MachineGun>("Weapon/MachineGun");

			return player;
		}

		private static List<Zombie> CreateZombies()
		{
			var listZombies = new List<Zombie>();

			var zombie1 = GetObjectFromSettings<Zombie>("Enemies/Zombie");

			var zombie2 = GetObjectFromSettings<Zombie>("Enemies/Zombie");
			zombie2.Position = new Vector2f(100, 200);

			var zombie3 = GetObjectFromSettings<Zombie>("Enemies/Zombie");
			zombie3.Position = new Vector2f(200, 100);

			listZombies.Add(zombie1);
			listZombies.Add(zombie2);
			listZombies.Add(zombie3);

			return listZombies;
		}

		public static T GetObjectFromSettings<T>(string objectPath)
		{
			var path = $"Resources/Assets/Settings/{objectPath}.json";
			var strContent = File.ReadAllText(path);

			return JsonConvert.DeserializeObject<T>(strContent);
		}

		public static string SerializeObject(object toSerialize)
		{
			return JsonConvert.SerializeObject(toSerialize);
		}
	}
}