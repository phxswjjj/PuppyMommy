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

        static void Execute()
        {
            var tasks = new List<Task>();

            var scheduler = Quartz.Impl.StdSchedulerFactory.GetDefaultScheduler();
            
            var config = (Configuration.DomainConfig)ConfigurationManager.GetSection("DomainConfig");
            var dogs = config.Dogs;
            foreach (Configuration.DogSection dog in dogs)
            {
                Console.WriteLine("Name={0}, Watch={1}, CronScheduler={2}", dog.Name, dog.Watch, dog.CronScheduler);
                foreach (var sniff in dog.Sniffs)
                {
                    Console.WriteLine("Loader={0}, Feeder={1}", sniff.Loader, sniff.Feeder);
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

                scheduler.ScheduleJob(job, jobTrigger);
            }

            Task.WaitAll(tasks.ToArray());
            tasks.RemoveAll(t => t.IsCompleted);
            if (tasks.Count > 0)
                throw new Exception("Task is Alive");

            scheduler.Start();
            Console.ReadLine();

            Console.WriteLine("Scheduler Stopping...");
            scheduler.PauseAll();

            //not require
            while (scheduler.GetCurrentlyExecutingJobs().Count > 0)
            {
                Console.WriteLine("Wait...");
                System.Threading.Thread.Sleep(1000);
            }

            //require
            scheduler.Shutdown(true);
            
            Console.WriteLine("Press Enter Exit");
            Console.ReadLine();
        }
    }
}
