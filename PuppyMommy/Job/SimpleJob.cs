using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDC.Job
{
    public class SimpleJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            
            return null;
        }
    }
}
