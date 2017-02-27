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
    public class MedicareLevyDeductionRuleShoud
    {
        private MedicareLevyDeductionRule _deductionRule;
        private Injector _injector;
        private Mock<ITaxCalculator> _medicareLevyCalculatorMock;

        [OneTimeSetUp]
        public void Init()
        {
            _injector = Injector.Instance;
            _medicareLevyCalculatorMock = new Mock<ITaxCalculator>();
            _injector.RegisterInstance<ITaxCalculator>(_medicareLevyCalculatorMock.Object, "AustraliaMedicareLevyCalculator");
        }

        [SetUp]
        public void BeforeEach()
        {
            _deductionRule = new MedicareLevyDeductionRule();
        }

        [Test]
        public void SetAustralianMedicareDeductionRuleDescription()
        {
            Assert.AreEqual(_deductionRule.GetRuleDescription(), "Medicare Levy");
        }
    }
}
