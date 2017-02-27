using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayCalculator.Ext.BusinessObjects.Tax.Australia;

namespace PayCalculator.Ext.BusinessObjects.Test.Tax.Australia
{
    [TestFixture]
    public class MedicareLevyTaxCalculatorShould
    {
        [Test]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(21335, ExpectedResult = 0)]
        [TestCase(23000, ExpectedResult = 167)]
        [TestCase(26668, ExpectedResult = 533)]
        [TestCase(50000, ExpectedResult = 1000)]
        public decimal CalculateMedicareLevy(decimal taxableIncome)
        {
            return new MedicareLevyTaxCalculator().CalculateTax(taxableIncome); 
        }
    }
}
