using PayCalculator.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Contracts.Employee
{
    public class EmployeeCalculateSalaryServiceRequest : ServiceRequestBase
    {
        public string EmployeeName { get; set; }

        public EmployeeCalculateSalaryServiceRequest()
        {
            ServiceName = "EmployeeCalculateSalaryService";
        }
    }
}
