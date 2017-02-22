using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Contracts.Common
{
    public interface IServiceResponse
    {
        string RequestId { get; set; }
        bool Status { get; set; }
        string Message { get; set; }

        string DumpResponseHeader();
        string DumpResponseBody();
    }
}
