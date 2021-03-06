﻿using log4net;
using PayCalculator.core.Model.Tax;
using PayCalculator.Ext.Model.Tax;
using System;

namespace PayCalculator.Ext.BusinessObjects.Tax.Australia
{
    public class LowIncomeTaxOffsetTaxCalculatorDecorator : ITaxCalculatorDecorator
    {
        protected readonly ILog _log = LogManager.GetLogger("AU Income tax calc");
        // maybe I should add another base class for all the tax calculators decorators to hold the actual tax calculator
        private ITaxCalculator _decoratedCalculator = null;

        public LowIncomeTaxOffsetTaxCalculatorDecorator(IAustraliaDecoratableTaxCalculator calculator)
        {
            _decoratedCalculator = calculator;
        }

        public decimal CalculateTax(decimal taxableIncome)
        {
            var baseTax = _decoratedCalculator.CalculateTax(taxableIncome); 
            decimal lowIncomeTaxOffset = 0;

            if (taxableIncome < 66667)
            {
                if (taxableIncome <= 37000)
                {
                    lowIncomeTaxOffset = 445;
                }
                else
                {
                    lowIncomeTaxOffset = (decimal)(445 - ((taxableIncome - 37000) * (decimal)0.0015));
                }

                if ((baseTax - lowIncomeTaxOffset) < 0)
                {
                    return 0;
                }
            }
            return Math.Round((baseTax - lowIncomeTaxOffset), MidpointRounding.AwayFromZero);
        }
    }
}
