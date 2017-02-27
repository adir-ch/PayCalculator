using PayCalculator.core.Model.Tax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Tax.Germany
{
    class SolidaritySurchargeCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal taxableIncome)
        {
            return (taxableIncome * (decimal)0.0055);
        }
    }
}
