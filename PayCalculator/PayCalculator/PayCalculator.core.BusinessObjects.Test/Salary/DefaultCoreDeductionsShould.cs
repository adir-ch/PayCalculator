using Moq;
using NUnit.Framework;
using PayCalculator.core.BusinessObjects.Salary;
using PayCalculator.core.Model.Salary;
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
            _injector.Register(typeof(IDeductionRule), typeof(DefaultTaxDeductionRule), "DefaultTaxDeductionRule");
            _deductions = new DefaultCoreDeductions();

            _deductionRuleMock.Setup(f => f.Apply(It.IsAny<decimal>())).Returns(100); 
        }

        [Test]
        public void ReturnTotalDeductionsAmount(decimal taxableSalary)
        {
            _deductions.GetTotalDeductionsAmount(taxableSalary); 
            var deductionsReport = _deductions.GetDeductionsReport(); 
            Assert.IsNotEmpty(deductionsReport);
        }

        [Test]
        public void ReturnDeductionReport()
        {
            Assert.IsNotEmpty(_deductions.GetDeductionsReport());
        }
    }
}
