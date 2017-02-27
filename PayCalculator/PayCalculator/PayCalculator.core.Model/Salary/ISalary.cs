using System;
using System.Collections.Generic;

namespace PayCalculator.core.Model.Salary
{
    public interface ISalary
    {
        decimal GrossSalary { get; set; }
        decimal TaxableIncome { get; set; }
        decimal NetAnnualSalary { get; set; }
        IList<Tuple<string, decimal>> Deductions { get; set; }
    }
}
