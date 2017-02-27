using PayCalculator.core.Model.Salary;
using PayCalculator.Infra.IoC;

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
            _deductionRules.Add(Injector.Instance.Inject<IDeductionRule>("DefaultTaxDeductionRule"));
        }
    }
}
