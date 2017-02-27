using log4net;
using PayCalculator.core.Model.Tax;
using System;

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

            var roundedTotalBudgetRepairTax = Math.Round(totalBudgetRepairTax, MidpointRounding.AwayFromZero);
            _log.DebugFormat("Calculated total budget repair: {0}", roundedTotalBudgetRepairTax);
            return roundedTotalBudgetRepairTax; 
        }
    }
}