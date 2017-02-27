using PayCalculator.core.Model.Salary;
using PayCalculator.core.Model.Tax;
using PayCalculator.Infra.IoC;

namespace PayCalculator.Ext.BusinessObjects.Salary.Australia.DeductionRules
{
    public class BudgetRepairTaxDeductionRule : IDeductionRule
    {
        public string RuleName { get; set; }

        public string GetRuleDescription()
        {
            return "Temporary Budget Repair Levy";
        }

        public decimal Apply(decimal taxableIncome)
        {
            if (taxableIncome <= 0)
            {
                return 0;
            }

            ITaxCalculator calculator = Injector.Instance.Inject<ITaxCalculator>("AustraliaBudgetRepairTaxCalculator");
            return calculator.CalculateTax(taxableIncome);
        }
    }
}
