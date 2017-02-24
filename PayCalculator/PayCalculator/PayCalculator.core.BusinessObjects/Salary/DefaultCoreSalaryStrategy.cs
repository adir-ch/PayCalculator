using PayCalculator.core.Model.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.BusinessObjects.Salary
{
    public class DefaultCoreSalaryStrategy : ISalaryStrategy
    {
        public decimal GrossSalary { get; set; }
        private IDeductions _deductions;
        private ISalary _salary;

        public DefaultCoreSalaryStrategy(IDeductions deductions)
        {
            _deductions = deductions; 
        }

        public ISalary Execute()
        {
            _salary = new Salary();
            _salary.GrossSalary = GrossSalary;
            _salary.TaxableIncome = GrossSalary;
            _salary.NetAnnualSalary = GrossSalary - _deductions.GetTotalDeductionsAmount(_salary.TaxableIncome);

            if (_salary.NetAnnualSalary < 0)
                _salary.NetAnnualSalary = 0;

            _salary.Deductions = _deductions.GetDeductionsReport();
            return _salary; 
        }
    }
}
