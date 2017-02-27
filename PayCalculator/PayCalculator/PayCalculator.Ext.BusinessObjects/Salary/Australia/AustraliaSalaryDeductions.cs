using PayCalculator.core.BusinessObjects.Salary;
using PayCalculator.core.Model.Salary;
using PayCalculator.Ext.Model.Salary;
using PayCalculator.Infra.IoC;
using System.Collections.Generic;
using System.Linq;

namespace PayCalculator.Ext.BusinessObjects.Salary.Australia
{
    // The class is a derived of DeductionBase and implements the abstract methods
    // The class also implements the IAustraliaSalaryDeductions to enable construction
    // injection when building the AustraliaSalaryStrategy class (if it was only IDeduction
    // type, it could have been constructor injected). 
    public class AustraliaSalaryDeductions : DeductionsBase, IAustraliaSalaryDeductions
    {
        protected override void SetDeductionRules()
        {
            // rules should be taken from DB or another micro service 
            // var rules = DB.GetAsutraliaSalaryDeductionsRules(); 
            // var rules = WebApi.GetConfigurationService("AsutraliaSalaryDeductionsRules"); 

            var fetchedRules = new List<string>() { "AustraliaIncomeTaxDeductionRule", 
                                                    "MedicareLevyDeductionRule", 
                                                    "BudgetRepairTaxDeductionRule" };

            var rules = fetchedRules.Select(ruleName => Injector.Instance.Inject<IDeductionRule>(ruleName));
            _deductionRules = rules.ToList(); 
        }
    }
}
