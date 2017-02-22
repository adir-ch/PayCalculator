using PayCalculator.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Contracts.Employee
{
    public class EmployeeCalculateSalaryServiceResponse : ServiceResponseBase
    {
        public decimal NetAnnualSalary { get; set; }

        public override string DumpResponseBody()
        {
            return NetAnnualSalary.ToString(); 
        }
    }
}

