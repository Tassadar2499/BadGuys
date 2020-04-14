using BadGuys.Engine.Utils;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using BadGuys.Entities.Weapons;

namespace BadGuys.Systems
{
	public static class MachineGunShoot
	{
		public static void Delegate(Environment environment)
		{
			var weapon = environment.Player.Weapon;

			if (weapon is MachineGun machineGun)
			{
				machineGun.ShootTimer.Update();

				if (Mouse.IsButtonPressed(Mouse.Button.Left) && machineGun.ShootTimer.Ticked)
					MakeRifleShoot(environment, machineGun);
			}
		}

		private static void MakeRifleShoot(Environment environment, MachineGun machineGun)
		{
			var mousePosition = MouseExtension.Position;
			var rifleBound = machineGun.Sprite.GetLocalBounds();

			var rifleLength = rifleBound.Width * machineGun.Sprite.Scale.X;

			//В случае, если юзверь тыкнул на позицию игрока с винтовкой, пуля не должна вылетать
			//DIMAN UPDATE: Почему? Лучше пусть стреляет. Только здесь ошибка в коде: если нажать слишком близко,
			//то пуля летит обратно
			//TODO: поправить с.м. выше
			if (rifleLength >= VectorMath.GetLength(machineGun.Sprite.Position, mousePosition))
				return;

			//Левая верхня точка спрайта оружия
			var barrelPosition = VectorMath.GetPointOnVector(rifleLength, machineGun.Sprite.Position, mousePosition);
			//Точка, относительно которой вращалась винтовка
			var barrelOrigin = machineGun.Sprite.Origin.RotateAt(new Vector2f(), machineGun.Sprite.Rotation);

			//угол поворота винтовки
			var rifleAngle = VectorMath.ConvertToRadians(machineGun.Sprite.Rotation);
			//центр винтовки по Y
			var rifleYCenter = rifleBound.Height * machineGun.Sprite.Scale.Y / 2.0f;

			//Смещение дула до центра с поворота на угол rifleAngle
			var barrelOffset = rifleYCenter * new Vector2f(
				-(float)Math.Sin(rifleAngle),
				 (float)Math.Cos(rifleAngle)
			);

			var moveUnitVector = barrelPosition.GetUnitVectorTo(mousePosition);

			environment.Bullets.Add(CreateBullet(barrelPosition + barrelOffset - barrelOrigin, moveUnitVector));

			//Звук выстрела из винтовки
			machineGun.Sound.Play();
		}

		private static Bullet CreateBullet(Vector2f position, Vector2f moveUnitVector)
			=> new Bullet(position, moveUnitVector);
	}
}