using NUnit.Framework;
using PayCalculator.Ext.BusinessObjects.Tax.Australia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Test.Tax.Australia
{
    [TestFixture]
    public class BudgetRepairTaxCalculatorShould
    {
        [Test]
        [TestCase(200000, ExpectedResult = 63232)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(18201, ExpectedResult = 0)]
        [TestCase(85000, ExpectedResult = 0)]
        public decimal CalculateBudgetRepairTax(decimal taxableIncome)
        {
            var budgetRepairTaxCalculator = new BudgetRepairTaxCalculator();
            return budgetRepairTaxCalculator.CalculateTax(taxableIncome);
        }
    }
}
