using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDC.Feeder
{
    interface IFeeder
    {
        ResultType Save(Common.FileResultBase fileResult);
    }
}
