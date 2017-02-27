using PayCalculator.Contracts.Common;
using System;

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
