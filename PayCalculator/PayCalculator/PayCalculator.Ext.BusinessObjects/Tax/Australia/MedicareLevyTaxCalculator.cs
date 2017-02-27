using log4net;
using PayCalculator.core.BusinessObjects.Tax;
using PayCalculator.core.Model.Tax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Tax.Australia
{
    public class MedicareLevyTaxCalculator : ITaxCalculator
    {
        protected readonly ILog _log = LogManager.GetLogger("AU Income tax calc");
        private List<ITaxBracket> _taxBrackets;

        public MedicareLevyTaxCalculator()
        {
            _taxBrackets = new List<ITaxBracket>();
            InitBracets("AustraliaMedicareBracets"); 
        }

        public decimal CalculateTax(decimal taxableIncome)
        {
            decimal totalCalculatedMedicareLevy = _taxBrackets
                 .Where(bracket => bracket.CanApplyBracket(taxableIncome))
                 .Sum(validBracket => validBracket.CalculateTaxBracket(taxableIncome));

            var roundedTotalCalculatedMedicareLevy = Math.Round(totalCalculatedMedicareLevy, MidpointRounding.AwayFromZero);
            _log.DebugFormat("Calculated total Medicare Levy: {0}", roundedTotalCalculatedMedicareLevy);
            return roundedTotalCalculatedMedicareLevy; 
        }

        private void InitBracets(string description)
        {
            // TODO: Bracets should be taken from DB
            _taxBrackets.Add(new DefaultTaxBracket(0, 21335, 0));
            _taxBrackets.Add(new DefaultTaxBracket(21336, 26668, (decimal)0.1));
            _taxBrackets.Add(new DefaultTaxBracket(26669, decimal.MaxValue, (decimal)0.02));
        }
    }
}