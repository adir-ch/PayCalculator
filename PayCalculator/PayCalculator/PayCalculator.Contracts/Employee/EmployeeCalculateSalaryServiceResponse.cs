using PayCalculator.Contracts.Common;

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

