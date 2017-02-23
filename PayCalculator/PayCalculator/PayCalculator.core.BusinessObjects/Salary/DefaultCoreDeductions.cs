using PayCalculator.core.BusinessObjects.Salary;
using PayCalculator.core.Model.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.BusinessObjects.Salary
{
    public class DefaultCoreDeductions : DeductionsBase
    {

        protected override void SetDeductionRules()
        {
            // best practice will be to get the deduction rules from the DB. 
            // and adding them the DB via some scripting lang or XML 

            // the only rules for the default deductions are the default tax rules
            // Taxable income = gross salary! 
            AddDefaultTaxRule();
        }

        private void AddDefaultTaxRule()
        {
            throw new NotImplementedException();
        }
    }
}
