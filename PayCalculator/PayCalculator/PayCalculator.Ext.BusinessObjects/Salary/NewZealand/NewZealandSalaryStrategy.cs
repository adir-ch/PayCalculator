using PayCalculator.core.Model.Salary;
using PayCalculator.Ext.Model.Salary;
using cbc = PayCalculator.core.BusinessObjects.Salary;

namespace PayCalculator.Ext.BusinessObjects.Salary.NewZealand
{
    public class NewZealandSalaryStrategy : ISalaryStrategy
    {
        private IDeductions _deductions;

        public NewZealandSalaryStrategy(INewZealandSalaryDeductions deductions)
        {
            _deductions = deductions;
        }

        public decimal GrossSalary { get; set; }

        public ISalary Execute()
        {
            var taxableIncome = GrossSalary;
            var netAnnualSalary = taxableIncome - _deductions.GetTotalDeductionsAmount(taxableIncome);
            return BuildSalaryReport(taxableIncome, netAnnualSalary);
        }

        private ISalary BuildSalaryReport(decimal taxableIncome, decimal netAnnualSalary)
        {
            cbc.Salary salary = new cbc.Salary();
            salary.GrossSalary = GrossSalary;
            salary.TaxableIncome = taxableIncome;
            salary.NetAnnualSalary = netAnnualSalary;
            salary.Deductions = _deductions.GetDeductionsReport();
            return salary;
        }
    }
}
