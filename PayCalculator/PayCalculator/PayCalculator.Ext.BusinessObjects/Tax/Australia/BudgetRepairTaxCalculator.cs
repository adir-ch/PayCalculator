﻿using PayCalculator.core.Model.Tax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Tax.Australia
{
    public class BudgetRepairTaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal taxableIncome)
        {
            if (taxableIncome > 180000)  // take values from DB
            {
                return ((taxableIncome - 180000) * (decimal)0.02);
            }
            return 0;
        }
    }
}