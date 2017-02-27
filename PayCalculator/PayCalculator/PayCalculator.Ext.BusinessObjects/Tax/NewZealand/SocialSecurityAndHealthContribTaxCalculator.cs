using PayCalculator.core.Model.Tax;
using System;

namespace PayCalculator.Ext.BusinessObjects.Tax.NewZealand
{
    public class SocialSecurityAndHealthContribTaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal taxableIncome)
        {
            return Math.Min(118191, (taxableIncome * (decimal)0.00145));
        }
    }
}
