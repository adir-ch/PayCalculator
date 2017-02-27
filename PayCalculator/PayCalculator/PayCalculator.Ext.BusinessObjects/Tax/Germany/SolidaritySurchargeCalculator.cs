using PayCalculator.core.Model.Tax;

namespace PayCalculator.Ext.BusinessObjects.Tax.Germany
{
    class SolidaritySurchargeCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal taxableIncome)
        {
            return (taxableIncome * (decimal)0.0055);
        }
    }
}
