using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Salary
{
    class AustraliaSalaryDeductions : IAustraliaSalaryDeductions
    {
        decimal GetTotalDeductionsAmount(decimal taxableIncome)
        {
            throw new NotImplementedException();
        }
        IList<Tuple<string, decimal>> GetDeductionsReport()
        {
            throw new NotImplementedException();
        }
    }
}
