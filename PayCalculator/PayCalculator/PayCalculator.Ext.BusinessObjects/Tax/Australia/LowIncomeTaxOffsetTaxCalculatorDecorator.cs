using log4net;
using PayCalculator.core.Model.Tax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Tax.Australia
{
    public class LowIncomeTaxOffsetTaxCalculatorDecorator : ITaxCalculatorDecorator
    {
        protected readonly ILog _log = LogManager.GetLogger("AU Income tax calc");
        // maybe I should add another base class for all the tax calculators decorators to hold the actual tax calculator
        private ITaxCalculator _decoratedCalculator = null;

        public LowIncomeTaxOffsetTaxCalculatorDecorator(ITaxCalculator calculator)
        {
            _decoratedCalculator = calculator;
        }

        public decimal CalculateTax(decimal taxableIncome)
        {
            return _decoratedCalculator.CalculateTax(taxableIncome); 
        }
    }
}
