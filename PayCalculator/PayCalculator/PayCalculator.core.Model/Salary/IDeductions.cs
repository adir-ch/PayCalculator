using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayCalculator.core.Model.Salary
{
    public interface IDeductions
    {
        decimal GetTotalDeductionsAmount(decimal taxableIncome);
        IList<Tuple<string, decimal>> GetDeductionsReport(); 
    }
}
