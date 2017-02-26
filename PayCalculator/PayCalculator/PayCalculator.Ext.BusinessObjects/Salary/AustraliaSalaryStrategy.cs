﻿using PayCalculator.core.Model.Salary;
using PayCalculator.Ext.Model.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayCalculator.Ext.BusinessObjects.Salary
{
    public class AustraliaSalaryStrategy : ISalaryStrategy
    {
        public decimal GrossSalary { get; set; }
        private IAustraliaSalaryDeductions _deductions;

        public AustraliaSalaryStrategy(IAustraliaSalaryDeductions deductions)
        {
            _deductions = deductions; 
        }

        public ISalary Execute()
        {
            var superannuation = CalculateSuperannuation();
            var taxableIncome = (GrossSalary - superannuation);
            var netAnnualSalary = taxableIncome - _deductions.GetTotalDeductionsAmount(taxableIncome);
            return BuildSalaryReport(superannuation, taxableIncome, netAnnualSalary);
        }

        private ISalary BuildSalaryReport(decimal superannuation, decimal taxableIncome, decimal netAnnualSalary)
        {
            throw new NotImplementedException();
        }

        private decimal CalculateSuperannuation()
        {
            return (GrossSalary * (decimal)0.086758); // take this value from DB
        }
    }
}
