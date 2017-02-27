using PayCalculator.core.Model.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Salary.Australia.DeductionRules
{
    public class BudgetRepairTaxDeductionRule : IDeductionRule
    {
        public string RuleName { get; set; }

        public string GetRuleDescription()
        {
            return "Temporary Budget Repair Levy";
        }

        public decimal Apply(decimal taxableIncome)
        {
            throw new NotImplementedException();
        }
    }
}
