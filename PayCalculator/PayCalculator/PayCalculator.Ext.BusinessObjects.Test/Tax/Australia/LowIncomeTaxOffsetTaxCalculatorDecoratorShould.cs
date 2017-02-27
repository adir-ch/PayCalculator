using NUnit.Framework;
using PayCalculator.Ext.BusinessObjects.Tax.Australia;
using PayCalculator.Ext.Model.Tax;
using au = PayCalculator.Ext.BusinessObjects.Tax.Australia;

namespace PayCalculator.Ext.BusinessObjects.Test.Tax.Australia
{
    [TestFixture]
    public class LowIncomeTaxOffsetTaxCalculatorDecoratorShould
    {
        private LowIncomeTaxOffsetTaxCalculatorDecorator _decorator;
        private IAustraliaDecoratableTaxCalculator _decoratedCalculator;

        [OneTimeSetUp]
        public void Init()
        {
            _decoratedCalculator = new au.IncomeTaxCalculator();
            _decorator = new au.LowIncomeTaxOffsetTaxCalculatorDecorator(_decoratedCalculator);
        }

        [Test]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(20000, ExpectedResult = 0)] // TODO: what happens if below zero
        [TestCase(40000, ExpectedResult = 4107)]
        [TestCase(66667, ExpectedResult = 13214)]
        public decimal CalculateTaxBrackets(decimal taxableIncom)
        {
            return _decorator.CalculateTax(taxableIncom);
        }
    }
}
