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
        public void Execute(IJobExecutionContext context)
        {
            var dog = (Configuration.DogSection)context.JobDetail.JobDataMap[JOBDATAKEY_DOG];
            Console.WriteLine("Dog {0} is Running...", dog.Name);

            //do something
            var waitSecs = new Random().Next(5) + 3;
            System.Threading.Thread.Sleep(waitSecs * 1000);

            Console.WriteLine("Dog {0} is Stopped", dog.Name);
        }
    }
}
