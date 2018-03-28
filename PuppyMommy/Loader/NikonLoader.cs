using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDC.Common;

namespace EDC.Loader
{
    public class NikonLoader : LoaderBase, ILoader
    {
        public ResultType ParseFile(string filePath, out FileResultBase fileResult)
        {
            Console.WriteLine("NikonLoader Parse File {0}...", filePath);
            System.Threading.Thread.Sleep(2000);

            //parse file content to file result
            var fileResultDetail = new NikonFileResult();

            fileResult = fileResultDetail;

            if (new Random().Next(100) % 2 == 0)
                return ResultType.Fetch;
            else
                return ResultType.Skip;
        }
    }
}
