using System;
using System.Threading.Tasks;
using Quartz;

namespace Examples
{
    public class DateTimeJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            return Task.FromResult(0);
        }
    }
}