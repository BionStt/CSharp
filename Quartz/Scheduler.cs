using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace Examples
{
    public class Scheduler
    {
        private readonly IScheduler _scheduler;

        private readonly StdSchedulerFactory _schedulerFactory = new StdSchedulerFactory();

        public Scheduler()
        {
            _scheduler = _schedulerFactory.GetScheduler().Result;
            _scheduler.Start().Wait();
        }

        public async Task ScheduleJob<TJob>(ITrigger trigger) where TJob : IJob
        {
            await _scheduler.ScheduleJob(CreateJob<TJob>(), trigger);
        }

        private IJobDetail CreateJob<TJob>() where TJob : IJob
        {
            return JobBuilder.Create<TJob>().WithIdentity(JobKey.Create(nameof(TJob))).Build();
        }
    }
}