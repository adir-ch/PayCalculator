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
        private BudgetRepairTaxCalculator _budgetRepairCalculator;

        [OneTimeSetUp]
        public void Init()
        {
            _budgetRepairCalculator = new BudgetRepairTaxCalculator();
        }

        [Test]
        [TestCase(200000, ExpectedResult = 400)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(180000, ExpectedResult = 0)]
        [TestCase(85000, ExpectedResult = 0)]
        public decimal CalculateBudgetRepairTax(decimal taxableIncome)
        {
            return _budgetRepairCalculator.CalculateTax(taxableIncome);
        }

        [TestCase(182648.40, ExpectedResult = 53)]
        [TestCase(182612.5, ExpectedResult = 52)]
        public decimal RoundUpCalculatedBudgetRepair(decimal taxableIncome)
        {
            return _budgetRepairCalculator.CalculateTax(taxableIncome); 
        }
    }
}
