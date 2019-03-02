using System;
using System.Threading;
using Hangfire;
using Scheduler.Jobs;

namespace Scheduler.Client
{
	internal class Program
	{
		public static void ConfigureHangfireClient()
		{
			Thread.Sleep(10000);

			Console.WriteLine("== CLIENT START ==");

			GlobalConfiguration.Configuration.UseSqlServerStorage("Scheduler");

			var client = new BackgroundJobClient();

			Console.WriteLine("== CLIENT STARTED ==");

			RecurringJob.AddOrUpdate(() => Job.WriteConsole(), Cron.Minutely());

			Console.WriteLine("== WRITE CONSOLE STARTED ==");

			RecurringJob.AddOrUpdate(() => Job.WriteFile(), Cron.Minutely());

			Console.WriteLine("== WRITE FILE STARTED ==");

			Console.ReadKey();
		}

		public static void Main(string[] args)
		{
			ConfigureHangfireClient();
		}
	}
}