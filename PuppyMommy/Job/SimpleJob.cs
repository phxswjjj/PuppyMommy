using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
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
            Console.WriteLine("Dog {0} is Running & Watch {1}...", dog.Name, dog.Watch);

            //check dir exists
            var watchDir = new DirectoryInfo(dog.Watch);
            if (!watchDir.Exists)
                throw new DirectoryNotFoundException(dog.Watch);

            //do something
            var waitSecs = new Random().Next(5) + 3;
            System.Threading.Thread.Sleep(waitSecs * 1000);

            foreach(var fileInfo in watchDir.GetFiles())
            {
                SniffFile(fileInfo, dog.Sniffs);
            }

            Console.WriteLine("Dog {0} is Stopped", dog.Name);
            Console.WriteLine();
        }

        void SniffFile(FileInfo fi, IEnumerable<Configuration.SniffSection> sniffs)
        {
            var isFetch = false;
            foreach (var sniff in sniffs)
            {
                var loader = Activator.CreateInstance(Type.GetType(sniff.Loader)) as Loader.ILoader;
                if (loader == null)
                    throw new Exception(string.Format("Sniff.Loader {0} is not implement Loader.ILoader", sniff.Loader));
                
                Common.FileResultBase parseFileContent;
                var parseResult = loader.ParseFile(fi.FullName, out parseFileContent);
                Console.WriteLine("{0} execute result: {1}", loader.GetType(), parseResult);
                if (parseResult == Loader.ResultType.Fetch)
                {
                    isFetch = true;

                    var feeder = Activator.CreateInstance(Type.GetType(sniff.Feeder)) as Feeder.IFeeder;
                    var feedResult = feeder.Save(parseFileContent);
                    //ignore feed result

                    break;
                }
                else if (parseResult == Loader.ResultType.Break)
                    break;
            }
            if (!isFetch)
                Console.WriteLine("No Any Sniff Fetch");
        }
    }
}
