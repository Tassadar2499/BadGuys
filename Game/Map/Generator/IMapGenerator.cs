using SFML.Graphics;

namespace BadGuys.Map
{
	public interface IMapGenerator
	{
		uint Seed { get; }

		(Texture, VertexArray) Generate();
	}
}