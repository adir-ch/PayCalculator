using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayCalculator.Ext.BusinessObjects.Salary.Australia.DeductionRules;
using PayCalculator.Infra.IoC;
using PayCalculator.core.Model.Tax;
using Moq; 

namespace PayCalculator.Ext.BusinessObjects.Test.Salary.Australia
{
    [TestFixture]
    public class AustraliaIncomeTaxDeductionRuleShould
    {
        private IncomeTaxDeductionRule _deductionRule;
        private Injector _injector;
        private Mock<ITaxCalculator> _taxCalcularotMock; 

        [OneTimeSetUp]
        public void Init()
        {
            _injector = Injector.Instance;
            _taxCalcularotMock = new Mock<ITaxCalculator>(); 
            _injector.RegisterInstance<ITaxCalculator>(_taxCalcularotMock.Object, "AustraliaIncomeTaxCalculator"); 
        }

        [SetUp]
        public void BeforeEach()
        {
            _deductionRule = new IncomeTaxDeductionRule();
        }

        [Test]
        public void SetAustralianTaxRuleDescription()
        {
            Assert.AreEqual(_deductionRule.GetRuleDescription(), "Income Tax"); 
        }

        [Test]
        public void CallCalculateTaxOnRuleApply([Values(0, 1000, 5000)] decimal taxableIncome)
        {
            _taxCalcularotMock.Setup(calc => calc.CalculateTax(taxableIncome)).Returns(100);
            var taxDeduction = _deductionRule.Apply(taxableIncome);
            _taxCalcularotMock.Verify(f => f.CalculateTax(taxableIncome), Times.Once());
            Assert.That(taxDeduction, Is.EqualTo(100)); 
        }

        [Test]
        [TestCase(0, ExpectedResult=0)]
        [TestCase(1000, ExpectedResult = 100)]
        [TestCase(200000, ExpectedResult = 100)]
        public decimal ReturnZeroTaxForZeroTaxableIncome(decimal taxableIncome)
        {
            _taxCalcularotMock.Setup(calc => calc.CalculateTax(taxableIncome)).Returns(100);
            return _deductionRule.Apply(taxableIncome);
        }
    }
}
