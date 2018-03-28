using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDC.Common;

namespace EDC.Feeder
{
    public class SimpleFeeder : IFeeder
    {
        public ResultType Save(FileResultBase fileResult)
        {
            var simpleFileResult = fileResult as Common.SimpleFileResult;
            if (simpleFileResult == null)
                throw new Exception(string.Format("file result {0} is not SimpleFileResult", fileResult.GetType()));
            //save content...
            Console.WriteLine("SimpleFeeder save...");

            return ResultType.Success;
        }
    }
}
