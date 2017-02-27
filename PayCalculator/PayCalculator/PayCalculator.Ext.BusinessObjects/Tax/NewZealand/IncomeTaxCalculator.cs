using PayCalculator.core.BusinessObjects.Tax;
using PayCalculator.core.Model.Tax;
using System.Collections.Generic;
using System.Linq;

namespace PayCalculator.Ext.BusinessObjects.Tax.NewZealand
{
    public class IncomeTaxCalculator : ITaxCalculator
    {
        private List<ITaxBracket> _taxBrackets;

        public IncomeTaxCalculator()
        {
            _taxBrackets = new List<ITaxBracket>();

            // take calculator bracets from DB
            // string bracketsDescription = DB.GetBracketsDescription("DefaultBrackets"); 
            // InitBracets(bracketsDescription); 

            InitBracets("NewZealandIncomeTaxBrackets");
        }

        public decimal CalculateTax(decimal taxableIncome)
        {
            return _taxBrackets
                        .Where(bracket => bracket.CanApplyBracket(taxableIncome))
                        .Sum(validBracket => validBracket.CalculateTaxBracket(taxableIncome)); 
        }

        private void InitBracets(string description)
        {
            // TODO: bracets should be taken from DB, using description
            //_taxBracets = DB.GetTaxBracets(description);

            // TODO: adding the tax bracets - should be done via microservice 
            _taxBrackets.Add(new DefaultTaxBracket(0, 14000, (decimal)0.105));
            _taxBrackets.Add(new DefaultTaxBracket(14001, 48000, (decimal)0.175));
            _taxBrackets.Add(new DefaultTaxBracket(48001, 70000, (decimal)0.30));
            _taxBrackets.Add(new DefaultTaxBracket(70001, decimal.MaxValue, (decimal)0.33));
        }
    }
}