using Moq;
using NUnit.Framework;
using PayCalculator.core.Model.Salary;
using PayCalculator.Ext.BusinessObjects.Location;
using PayCalculator.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Test.Salary
{
    [TestFixture]
    public class AustraliaSalaryStrategyShould
    {
        private AustraliaSalaryStrategy _australiaSalaryStrategy;
        private Mock<IDeductions> _deductionsMock;
        private Injector _injector;

        [OneTimeSetUp]
        public void Init()
        {
            _deductionsMock = new Mock<IDeductions>();
            _injector = Injector.Instance;
            _injector.RegisterInstance<IDeductions>(_deductionsMock.Object, "AustraliaSalaryDeductions");
            _australiaSalaryStrategy = new AustraliaSalaryStrategy();
        }

        [Test]
        public void InitGrossSalary([Values(0, 5000)] decimal grossSalary)
        {
            _australiaSalaryStrategy.GrossSalary = grossSalary;
            Assert.AreEqual(_australiaSalaryStrategy.GrossSalary, grossSalary);
        }
    }
}
