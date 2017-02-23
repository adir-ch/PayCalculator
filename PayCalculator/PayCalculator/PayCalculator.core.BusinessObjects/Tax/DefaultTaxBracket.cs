using PayCalculator.core.Model.Tax;

namespace PayCalculator.core.BusinessComponents.Tax
{
    public class DefaultTaxBracket : ITaxBracet
    {
        private readonly decimal _lowerBand;
        private readonly decimal _upperBand;
        private readonly decimal _taxRate;

        public DefaultTaxBracket(decimal lowerBand, decimal upperBand, decimal taxRate)
        {
            _lowerBand = lowerBand;
            _upperBand = upperBand;
            _taxRate = taxRate;
        }

        public decimal CalculateTaxBracet(decimal taxableIncome)
        {
            return 0;
        }

        public bool CanApplyBracet(decimal taxableIncome)
        {
            return false; 
        }

        public bool IsInBracket(decimal taxableIncome)
        {
            return false; 
        }
    }
}
