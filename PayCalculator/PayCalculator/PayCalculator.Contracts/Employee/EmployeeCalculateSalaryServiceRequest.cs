using PayCalculator.Contracts.Common;

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
