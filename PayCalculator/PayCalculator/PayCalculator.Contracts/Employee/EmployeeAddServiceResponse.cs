using PayCalculator.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Contracts.Employee
{
    public class EmployeeAddServiceResponse : ServiceResponseBase
    {
        public EmployeeAddServiceResponse()
        {
        }

        public override string DumpResponseBody()
        {
            return String.Empty; // nothing else is needed
        }
    }
}
