using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDC.Common;

namespace EDC.Feeder
{
    public class NikonFeeder : IFeeder
    {
        public ResultType Save(FileResultBase fileResult)
        {
            var nikonFileResult = fileResult as Common.NikonFileResult;
            if (nikonFileResult == null)
                throw new Exception(string.Format("file result {0} is not NikonFileResult", fileResult.GetType()));
            //save content...
            Console.WriteLine("NikonFeeder save...");

            return ResultType.Success;
        }
    }
}
