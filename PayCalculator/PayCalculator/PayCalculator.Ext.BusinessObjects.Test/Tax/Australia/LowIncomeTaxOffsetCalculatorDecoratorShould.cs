using NUnit.Framework;
using PayCalculator.Ext.BusinessObjects.Tax.Australia;
using au = PayCalculator.Ext.BusinessObjects.Tax.Australia;

namespace PayCalculator.Ext.BusinessObjects.Test.Tax.Australia
{
    [TestFixture]
    public class LowIncomeTaxOffsetCalculatorDecoratorShould
    {
        private LowIncomeTaxOffsetCalculatorDecorator _decorator;
        private au.IncomeTaxCalculator _decoratedCalculator;

        [OneTimeSetUp]
        public void Init()
        {
            _decoratedCalculator = new au.IncomeTaxCalculator(); 
            _decorator = new LowIncomeTaxOffsetCalculatorDecorator(_decoratedCalculator);
        }

        [Test]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(18201, ExpectedResult = 0)]
        [TestCase(85000, ExpectedResult = 19172)]
        [TestCase(200000, ExpectedResult = 63232)]
        public decimal CalculateTaxBrackets(decimal taxableIncom)
        {
            return _decorator.CalculateTax(taxableIncom);
        }
    }
}
