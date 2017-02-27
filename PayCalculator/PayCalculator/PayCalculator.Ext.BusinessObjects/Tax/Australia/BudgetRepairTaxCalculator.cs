using log4net;
using PayCalculator.core.Model.Tax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Tax.Australia
{
    public class BudgetRepairTaxCalculator : ITaxCalculator
    {
        protected readonly ILog _log = LogManager.GetLogger("AU Income tax calc");
        public decimal CalculateTax(decimal taxableIncome)
        {
            decimal totalBudgetRepairTax = 0; 

            if (taxableIncome > 180000)  // take values from DB
            {
                totalBudgetRepairTax = ((taxableIncome - 180000) * (decimal)0.02);
            }

            _log.DebugFormat("Calculated total budget repair: {0}", totalBudgetRepairTax);
            return totalBudgetRepairTax; 
        }
    }
}