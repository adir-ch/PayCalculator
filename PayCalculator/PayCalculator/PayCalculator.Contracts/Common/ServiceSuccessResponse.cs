using PayCalculator.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Common
{
    public class ServiceSuccessResponse : ServiceResponseBase
    {
        public override string DumpResponseBody()
        {
            return "Service finished successfully";
        }
    }
}
