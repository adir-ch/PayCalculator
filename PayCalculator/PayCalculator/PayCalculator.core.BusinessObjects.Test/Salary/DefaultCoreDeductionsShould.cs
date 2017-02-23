using Moq;
using NUnit.Framework;
using PayCalculator.core.BusinessObjects.Salary;
using PayCalculator.core.BusinessObjects.Tax;
using PayCalculator.core.Model.Salary;
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
    public class DefaultCoreDeductionsShould
    {
        private DefaultCoreDeductions _deductions;
        private Mock<IDeductionRule> _deductionRuleMock;
        private Injector _injector; 

        [OneTimeSetUp]
        public void Init()
        {
            _deductionRuleMock = new Mock<IDeductionRule>();
            _injector = Injector.Instance;
            _injector.RegisterInstance<IDeductionRule>(_deductionRuleMock.Object, "DefaultTaxDeductionRule");
            _deductions = new DefaultCoreDeductions();

            _deductionRuleMock.Setup(rule => rule.Apply(It.IsAny<decimal>())).Returns(100);
            _deductionRuleMock.Setup(rule => rule.GetRuleDescription()).Returns("Default Core Tax rule"); 
        }

        [Test]
        public void ReturnTotalDeductionsAmount([Values(200000)] decimal taxableSalary)
        {
            var amount =_deductions.GetTotalDeductionsAmount(taxableSalary);
            Assert.AreEqual(amount, 100); 
        }

        [Test]
        public void ReturnValidDeductionReport([Values(200000)] decimal taxableSalary)
        {
            _deductions.GetTotalDeductionsAmount(taxableSalary);
            var deductionsReport = _deductions.GetDeductionsReport();
            Assert.IsNotEmpty(deductionsReport); 
            Assert.Greater(deductionsReport.Where(rdesc => rdesc.Item1.Equals("Default Core Tax rule") == true).Count(), 0);
        }
    }
}
