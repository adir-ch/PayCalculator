﻿using PayCalculator.core.Model.Salary;
using PayCalculator.core.Model.Tax;
using PayCalculator.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Salary.Australia.DeductionRules
{
    public class IncomeTaxDeductionRule : IDeductionRule
    {
        public string RuleName { get; set; }
        
        public string GetRuleDescription()
        {
            return "Income Tax"; // take from DB or config
        }

        public decimal Apply(decimal taxableIncome)
        {
            ITaxCalculator calculator = Injector.Instance.Inject<ITaxCalculator>("AustraliaIncomeTaxCalculator");
            return calculator.CalculateTax(taxableIncome); 
        }
    }
}
