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
            throw new NotImplementedException();
        }
    }
}
