using PayCalculator.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Contracts.Employee
{
    public class EmployeeAddServiceRequest : ServiceRequestBase
    {
        public string EmployeeName;
        public string EmployeeLocation;
        public string GrossSalary;

        public EmployeeAddServiceRequest()
        {
            ServiceName = "EmployeeAddService";
        }
    }
}
