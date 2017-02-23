using PayCalculator.core.Model.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.BusinessObjects.Salary
{
    public class DefaultCoreSalaryStrategy : ISalaryStrategy
    {
        public decimal GrossSalary { get; set; }

        public ISalary Execute()
        {
            throw new NotImplementedException();
        }
    }
}
