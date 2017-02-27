﻿using PayCalculator.core.BusinessObjects.Salary;
using PayCalculator.core.Model.Salary;
using PayCalculator.Ext.Model.Salary;
using PayCalculator.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Salary.NewZealand
{
    class NewZealandSalaryDeductions : DeductionsBase, INewZealandSalaryDeductions
    {
        protected override void SetDeductionRules()
        {
            // rules should be taken from DB or another micro service 
            // var rules = DB.GetAsutraliaSalaryDeductionsRules(); 
            // var rules = WebApi.GetConfigurationService("AsutraliaSalaryDeductionsRules"); 

            var fetchedRules = new List<string>() { "IncomeTaxDeductionRule", 
                                                    "SocialSecurityAndHealthContribDeductionRule" };

            var rules = fetchedRules.Select(ruleName => Injector.Instance.Inject<IDeductionRule>(ruleName));
            _deductionRules = rules.ToList();
        }
    }
}