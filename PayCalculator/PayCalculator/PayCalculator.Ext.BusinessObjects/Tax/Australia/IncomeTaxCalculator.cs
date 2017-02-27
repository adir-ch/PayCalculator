using log4net;
using PayCalculator.core.BusinessObjects.Tax;
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

            foreach (var bracket in _taxBrackets)
            {
                if (bracket.CanApplyBracket(taxableIncome) == true)
                {
                    currentBracet = bracket.CalculateTaxBracket(taxableIncome);
                    totalCalculatedIncomeTax += Math.Round(currentBracet);
                }
                else
                {
                    break;
                }
            }

            _log.DebugFormat("Calculated total income tax: {0}", totalCalculatedIncomeTax);
            return totalCalculatedIncomeTax;
        }

        private void InitBracets(string description)
        {
            // adding the tax bracets - should be done via microservice 
            // bracets should be taken from DB
            _taxBrackets.Add(new DefaultTaxBracket(0, 18200, 0));
            _taxBrackets.Add(new DefaultTaxBracket(18201, 37000, (decimal)0.19));
            _taxBrackets.Add(new DefaultTaxBracket(37001, 87000, (decimal)0.325));
            _taxBrackets.Add(new DefaultTaxBracket(87001, 180000, (decimal)0.37));
            _taxBrackets.Add(new DefaultTaxBracket(180001, decimal.MaxValue, (decimal)0.45));
        }
    }
}
