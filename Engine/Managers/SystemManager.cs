using System.Collections.Generic;

namespace BadGuys.Engine.Managers
{
	internal class SystemsManager
	{
		public List<GameSystem> Systems
			= new List<GameSystem>();

		public void Add(GameSystem system)
			=> Systems.Add(system);

		public void Invoke(Environment e)
			=> Systems.ForEach(a => a(e));

		public SystemsManager(params GameSystem[] gameSystems)
		{
			foreach (var system in gameSystems)
				Add(system);
		}
	}
}