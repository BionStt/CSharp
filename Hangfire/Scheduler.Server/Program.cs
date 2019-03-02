using System;
using Hangfire;
using Hangfire.Logging;
using Hangfire.Logging.LogProviders;
using Hangfire.SqlServer;

namespace Scheduler.Server
{
	internal class Program
	{
		private static void ConfigureHangfireServer()
		{
			Console.WriteLine("== SERVER START ==");

			LogProvider.SetCurrentLogProvider(new ColouredConsoleLogProvider());

			var options = new SqlServerStorageOptions
			{
				PrepareSchemaIfNecessary = true
			};

			GlobalConfiguration.Configuration
				.UseSqlServerStorage("Scheduler", options)
				.UseColouredConsoleLogProvider();

			GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 0 });

			using (var server = new BackgroundJobServer())
			{
				Console.WriteLine("== SERVER STARTED ==");
				Console.ReadKey();
			}
		}

		private static void Main(string[] args)
		{
			ConfigureHangfireServer();
		}
	}
}