using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDC.Job
{
    [DisallowConcurrentExecution]
    public class SimpleJob : IJob
    {
        public const string JOBDATAKEY_DOG = "Dog";
        public Task Execute(IJobExecutionContext context)
        {
            var dog = (Configuration.DogSection)context.JobDetail.JobDataMap[JOBDATAKEY_DOG];
            Console.WriteLine($"Dog {dog.Name} is Running...");

            //do something
            var waitSecs = new Random().Next(10) + 10;
            System.Threading.Thread.Sleep(waitSecs * 1000);

            Console.WriteLine($"Dog {dog.Name} is Stopped");
            
            return null;
        }
    }
}
