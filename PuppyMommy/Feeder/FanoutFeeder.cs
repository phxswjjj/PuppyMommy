using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDC.Common;

namespace EDC.Feeder
{
    public class FanoutFeeder : IFeeder
    {
        public ResultType Save(FileResultBase fileResult)
        {
            var result = ResultType.None;

            //overload
            Console.WriteLine("FanoutFeeder save...");

            if (result == ResultType.None)
                result = Save(fileResult as SimpleFileResult);
            if (result == ResultType.None)
                result = Save(fileResult as NikonFileResult);

            if(result == ResultType.None)
                throw new Exception(string.Format("file result {0} is invalid", fileResult.GetType()));
            
            return result;
        }
        private ResultType Save(NikonFileResult nikonFileResult)
        {
            if (nikonFileResult == null)
                return ResultType.None;

            //save content...

            return ResultType.Success;
        }
        private ResultType Save(SimpleFileResult simpleFileResult)
        {
            if (simpleFileResult == null)
                return ResultType.None;

            //save content...

            return ResultType.Success;
        }
    }
}
