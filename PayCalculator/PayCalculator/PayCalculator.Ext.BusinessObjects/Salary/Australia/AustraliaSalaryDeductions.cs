using PayCalculator.core.BusinessObjects.Salary;
using PayCalculator.Ext.Model.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Salary.Australia
{
    // The class is a derived of DeductionBase and implements the abstract methods
    // The class also implements the IAustraliaSalaryDeductions to enable construction
    // injection when building the AustraliaSalaryStrategy class (if it was only IDeduction
    // type, it could have been constructor injected). 
    class AustraliaSalaryDeductions : DeductionsBase, IAustraliaSalaryDeductions
    {
        protected override void SetDeductionRules()
        {
            throw new NotImplementedException();
        }
    }
}
