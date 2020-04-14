using SFML.Graphics;
using SFML.System;
using System;

namespace BadGuys.Engine.Utils
{
	public static class VectorMath
	{
		/// <summary>
		/// Угол между векторами
		/// </summary>
		public static float GetAngle(this Vector2f a, Vector2f b)
		{
			return (float)Math.Atan2(a.Y - b.Y, a.X - b.X) / (float)Math.PI * 180;
		}

		/// <summary>
		/// Угол между вектором и осью координат
		/// </summary>
		public static float GetAngle(this Vector2f a)
		{
			return (float)Math.Atan2(a.Y, a.X) / (float)Math.PI * 180;
		}

		/// <summary>
		/// Длина вектора по 2 точкам
		/// </summary>
		public static float GetLength(this Vector2f a, Vector2f b)
		{
			return (a - b).GetLength();
		}

		/// <summary>
		/// Длина вектора
		/// </summary>
		public static float GetLength(this Vector2f vector)
		{
			return (float)Math.Sqrt((vector.X * vector.X) + (vector.Y * vector.Y));
		}

		/// <summary>
		/// Конвертация угла в градусах к радианам
		/// </summary>
		public static double ConvertToRadians(float angleGrad)
		{
			return angleGrad * Math.PI / 180.0f;
		}

		/// <summary>
		/// Вращение вектора на указанный угол относительно center
		/// </summary>
		public static Vector2f RotateAt(this Vector2f point, Vector2f center, float angleGrad)
		{
			var angle = (float)ConvertToRadians(angleGrad);

			var cos = (float)Math.Cos(angle);
			var sin = (float)Math.Sin(angle);

			var offset = point - center;
			var rotatedX = cos * offset.X - sin * offset.Y;
			var rotatedY = sin * offset.X + cos * offset.Y;

			return new Vector2f(rotatedX, rotatedY) + center;
		}

		/// <summary>
		/// Получение единичного вектора из текущего вектора
		/// </summary>
		public static Vector2f GetUnitVector(this Vector2f vector)
		{
			if (vector.Equals(new Vector2f()))
				return vector;

			return vector / vector.GetLength();
		}

		/// <summary>
		/// Получение единичного вектора по 2 точкам
		/// </summary>
		/// <param name="start"> точка начала </param>
		/// <param name="end"> точка конца </param>
		/// <returns>единичный вектор</returns>
		public static Vector2f GetUnitVectorTo(this Vector2f start, Vector2f end)
		{
			if (start.Equals(end))
				return new Vector2f(0, 0);

			var vector = end - start;

			return vector / vector.GetLength();
		}

		/// <summary>
		/// Получение единичного вектора и расстояния между точками
		/// </summary>
		/// <param name="start"> точка начала </param>
		/// <param name="end"> точка конца </param>
		/// <returns>единичный вектор, расстояние между точками</returns>
		public static (Vector2f, float) GetUnitVectorAndRange(this Vector2f start, Vector2f end)
		{
			if (start.Equals(end))
				return (new Vector2f(0, 0), 0);

			var vector = end - start;
			var range = vector.GetLength();

			return (vector / range, range);
		}

		/// <summary>
		/// Получение координаты точки на заданном расстоянии на прямой, проходящей через 2 точке,
		/// </summary>
		/// <param name="length">длина вектора</param>
		/// <param name="start">точка начала вектора</param>
		/// <param name="end">точка конца вектора</param>
		/// <returns>координаты точки на прямой, проходящей через данный вектор</returns>
		public static Vector2f GetPointOnVector(float length, Vector2f start, Vector2f end)
		{
			return start + start.GetUnitVectorTo(end) * length;
		}

		/// <summary>
		/// Проверка вхождения вектора в круг заданного радиуса
		/// </summary>
		public static bool InCircle(this Vector2f point, Vector2f circleCenter, float radius)
		{
			var lenght = circleCenter - point;

			return lenght.X * lenght.X + lenght.Y * lenght.Y <= radius * radius;
		}

		/// <summary>
		/// Проверка на пересечение двух окружностей
		/// </summary>
		public static bool TwoCircleIntersection(Vector2f centerA, Vector2f centerB, float radiusA, float radiusB)
		{
			return GetLength(centerA, centerB) <= radiusA + radiusB;
		}

		/*

		/// <summary>
		/// Проверка на пересечение двух окружностей
		/// </summary>
		public static bool TwoCircleIntersection(RectangleShape bodyA, RectangleShape bodyB)
		{
			return TwoCircleIntersection(bodyA.Position, bodyB.Position, bodyA.GetRadius(), bodyB.GetRadius());
		}

		/// <summary>
		/// Проверка на пересечение двух окружностей
		/// </summary>
		public static bool TwoCircleIntersection(RectangleShape body, Sprite sprite)
		{
			return TwoCircleIntersection(body.Position, sprite.Position, body.GetRadius(), sprite.GetRadius());
		}

		/// <summary>
		/// Получение радиуса тела
		/// </summary>
		public static float GetRadius(this RectangleShape body)
		{
			var size = body.Size;
			return Math.Max(size.X, size.Y) / 2;
		}

		/// <summary>
		/// Получение радиуса тела
		/// </summary>
		public static float GetRadius(this Sprite sprite)
		{
			var bound = sprite.GetLocalBounds();
			var sizeX = bound.Width * sprite.Scale.X;
			var sizeY = bound.Height * sprite.Scale.Y;

			return Math.Max(sizeX, sizeY) / 2;
		}

		/// <summary>
		/// Получить вектор отталкивания двух объектов друг от друга
		/// </summary>
		/// <param name="delta">Сила отталкивания</param>
		public static Vector2f GetVectorPushTwoObjectsAway(Vector2f firstPosition, Vector2f secondPostition, float delta)
		{
			return firstPosition.GetUnitVectorTo(secondPostition) * delta;
		}
		*/
	}
}