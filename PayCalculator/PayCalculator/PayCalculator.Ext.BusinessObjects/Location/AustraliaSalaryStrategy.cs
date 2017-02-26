using PayCalculator.core.Model.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayCalculator.Ext.BusinessObjects.Location
{
    public class AustraliaSalaryStrategy : ISalaryStrategy
    {
        public decimal GrossSalary { get; set; }
        private IDeductions _deductions;

        public AustraliaSalaryStrategy()
        {

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
            throw new NotImplementedException();
        }

        private decimal CalculateSuperannuation()
        {
            return (GrossSalary * (decimal)0.086758); // take this value from DB
        }
    }
}
