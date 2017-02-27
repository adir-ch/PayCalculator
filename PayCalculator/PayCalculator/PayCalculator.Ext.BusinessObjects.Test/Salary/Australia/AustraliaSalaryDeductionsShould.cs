using Moq;
using NUnit.Framework;
using PayCalculator.core.BusinessObjects.Salary;
using PayCalculator.core.BusinessObjects.Tax;
using PayCalculator.core.Model.Salary;
using PayCalculator.core.Model.Tax;
using PayCalculator.Ext.BusinessObjects.Salary.Australia;
using PayCalculator.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayCalculator.Ext.BusinessObjects.Test.Salary.Australia;

namespace PayCalculator.core.BusinessObjects.Test.Salary
{
    [TestFixture]
    public class DefaultCoreDeductionsShould
    {
        private AustraliaSalaryDeductions _deductions;
        private Mock<IDeductionRule> _deductionRuleMock; 
        private Injector _injector;

        [OneTimeSetUp]
        public void Init()
        {
            _deductionRuleMock = new Mock<IDeductionRule>(); 
            _injector = Injector.Instance;
            _injector.RegisterInstance<IDeductionRule>(_deductionRuleMock.Object, "AustraliaIncomeTaxDeductionRule");
            _injector.RegisterInstance<IDeductionRule>(_deductionRuleMock.Object, "MedicareLevyDeductionRule");
            _injector.RegisterInstance<IDeductionRule>(_deductionRuleMock.Object, "BudgetRepairTaxDeductionRule");
            _deductionRuleMock.Setup(rule => rule.Apply(It.IsAny<decimal>())).Returns(100);
        }

        [SetUp]
        public void BeforeEach()
        {
            _deductions = new AustraliaSalaryDeductions();
        }

        [Test]
        public void ContainListOfDeductionRules([Values(0, 1000, 5000)] decimal taxableIncome)
        {
            var deductionsAmount = _deductions.GetTotalDeductionsAmount(taxableIncome);
            var deductionsReport = _deductions.GetDeductionsReport();
            Assert.That(deductionsReport, Is.Not.Empty);
            Assert.That(deductionsReport.Count(), Is.EqualTo(3));
        }
    }
}
