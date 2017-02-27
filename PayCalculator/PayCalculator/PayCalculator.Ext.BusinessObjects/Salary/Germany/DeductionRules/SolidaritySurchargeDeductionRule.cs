using PayCalculator.core.Model.Salary;
using PayCalculator.core.Model.Tax;
using PayCalculator.Infra.IoC;

namespace PayCalculator.Ext.BusinessObjects.Salary.Germany.DeductionRules
{
    public class SolidaritySurchargeDeductionRule : IDeductionRule
    {
        public string RuleName { get; set; }

        public string GetRuleDescription()
        {
            return "Solidarity and surcharge"; // take from DB or config
        }

        public decimal Apply(decimal taxableIncome)
        {
            if (taxableIncome <= 0)
            {
                return 0;
            }
            ITaxCalculator calculator = Injector.Instance.Inject<ITaxCalculator>("GermanySolidaritySurchargeCalculator");
            return calculator.CalculateTax(taxableIncome);
        }
    }
}
