using System;
using System.Collections.Generic;

namespace PayCalculator.core.Model.Salary
{
    public interface IDeductions
    {
        decimal GetTotalDeductionsAmount(decimal taxableIncome);
        IList<Tuple<string, decimal>> GetDeductionsReport(); 
    }
}
