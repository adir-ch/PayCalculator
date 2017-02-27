using PayCalculator.core.Model.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Salary.Germany.DeductionRules
{
    public class SolidaritySurchargeDeductionRule : IDeductionRule
    {
        public string RuleName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string GetRuleDescription()
        {
            throw new NotImplementedException();
        }

        public decimal Apply(decimal taxableIncome)
        {
            throw new NotImplementedException();
        }
    }
}
