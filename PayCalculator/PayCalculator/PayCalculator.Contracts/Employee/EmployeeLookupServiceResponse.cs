using PayCalculator.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Contracts.Employee
{
    public class EmployeeLookupServiceResponse : ServiceResponseBase
    {
        public string EmployeeName { get; set; }
        public string Location { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal TaxableIncome { get; set; }
        public decimal NetAnnualSalary { get; set; }
        public IList<Tuple<string, decimal>> Deductions { get; set; }

        public EmployeeLookupServiceResponse()
        {
            GrossSalary = 0;
            TaxableIncome = 0;
            NetAnnualSalary = 0;
            Deductions = null; 
        }

        public override string DumpResponseBody()
        {
            StringBuilder output = new StringBuilder();
            output.Append(String.Format("Name: {0}{1}", EmployeeName, System.Environment.NewLine));
            output.Append(String.Format("Employee location: {0}{1}", Location, System.Environment.NewLine));
            output.Append(String.Format("Gross Salary: {0}{1}", GrossSalary, System.Environment.NewLine));
            output.Append(System.Environment.NewLine);
            output.Append(String.Format("Taxable Income: {0}{1}", TaxableIncome, System.Environment.NewLine));
            output.Append(System.Environment.NewLine);
            output.Append(String.Format("Net annual salary: {0}{1}", NetAnnualSalary, System.Environment.NewLine));
            return output.ToString();
        }
    }
}
