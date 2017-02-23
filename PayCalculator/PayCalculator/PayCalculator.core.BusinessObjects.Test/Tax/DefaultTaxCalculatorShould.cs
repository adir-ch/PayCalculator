using NUnit.Framework;
using PayCalculator.core.BusinessComponents.Tax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.BusinessObjects.Test.Tax
{
    [TestFixture]
    public class DefaultTaxCalculatorShould
    {
        [Test]
        [TestCase(200000, ExpectedResult = 25)]
        [TestCase(0, ExpectedResult = 50)]
        [TestCase(18201, ExpectedResult = 0)]
        [TestCase(85000, ExpectedResult = 7)]
        public decimal CalculateTaxBrackets(decimal taxableIncom)
        {
            DefaultTaxCalculator calculator = new DefaultTaxCalculator();
            return calculator.CalculateTax(taxableIncom); 
        }
    }
}
