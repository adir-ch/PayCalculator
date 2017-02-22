using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Contracts.Common
{
    public abstract class ServiceRequestBase : IServiceRequest
    {
        public string ServiceName { get; set; }
        public string RequestId { get; set; }

        public ServiceRequestBase()
        {
            RequestId = Guid.NewGuid().ToString(); 
        }
    }
}
