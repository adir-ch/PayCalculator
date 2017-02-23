using PayCalculator.core.Model.Tax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayCalculator.core.BusinessObjects.Tax
{
    public class DefaultTaxCalculator : ITaxCalculator
    {
        private List<ITaxBracket> _taxBrackets;

        public DefaultTaxCalculator()
        {
            _taxBrackets = new List<ITaxBracket>();

            // take calculator brackets from DB
            // string bracketsDescription = DB.GetBracketsDescription("DefaultBrackets"); 
            // InitBrackets(bracketsDescription); 

            InitBrackets("DefaultBrackets");
        }

        public decimal CalculateTax(decimal taxableIncome)
        {
            return _taxBrackets.Sum(b => Math.Round(b.CalculateTaxBracket(taxableIncome)));
        }

        private void InitBrackets(string description)
        {
            // TODO: brackets should be taken from DB, using description
            //_taxBrackets = DB.GetTaxBracets(description);
            _taxBrackets.Add(new DefaultTaxBracket(0, 18200, 0));
            _taxBrackets.Add(new DefaultTaxBracket(18201, 37000, (decimal)0.19));
            _taxBrackets.Add(new DefaultTaxBracket(37001, 87000, (decimal)0.325));
            _taxBrackets.Add(new DefaultTaxBracket(87001, 180000, (decimal)0.37));
            _taxBrackets.Add(new DefaultTaxBracket(180001, decimal.MaxValue, (decimal)0.45));
        }
    }
}
