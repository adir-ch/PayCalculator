﻿using Moq;
using NUnit.Framework;
using PayCalculator.core.Model.Tax;
using PayCalculator.Ext.BusinessObjects.Salary.Australia.DeductionRules;
using PayCalculator.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Test.Salary.Australia
{
    [TestFixture]
    public class BudgetRepairTaxDeductionRuleShould
    {
        private BudgetRepairTaxDeductionRule _deductionRule;
        private Injector _injector;
        private Mock<ITaxCalculator> _budgetRepairTaxCalculatorMock;

        [OneTimeSetUp]
        public void Init()
        {
            _injector = Injector.Instance;
            _budgetRepairTaxCalculatorMock = new Mock<ITaxCalculator>();
            _injector.RegisterInstance<ITaxCalculator>(_budgetRepairTaxCalculatorMock.Object, "AustraliaBudgetRepairTaxCalculator");
        }

        [SetUp]
        public void BeforeEach()
        {
            _deductionRule = new BudgetRepairTaxDeductionRule();
        }

        [Test]
        public void SetAustralianMedicareDeductionRuleDescription()
        {
            Assert.AreEqual(_deductionRule.GetRuleDescription(), "Temporary Budget Repair Levy");
        }

        [Test]
        public void CallCalculateTaxOnRuleApply([Values(0, 1000, 5000)] decimal taxableIncome)
        {
            _budgetRepairTaxCalculatorMock.Setup(calc => calc.CalculateTax(taxableIncome)).Returns(100);
            var taxDeduction = _deductionRule.Apply(taxableIncome);

            if (taxableIncome > 0)
            {
                _budgetRepairTaxCalculatorMock.Verify(f => f.CalculateTax(taxableIncome), Times.Once());
                Assert.That(taxDeduction, Is.EqualTo(100));
            }
        }
    }
}
