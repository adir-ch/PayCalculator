using PayCalculator.core.Model.Salary;
using PayCalculator.Ext.Model.Salary;
using System;
using cbc = PayCalculator.core.BusinessObjects.Salary;

namespace PayCalculator.Ext.BusinessObjects.Salary.Australia
{
    public class AustraliaSalaryStrategy : ISalaryStrategy
    {
        public decimal GrossSalary { get; set; }
        private IAustraliaSalaryDeductions _deductions;

        public AustraliaSalaryStrategy(IAustraliaSalaryDeductions deductions)
        {
            _deductions = deductions; 
        }

        public ISalary Execute()
        {
            var superannuation = CalculateSuperannuation();
            var taxableIncome = (GrossSalary - superannuation);
            var netAnnualSalary = taxableIncome - _deductions.GetTotalDeductionsAmount(taxableIncome);
            return BuildSalaryReport(superannuation, taxableIncome, netAnnualSalary);
        }

        private ISalary BuildSalaryReport(decimal superannuation, decimal taxableIncome, decimal netAnnualSalary)
        {
            cbc.Salary salary = new cbc.Salary();
            salary.GrossSalary = GrossSalary;
            salary.TaxableIncome = taxableIncome;
            salary.NetAnnualSalary = netAnnualSalary;
            salary.Deductions = _deductions.GetDeductionsReport();

            // Adding Superannuation to the report, since the requierments states that the deductions report
            // should contain the super entry, but the code is using the deduction report to calculate the amount 
            // needed for net annual - adding the super after the report was used. 
            salary.Deductions.Insert(0, Tuple.Create<string, decimal>("Superannuation", superannuation));
            return salary; 
        }

        private decimal CalculateSuperannuation()
        {
            return (GrossSalary * (decimal)0.086758); // take this value from DB
        }
    }
}
