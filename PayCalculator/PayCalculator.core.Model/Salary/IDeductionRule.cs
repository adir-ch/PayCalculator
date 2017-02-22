using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayCalculator.core.Model.Salary
{
    public interface IDeductionRule
    {
        string  RuleName { get; set; }
        string GetRuleDescription();
        decimal Apply(decimal taxableIncome); 
    }
}
