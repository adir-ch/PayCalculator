using NUnit.Framework;
using PayCalculator.core.BusinessObjects.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.BusinessObjects.Test.Salary
{
    [TestFixture]
    public class DefaultCoreSalaryStrategyShould
    {
        private DefaultCoreSalaryStrategy _coreSalaryStragegy;

        [OneTimeSetUp]
        public void Init()
        {
            _coreSalaryStragegy = new DefaultCoreSalaryStrategy();
        }

        [Test]
        public void InitGrossSalary([Values(0, 5000)] decimal grossSalary)
        {
            _coreSalaryStragegy.GrossSalary = grossSalary;
            Assert.AreEqual(_coreSalaryStragegy.GrossSalary, grossSalary); 
        }
    }
}
