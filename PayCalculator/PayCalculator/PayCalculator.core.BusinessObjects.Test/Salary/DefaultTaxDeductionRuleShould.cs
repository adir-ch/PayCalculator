﻿using Moq;
using NUnit.Framework;
using PayCalculator.core.BusinessComponents.Salary;
using PayCalculator.core.Model.Tax;
using PayCalculator.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.BusinessObjects.Test.Salary
{
    [TestFixture]
    public class DefaultTaxDeductionRuleShould
    {
        private DefaultTaxDeductionRule _defaultTaxDeductionRule;
        private Mock<ITaxCalculator> _taxCalculatorMock; 

        [OneTimeSetUp]
        public void Init()
        {
            _taxCalculatorMock = new Mock<ITaxCalculator>(); 
            _defaultTaxDeductionRule = new DefaultTaxDeductionRule(_taxCalculatorMock.Object);
        }

        [Test]
        public void NotReturnEmpltyDescription()
        {
            Assert.IsTrue(String.IsNullOrEmpty(_defaultTaxDeductionRule.GetRuleDescription()) == false);
        }

        [Test]
        public void ApplyRuleOnTaxableIncome([Values(200000)] decimal taxableIncome)
        {
            _taxCalculatorMock.Setup(f => f.CalculateTax(taxableIncome)).Returns(0); 
            var calculatedTax = _defaultTaxDeductionRule.Apply(taxableIncome);
            _taxCalculatorMock.Verify(calc => calc.CalculateTax(It.IsAny<decimal>()), Times.Once());
        }
    }
}
