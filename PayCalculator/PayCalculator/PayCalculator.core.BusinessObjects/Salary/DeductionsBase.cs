using log4net;
using PayCalculator.core.Model.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        protected abstract void SetDeductionRules();

        public decimal GetTotalDeductionsAmount(decimal taxableIncome)
        {
            throw new NotImplementedException();
        }

        public IList<Tuple<string, decimal>> GetDeductionsReport()
        {
            throw new NotImplementedException();
        }
    }
}
