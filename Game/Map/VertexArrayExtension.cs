using SFML.Graphics;

namespace BadGuys.Map
{
	public static class VertexArrayExtension
	{
		public static void AppendAll(this VertexArray array, Vertex[] vertexes)
		{
			foreach (var vertex in vertexes)
				array.Append(vertex);
		}
	}
}