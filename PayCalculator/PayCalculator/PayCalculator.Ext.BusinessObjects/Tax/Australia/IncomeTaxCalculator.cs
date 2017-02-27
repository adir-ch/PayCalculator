using log4net;
using PayCalculator.core.Model.Tax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayCalculator.Ext.BusinessObjects.Tax.Australia
{
    public class IncomeTaxCalculator : ITaxCalculator 
    {
        protected readonly ILog _log = LogManager.GetLogger("AU Income tax calc");
        private List<ITaxBracket> _taxBrackets;

        public IncomeTaxCalculator()
        {
            _taxBrackets = new List<ITaxBracket>();
            InitBracets("AustraliaIncomeTaxBrackets"); 
        }
        
        public decimal CalculateTax(decimal taxableIncome)
        {
            decimal totalCalculatedIncomeTax = 0; 
            decimal currentBracet = 0;
            _log.DebugFormat("Calculated total income tax: {0}", totalCalculatedIncomeTax);
            return totalCalculatedIncomeTax;
        }

        private void InitBracets(string description)
        {
            
        }
    }
}
