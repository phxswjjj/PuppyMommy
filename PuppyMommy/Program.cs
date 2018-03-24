using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDC
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Execute();
            }
            catch (Exception)
            {

                throw;
            }
        }

        static async void Execute()
        {
            var tasks = new List<Task>();

            var scheduleTask = Quartz.Impl.StdSchedulerFactory.GetDefaultScheduler();
            var scheduler = scheduleTask.Result;

            var config = (Configuration.DomainConfig)ConfigurationManager.GetSection("DomainConfig");
            var dogs = config.Dogs;
            foreach (Configuration.DogSection dog in dogs)
            {
                Console.WriteLine($"Name={dog.Name}, Watch={dog.Watch}, CronScheduler={dog.CronScheduler}");
                foreach (var sniff in dog.Sniffs)
                {
                    Console.WriteLine($"Loader={sniff.Loader}, Feeder={sniff.Feeder}");
                }
                Console.WriteLine();

                var job = JobBuilder.Create<Job.SimpleJob>()
                    .WithIdentity(dog.Watch, "Mommy")
                    .RequestRecovery()
                    .SetJobData(new JobDataMap { { Job.SimpleJob.JOBDATAKEY_DOG, dog } })
                    .Build();

                var jobTrigger = TriggerBuilder.Create()
                    .WithCronSchedule(dog.CronScheduler)
                    .StartNow()
                    .Build();

                tasks.Add(scheduler.ScheduleJob(job, jobTrigger));
            }

            Task.WaitAll(tasks.ToArray());
            tasks.RemoveAll(t => t.IsCompleted);
            if (tasks.Count > 0)
                throw new Exception("Task is Alive");

            await scheduler.Start();
            Console.ReadLine();

            Console.WriteLine("Scheduler Stopping...");
            await scheduler.PauseAll();
            while ((await scheduler.GetCurrentlyExecutingJobs()).Count > 0)
            {
                Console.WriteLine("Wait Paused...");
                System.Threading.Thread.Sleep(1000);
            }
            
            Console.WriteLine("Press Enter Exit");
            Console.ReadLine();
        }
    }
}
