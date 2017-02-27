using log4net;
using PayCalculator.core.Model.Salary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayCalculator.core.BusinessObjects.Salary
{
    public abstract class DeductionsBase : IDeductions
    {
        protected readonly ILog _log = LogManager.GetLogger("Deductions");
        protected IList<IDeductionRule> _deductionRules;
        protected IList<Tuple<string, decimal>> _deductionsReport;

        public DeductionsBase()
        {
            _deductionRules = new List<IDeductionRule>();
            _deductionsReport = new List<Tuple<string, decimal>>();
            SetDeductionRules();
        }

        protected abstract void SetDeductionRules();

        public decimal GetTotalDeductionsAmount(decimal taxableIncome)
        {
            if (_deductionRules.Count() == 0)
            {
                return 0;
            }

            // decimal deductions = _deductionRules.Sum(r => r.Apply(taxableIncome)); 
            foreach (var rule in _deductionRules)
            {
                _deductionsReport.Add(Tuple.Create<string, decimal>(rule.GetRuleDescription(), rule.Apply(taxableIncome)));
            }

            var totalDeductionsAmount = _deductionsReport.Sum(e => e.Item2);
            _log.DebugFormat("Total deductions amount: {0}", totalDeductionsAmount);
            return totalDeductionsAmount;
        }

        public IList<Tuple<string, decimal>> GetDeductionsReport()
        {
            return _deductionsReport;
        }
    }
}
