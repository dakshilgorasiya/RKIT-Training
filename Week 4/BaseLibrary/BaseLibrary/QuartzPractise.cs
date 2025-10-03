using Quartz;
using Quartz.Impl;

namespace BaseLibrary
{
    public class SimpleJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync("Hello, Quartz.NET! " + DateTime.Now);
        }
    }
    internal class QuartzPractise
    {
        static async Task Main(string[] args)
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = await schedulerFactory.GetScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<SimpleJob>()
                .WithIdentity("myJob", "group1")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(1)
                    .RepeatForever())
                .Build();

            ITrigger trigger1 = TriggerBuilder.Create()
                .WithIdentity("myTrigger1", "group1")
                .WithSchedule(CronScheduleBuilder
                    .AtHourAndMinuteOnGivenDaysOfWeek(12, 0, DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday))
                .Build();

            await scheduler.ScheduleJob(job, trigger);

            Console.WriteLine("Scheduler started. Press any key to exit...");
            Console.ReadKey();

            await scheduler.Shutdown();
        }
    }
}
