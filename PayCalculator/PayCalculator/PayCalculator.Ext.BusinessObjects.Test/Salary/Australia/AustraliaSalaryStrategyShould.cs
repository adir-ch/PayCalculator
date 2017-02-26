using Moq;
using NUnit.Framework;
using PayCalculator.core.Model.Salary;
using PayCalculator.Ext.BusinessObjects.Salary.Australia;
using PayCalculator.Ext.Model.Salary;
using PayCalculator.Infra.IoC;
using System;
using System.Collections.Generic;
using bc = PayCalculator.core.BusinessObjects.Salary;

namespace PayCalculator.Ext.BusinessObjects.Test.Salary.Australia
{
    [TestFixture(0)]
    [TestFixture(1000)]
    [TestFixture(5000)]
    public class AustraliaSalaryStrategyShould
    {
        private decimal _initialGrossSalary; 
        private AustraliaSalaryStrategy _australiaSalaryStrategy;
        private Mock<IAustraliaSalaryDeductions> _deductionsMock;
        private Injector _injector;
        private ISalary _salary;

        public AustraliaSalaryStrategyShould(int grossSalary)
        {
            _initialGrossSalary = grossSalary; 
        }

        [OneTimeSetUp]
        public void Init()
        {
            _deductionsMock = new Mock<IAustraliaSalaryDeductions>();
            _injector = Injector.Instance;
            _injector.RegisterInstance<IDeductions>(_deductionsMock.Object, "AustraliaSalaryDeductions");
            _australiaSalaryStrategy = new AustraliaSalaryStrategy(_deductionsMock.Object);
        }

        [SetUp]
        public void BeforeEach()
        {
            _salary = new bc.Salary();
            _salary.GrossSalary = _initialGrossSalary;

            decimal super = (_salary.GrossSalary * (decimal)0.086758);
            _salary.TaxableIncome = _salary.GrossSalary - super;

            decimal deductionsAmount = (decimal)600;
            var deductionsList = new List<Tuple<string, decimal>>() { Tuple.Create<string, decimal>("a", (decimal)100),
                                                                      Tuple.Create<string, decimal>("b", (decimal)200),
                                                                      Tuple.Create<string, decimal>("c", (decimal)300)};

            _deductionsMock.Setup(d => d.GetDeductionsReport()).Returns(deductionsList);
            _deductionsMock.Setup(d => d.GetTotalDeductionsAmount(It.IsAny<decimal>())).Returns(deductionsAmount);

            _salary.Deductions = deductionsList;
            _salary.NetAnnualSalary = (_salary.TaxableIncome - deductionsAmount);
        }

        [Test]
        public void InitGrossSalary()
        {
            _australiaSalaryStrategy.GrossSalary = _initialGrossSalary;
            Assert.AreEqual(_australiaSalaryStrategy.GrossSalary, _initialGrossSalary);
        }

        [Test]
        public void ExecuteStrategyAndReturnSalaryObject()
        {
            _australiaSalaryStrategy.GrossSalary = _initialGrossSalary;
            ISalary calculatedSalary = _australiaSalaryStrategy.Execute();

            Assert.AreEqual(_salary.GrossSalary, calculatedSalary.GrossSalary);
            Assert.AreEqual(_salary.TaxableIncome, calculatedSalary.TaxableIncome);
            Assert.AreEqual(_salary.NetAnnualSalary, calculatedSalary.NetAnnualSalary);
            Assert.AreEqual(_salary.Deductions, calculatedSalary.Deductions);
        }

        [Test]
        public void ContainSuperAnnuationInTheDeductionsReport()
        {
            _australiaSalaryStrategy.GrossSalary = _initialGrossSalary;
            ISalary calculatedSalary = _australiaSalaryStrategy.Execute();

            decimal super = (_salary.GrossSalary * (decimal)0.086758);
            var expectedSuperEntry = Tuple.Create<string, decimal>("Superannuation", super);
            ICollection<Tuple<string, decimal>> collection = calculatedSalary.Deductions as ICollection<Tuple<string, decimal>>; 
            Assert.That(collection, Has.Member(expectedSuperEntry));
        }
    }
}
