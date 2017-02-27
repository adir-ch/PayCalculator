using NUnit.Framework;
using PayCalculator.Ext.BusinessObjects.Tax.Australia;
using au = PayCalculator.Ext.BusinessObjects.Tax.Australia;

namespace PayCalculator.Ext.BusinessObjects.Test.Tax.Australia
{
    [TestFixture]
    public class LowIncomeTaxOffsetTaxCalculatorDecoratorShould
    {
        private LowIncomeTaxOffsetTaxCalculatorDecorator _decorator;
        private au.IncomeTaxCalculator _decoratedCalculator;

        [OneTimeSetUp]
        public void Init()
        {
            _decoratedCalculator = new au.IncomeTaxCalculator(); 
            _decorator = new LowIncomeTaxOffsetTaxCalculatorDecorator(_decoratedCalculator);
        }

        [Test]
        [TestCase(0, ExpectedResult = 0)]
        public decimal CalculateTaxBrackets(decimal taxableIncom)
        {
            return _decorator.CalculateTax(taxableIncom);
        }
    }
}
