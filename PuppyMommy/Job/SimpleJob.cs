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

            //sniff
            foreach(var sniff in dog.Sniffs)
            {
                Console.WriteLine("{0} do {1}", dog.Name, sniff.Loader);

                var loader = Activator.CreateInstance(Type.GetType(sniff.Loader)) as Loader.ILoader;
                if (loader == null)
                    throw new Exception(string.Format("Dog {0} Sniff.Loader {1} is not implement Loader.ILoader", dog.Name, sniff.Loader));
            }

            Console.WriteLine("Dog {0} is Stopped", dog.Name);
        }
    }
}
