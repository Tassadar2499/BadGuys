using Microsoft.Win32.SafeHandles;
using SFML.Graphics;
using System;
using System.Runtime.InteropServices;

namespace BadGuys.Map
{
	public class GameMap : Drawable, IDisposable
	{
		private Texture _texture;
		private VertexArray _vertexArray;

		public GameMap()
		{
			_vertexArray = new VertexArray();
		}

		public GameMap(IMapGenerator mapGenerator)
		{
			GenerateBy(mapGenerator);
		}

		public void GenerateBy(IMapGenerator mapGenerator)
		{
			(_texture, _vertexArray) = mapGenerator.Generate();
		}

		public void Draw(RenderTarget target, RenderStates states)
		{
			states.Texture = _texture;
			_vertexArray.Draw(target, states);
		}

		#region Dispose

		//Флаг - был ли метод Dispose уже вызван?
		private bool _disposed = false;

		//Создание экземпляра SafeHandle
		private readonly SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);

		/// <summary>
		/// Основная реализация метода Dispose, для очистки объекта
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Скрытая реализация Dispose
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
				return;

			if (disposing)
			{
				_handle.Dispose();
				_texture?.Dispose();
				_vertexArray?.Dispose();
			}

			_disposed = true;
		}

		#endregion Dispose
	}
}