using PayCalculator.core.Model.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayCalculator.Ext.BusinessObjects.Location
{
    public class AustraliaSalaryStrategy : ISalaryStrategy
    {
        public decimal GrossSalary { get; set; }

        public ISalary Execute()
        {
            throw new NotImplementedException();
        }
    }
}
