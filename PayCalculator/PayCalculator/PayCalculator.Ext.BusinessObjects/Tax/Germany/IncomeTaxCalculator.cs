using PayCalculator.core.BusinessObjects.Tax;
using PayCalculator.core.Model.Tax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Tax.Germany
{
    public class IncomeTaxCalculator : ITaxCalculator
    {
        private List<ITaxBracket> _taxBracets;

        public IncomeTaxCalculator()
        {
            _taxBracets = new List<ITaxBracket>();

            // take calculator bracets from DB
            // string bracketsDescription = DB.GetBracketsDescription("DefaultBrackets"); 
            // InitBracets(bracketsDescription); 

            InitBracets("GermanyIncomeTaxBrackets");
        }

        public decimal CalculateTax(decimal taxableIncome)
        {
            return _taxBracets.Where(b => b.IsInBracket(taxableIncome))
                              .Select(b => b.CalculateTaxBracket(taxableIncome))
                              .FirstOrDefault();
        }

        private void InitBracets(string description)
        {
            // TODO: bracets should be taken from DB, using description
            //_taxBracets = DB.GetTaxBracets(description);

            _taxBracets.Add(new DefaultTaxBracket(0, 7664, 0));
            _taxBracets.Add(new DefaultTaxBracket(7664, 52153, (decimal)0.15));
            _taxBracets.Add(new DefaultTaxBracket(7664, 250000, (decimal)0.42));
            _taxBracets.Add(new DefaultTaxBracket(250001, decimal.MaxValue, (decimal)0.45));
        }
    }
}