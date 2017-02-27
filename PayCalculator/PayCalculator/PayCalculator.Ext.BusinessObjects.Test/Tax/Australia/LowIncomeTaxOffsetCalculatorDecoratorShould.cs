using NUnit.Framework;
using PayCalculator.Ext.BusinessObjects.Tax.Australia;
using au = PayCalculator.Ext.BusinessObjects.Tax.Australia;

namespace PayCalculator.Ext.BusinessObjects.Test.Tax.Australia
{
    [TestFixture]
    public class LowIncomeTaxOffsetCalculatorDecoratorShould
    {
        [Test]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(18201, ExpectedResult = 0)]
        [TestCase(85000, ExpectedResult = 19172)]
        [TestCase(200000, ExpectedResult = 63232)]
        public decimal CalculateTaxBrackets(decimal taxableIncom)
        {
            LowIncomeTaxOffsetCalculatorDecorator calculator = new LowIncomeTaxOffsetCalculatorDecorator();
            return calculator.CalculateTax(taxableIncom);
        }
    }
}
