using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDC.Common;

namespace EDC.Loader
{
    public class SimpleLoader : LoaderBase, ILoader
    {
        public ResultType ParseFile(string filePath, out FileResultBase fileResult)
        {
            Console.WriteLine("SimpleLoader Parse File {0}...", filePath);
            System.Threading.Thread.Sleep(3000);

            //parse file content to file result
            var fileResultDetail = new SimpleFileResult();

            fileResult = fileResultDetail;

            if (new Random().Next(100) % 50 == 0)
                return ResultType.Fetch;
            else
                return ResultType.Skip;
        }
    }
}
