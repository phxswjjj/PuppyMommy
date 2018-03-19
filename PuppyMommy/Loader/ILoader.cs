using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDC.Loader
{
    interface ILoader
    {
        ResultType ParseFile(string filePath, out Common.FileResultBase fileResult);
    }
}
