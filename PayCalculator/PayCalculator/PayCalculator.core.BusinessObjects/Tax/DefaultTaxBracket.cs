using PayCalculator.core.Model.Tax;

namespace PayCalculator.core.BusinessObjects.Tax
{
    public class DefaultTaxBracket : ITaxBracket
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

        public decimal CalculateTaxBracket(decimal taxableIncome)
        {
            if (taxableIncome < _lowerBand)
                return 0;

            if (taxableIncome > _upperBand)
                return ((_upperBand - _lowerBand) * _taxRate);

            if (_lowerBand == 0)
                return ((taxableIncome - _lowerBand) * _taxRate); 

            return ((taxableIncome - _lowerBand + 1) * _taxRate); 
        }

        public bool CanApplyBracket(decimal taxableIncome)
        {
            return (taxableIncome >= _lowerBand);
        }

        public bool IsInBracket(decimal taxableIncome)
        {
            return (taxableIncome >= _lowerBand && taxableIncome <= _upperBand); 
        }
    }
}
