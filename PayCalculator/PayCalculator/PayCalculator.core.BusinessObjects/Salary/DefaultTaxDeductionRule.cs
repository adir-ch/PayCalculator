using PayCalculator.core.Model.Salary;
using PayCalculator.core.Model.Tax;
using PayCalculator.Infra.IoC;
using System;

namespace PayCalculator.core.BusinessComponents.Salary
{
    public class DefaultTaxDeductionRule : IDeductionRule
    {
        public string RuleName { get; set; }

        public string GetRuleDescription()
        {
            return "Default Core Tax rule"; 
        }

        public decimal Apply(decimal taxableIncome)
        {
            ITaxCalculator calculator = Injector.Instance.Inject<ITaxCalculator>("DefaultTaxCalculator");
            return calculator.CalculateTax(taxableIncome); 
        }
    }
}
