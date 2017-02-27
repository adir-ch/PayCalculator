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
        public decimal CalculateTax(decimal taxableIncome)
        {
            decimal totalCalculatedMedicareLevy = 0;
            return totalCalculatedMedicareLevy;
        }
    }
}