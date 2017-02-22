using PayCalculator.core.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayCalculator.core.Model.Salary
{
    public interface ISalaryStrategy
    {
        decimal GrossSalary { get; set; }
        ISalary Execute();
    }
}
