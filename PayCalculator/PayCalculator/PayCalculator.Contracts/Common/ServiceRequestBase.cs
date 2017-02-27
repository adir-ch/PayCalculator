using System;

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
