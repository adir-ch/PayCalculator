using PayCalculator.Contracts.Common;

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
