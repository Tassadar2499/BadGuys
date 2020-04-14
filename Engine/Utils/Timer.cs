using SFML.System;
using System;

namespace BadGuys.Engine.Utils
{
	public class Timer
	{
		private Clock Clock { get; set; } = new Clock();
		public Time Time { get; private set; } = Time.Zero;
		public Time Interval { get; set; }

		public delegate void TimerEventHandler();

		public event TimerEventHandler Tick;

		public bool Ticked { get; private set; }

		public Timer(float seconds)
		{
			var interval = Time.FromSeconds(seconds);
			if (interval.AsMilliseconds() <= 0)
				throw new ArgumentException("Interval must be > 0");

			Interval = interval;
		}

		public Timer(Time interval)
		{
			if (interval.AsMilliseconds() <= 0)
				throw new ArgumentException("Interval must be > 0");

			Interval = interval;
		}

		public void Update()
		{
			Time += Clock.Restart();

			//TODO: if заменить на while
			if (Time >= Interval)
			{
				Ticked = true;

				while(Time >= Interval)
				{
					Time -= Interval;
					Tick?.Invoke();
				}
			}
			else
				Ticked = false;
		}
	}
}