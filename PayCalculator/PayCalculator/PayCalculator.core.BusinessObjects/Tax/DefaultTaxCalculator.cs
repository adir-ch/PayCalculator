using PayCalculator.core.Model.Tax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayCalculator.core.BusinessComponents.Tax
{
    public class DefaultTaxCalculator : ITaxCalculator
    {
        private List<ITaxBracket> _taxBracets;

        public DefaultTaxCalculator()
        {
            _taxBracets = new List<ITaxBracket>();

            // take calculator bracets from DB
            // string bracketsDescription = DB.GetBracketsDescription("DefaultBrackets"); 
            // InitBracets(bracketsDescription); 

            InitBracets("DefaultBrackets");
        }

        public decimal CalculateTax(decimal taxableIncome)
        {
            return _taxBracets.Sum(b => Math.Round(b.CalculateTaxBracket(taxableIncome)));
        }

        private void InitBracets(string description)
        {
            // TODO: bracets should be taken from DB, using description
            //_taxBracets = DB.GetTaxBracets(description);
            _taxBracets.Add(new DefaultTaxBracket(0, 18200, 0));
            _taxBracets.Add(new DefaultTaxBracket(18201, 37000, (decimal)0.19));
            _taxBracets.Add(new DefaultTaxBracket(37001, 87000, (decimal)0.325));
            _taxBracets.Add(new DefaultTaxBracket(87001, 180000, (decimal)0.37));
            _taxBracets.Add(new DefaultTaxBracket(180001, decimal.MaxValue, (decimal)0.45));
        }
    }
}
