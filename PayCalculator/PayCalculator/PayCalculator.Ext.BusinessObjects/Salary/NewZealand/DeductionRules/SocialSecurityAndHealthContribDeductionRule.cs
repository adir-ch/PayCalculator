using PayCalculator.core.Model.Salary;
using PayCalculator.core.Model.Tax;
using PayCalculator.Infra.IoC;

namespace PayCalculator.Ext.BusinessObjects.Salary.NewZealand.DeductionRules
{
    public class SocialSecurityAndHealthContribDeductionRule : IDeductionRule
    {
        public string RuleName { get; set; }

        public string GetRuleDescription()
        {
            return "Social security and Health contribution"; // take from DB or config
        }

        public decimal Apply(decimal taxableIncome)
        {
            if (taxableIncome <= 0)
            {
                return 0;
            }
            ITaxCalculator calculator = Injector.Instance.Inject<ITaxCalculator>("NewZealandSocialSecurityAndHealthContribTaxCalculator");
            return calculator.CalculateTax(taxableIncome);
        }
    }
}
