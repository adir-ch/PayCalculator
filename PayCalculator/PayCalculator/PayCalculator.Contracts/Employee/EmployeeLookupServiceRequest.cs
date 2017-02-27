using PayCalculator.Contracts.Common;

namespace PayCalculator.Contracts.Employee
{
    public class EmployeeLookupServiceRequest : ServiceRequestBase
    {
        public string EmployeeName;

        public EmployeeLookupServiceRequest()
        {
            ServiceName = "EmployeeLookupService"; 
        }
    }
}
