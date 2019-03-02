using System;
using System.IO;

namespace Scheduler.Jobs
{
	public static class Job
	{
		private const string dateTimeFormat = "dd/MM/yyyy HH:mm:ss";

		public static void WriteConsole()
		{
			Console.WriteLine(DateTime.Now.ToString(dateTimeFormat));
		}

		public static void WriteFile()
		{
			using (var sw = File.AppendText(@"C:\FILE.txt"))
			{
				sw.WriteLine(DateTime.Now.ToString(dateTimeFormat));
			}
		}
	}
}