using PayCalculator.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Contracts.Common
{
    public class ServiceErrorResponse : ServiceResponseBase
    {
        public int ErrorCode { get; set; }
        public string DetailedException { get; set; }
        
        public ServiceErrorResponse()
        {
        }

        public override string DumpResponseBody()
        {
            return String.Format(" ErrorCode {0}, Exception {1}", ErrorCode, DetailedException);
        }
    }
}
