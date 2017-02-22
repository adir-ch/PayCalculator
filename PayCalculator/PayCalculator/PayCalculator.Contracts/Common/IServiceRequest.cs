using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayCalculator.Contracts.Common
{
    public interface IServiceRequest
    {
        string ServiceName { get; set; }
        string RequestId { get; set; }
    }
}
