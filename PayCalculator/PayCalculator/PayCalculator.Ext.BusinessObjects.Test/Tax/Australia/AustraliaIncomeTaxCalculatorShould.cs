using NUnit.Framework;
using au = PayCalculator.Ext.BusinessObjects.Tax.Australia;

namespace PayCalculator.Ext.BusinessObjects.Test.Tax.Australia
{
    [TestFixture]
    public class AustraliaIncomeTaxCalculatorShould
    {
        [Test]
        [TestCase(200000, ExpectedResult = 63232)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(18201, ExpectedResult = 0)]
        [TestCase(85000, ExpectedResult = 19172)]
        public decimal CalculateTaxBrackets(decimal taxableIncom)
        {
            au.IncomeTaxCalculator calculator = new au.IncomeTaxCalculator();
            return calculator.CalculateTax(taxableIncom);
        }
    }
}
