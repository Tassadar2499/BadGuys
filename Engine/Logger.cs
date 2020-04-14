using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGuys.Engine
{
	public static class Logger
	{
		private static readonly StringBuilder LogContent = new StringBuilder();
		public static void Log(string str)
		{
			var strOut = DateTime.UtcNow.ToString("hh:mm:ss.ffff") + " : " + str;
			Console.WriteLine(strOut);
			LogContent.Append($"{strOut}\r\n");
		}

		public static async void FlushContentAsync()
		{

			await new Task(() => FlushContent()).ConfigureAwait(true);
		}

		public static void FlushContent()
		{
			Directory.CreateDirectory("Log");
			var dateStr = DateTime.Now.ToString("dd-MM-yy_hh-mm-ss");
			var filePath = $"Log/{dateStr}_Log.txt";

			using var sw = new StreamWriter(filePath, false);
			sw.WriteLine(LogContent.ToString());
		}
	}
}
