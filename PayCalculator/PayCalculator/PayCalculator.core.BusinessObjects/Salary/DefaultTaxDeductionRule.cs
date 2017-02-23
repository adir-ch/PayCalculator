using PayCalculator.core.Model.Salary;
using PayCalculator.core.Model.Tax;
using PayCalculator.Infra.IoC;
using System;

namespace PayCalculator.core.BusinessObjects.Salary
{
    public class DefaultTaxDeductionRule : IDeductionRule
    {
        private ITaxCalculator _taxCalculator; 
        public string RuleName { get; set; }

        public DefaultTaxDeductionRule(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator; 
        }

        public string GetRuleDescription()
        {
            return "Default Core Tax rule"; 
        }

        public decimal Apply(decimal taxableIncome)
        {
            return _taxCalculator.CalculateTax(taxableIncome); 
        }
    }
}
