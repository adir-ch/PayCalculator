using PayCalculator.core.Model.Salary;
using PayCalculator.core.Model.Tax;
using PayCalculator.Infra.IoC;

namespace PayCalculator.Ext.BusinessObjects.Salary.Germany.DeductionRules
{
    public class IncomeTaxDeductionRule : IDeductionRule
    {
        public string RuleName { get; set; }

        public string GetRuleDescription()
        {
            return "Income Tax"; // take from DB or config
        }

        public decimal Apply(decimal taxableIncome)
        {
            if (taxableIncome <= 0)
            {
                return 0;
            }
            ITaxCalculator calculator = Injector.Instance.Inject<ITaxCalculator>("GermanyIncomeTaxCalculator");
            return calculator.CalculateTax(taxableIncome);
        }
    }
}
