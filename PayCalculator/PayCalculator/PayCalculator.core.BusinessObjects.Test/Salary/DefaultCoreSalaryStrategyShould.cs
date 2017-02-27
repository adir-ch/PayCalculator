using Moq;
using NUnit.Framework;
using PayCalculator.core.BusinessObjects.Salary;
using PayCalculator.core.Model.Salary;
using PayCalculator.Infra.IoC;
using System;
using System.Collections.Generic;
using bc = PayCalculator.core.BusinessObjects.Salary;


namespace PayCalculator.core.BusinessObjects.Test.Salary
{
    [TestFixture]
    public class DefaultCoreSalaryStrategyShould
    {
        private DefaultCoreSalaryStrategy _coreSalaryStrategy;
        private Mock<IDeductions> _deductionsMock;
        private Injector _injector; 
        
        [OneTimeSetUp]
        public void Init()
        {
            _deductionsMock = new Mock<IDeductions>();
            _injector = Injector.Instance;
            _injector.RegisterInstance<IDeductions>(_deductionsMock.Object, "DefaultCoreDeductions");
            _coreSalaryStrategy = new DefaultCoreSalaryStrategy();
        }

        [Test]
        public void InitGrossSalary([Values(0, 5000)] decimal grossSalary)
        {
            _coreSalaryStrategy.GrossSalary = grossSalary;
            Assert.AreEqual(_coreSalaryStrategy.GrossSalary, grossSalary); 
        }

        [Test]
        public void ExecuteStrategyAndReturnSalaryObject([Values(1000, 5000)] decimal grossSalary)
        {
            _coreSalaryStrategy.GrossSalary = grossSalary; 
            ISalary salary = new bc.Salary();
            salary.GrossSalary = grossSalary;
            salary.TaxableIncome = grossSalary;


            decimal  deductionsAmount = (decimal)600; 
            var deductionsList = new List<Tuple<string, decimal>>() { Tuple.Create<string, decimal>("a", (decimal)100),
                                                                      Tuple.Create<string, decimal>("b", (decimal)200),
                                                                      Tuple.Create<string, decimal>("c", (decimal)300)};

            _deductionsMock.Setup(d => d.GetDeductionsReport()).Returns(deductionsList);
            _deductionsMock.Setup(d => d.GetTotalDeductionsAmount(It.IsAny<decimal>())).Returns(deductionsAmount);

            salary.Deductions = deductionsList;
            salary.NetAnnualSalary = (salary.TaxableIncome - deductionsAmount); 
            ISalary calculatedSalary = _coreSalaryStrategy.Execute();

            Assert.AreEqual(salary.GrossSalary, calculatedSalary.GrossSalary);
            Assert.AreEqual(salary.TaxableIncome, calculatedSalary.TaxableIncome);
            Assert.AreEqual(salary.NetAnnualSalary, calculatedSalary.NetAnnualSalary);
            Assert.AreEqual(salary.Deductions, calculatedSalary.Deductions);
        }

        [Test]
        public void NotReturnNegativeNetAnnualSalary()
        {
            _coreSalaryStrategy.GrossSalary = 0;
            decimal deductionsAmount = (decimal)600;
            var deductionsList = new List<Tuple<string, decimal>>();
            _deductionsMock.Setup(d => d.GetDeductionsReport()).Returns(deductionsList);
            _deductionsMock.Setup(d => d.GetTotalDeductionsAmount(It.IsAny<decimal>())).Returns(deductionsAmount);

            ISalary calculatedSalary = _coreSalaryStrategy.Execute();
            Assert.GreaterOrEqual(calculatedSalary.NetAnnualSalary, 0);
        }
    }
}
