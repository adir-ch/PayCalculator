using PayCalculator.core.Model.Tax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Tax.Australia
{
    public class LowIncomeTaxOffsetCalculatorDecorator : ITaxCalculatorDecorator
    {
        public decimal CalculateTax(decimal taxableIncome)
        {
            throw new NotImplementedException();
        }
    }
}
