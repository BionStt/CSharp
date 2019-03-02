using System;
using Quartz;

namespace Examples
{
	public class Program
	{
		private static void Main(string[] args)
		{
			var dateTimeJobTrigger = TriggerBuilder
				.Create()
				.StartNow()
				.WithSimpleSchedule(x => x.WithIntervalInSeconds(2).RepeatForever())
				.Build();

			new Scheduler().ScheduleJob<DateTimeJob>(dateTimeJobTrigger).GetAwaiter().GetResult();

			Console.ReadKey();
		}
	}
}