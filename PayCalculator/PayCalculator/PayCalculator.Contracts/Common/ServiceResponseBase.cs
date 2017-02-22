using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Contracts.Common
{
    public abstract class ServiceResponseBase : IServiceResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string RequestId { get; set; }
        public string ServiceName { get; set; }

        public ServiceResponseBase()
        {
        }

        public abstract string DumpResponseBody();

        public string DumpResponseHeader()
        {
            return String.Format("Service Response header - RequestId: {0}, ServiceName: {1}, Status: {2} [{3}]",
                RequestId,
                ServiceName,
                (Status == true ? "Success" : "Fail"),
                Message);
        }

        
    }
}
