﻿using PayCalculator.core.Model.Salary;
using System;
using System.Collections.Generic;

namespace PayCalculator.core.BusinessObjects.Salary
{
    public class Salary : ISalary
    {
        public decimal GrossSalary { get; set; }
        public decimal TaxableIncome { get; set; }
        public decimal NetAnnualSalary { get; set; }
        public IList<Tuple<string, decimal>> Deductions { get; set; }
    }
}
