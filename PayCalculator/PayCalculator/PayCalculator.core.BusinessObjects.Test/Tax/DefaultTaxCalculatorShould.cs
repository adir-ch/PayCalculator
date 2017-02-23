using NUnit.Framework;
using PayCalculator.core.BusinessObjects.Tax;
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
        [TestCase(200000, ExpectedResult = 63232)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(18201, ExpectedResult = 0)]
        [TestCase(85000, ExpectedResult = 19172)]
        public decimal CalculateTaxBrackets(decimal taxableIncom)
        {
            DefaultTaxCalculator calculator = new DefaultTaxCalculator();
            return calculator.CalculateTax(taxableIncom); 
        }
    }
}
