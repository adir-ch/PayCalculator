using Moq;
using NUnit.Framework;
using bc = PayCalculator.core.BusinessObjects.Salary;
using PayCalculator.core.BusinessObjects.Salary;
using PayCalculator.core.Model.Salary;
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
        private DefaultCoreSalaryStrategy _coreSalaryStrategy;
        
        [OneTimeSetUp]
        public void Init()
        {
            _coreSalaryStrategy = new DefaultCoreSalaryStrategy();
        }

        [Test]
        public void InitGrossSalary([Values(0, 5000)] decimal grossSalary)
        {
            _coreSalaryStrategy.GrossSalary = grossSalary;
            Assert.AreEqual(_coreSalaryStrategy.GrossSalary, grossSalary); 
        }

        [Test]
        public void ExecuteStrategyAndReturnSalaryObject([Values(0, 5000)] decimal grossSalary)
        {
            _coreSalaryStrategy.GrossSalary = grossSalary; 
            ISalary salary = new bc.Salary();
            salary.GrossSalary = grossSalary;
            salary.TaxableIncome = grossSalary; 

            var deductionsList = new List<Tuple<string, decimal>>() { Tuple.Create<string, decimal>("a", (decimal)100),
                                                                      Tuple.Create<string, decimal>("b", (decimal)200),
                                                                      Tuple.Create<string, decimal>("c", (decimal)300)};

            salary.Deductions = deductionsList;
            salary.NetAnnualSalary = (salary.TaxableIncome - 600); 
            ISalary calculatedSalary = _coreSalaryStrategy.Execute(); 
            Assert.AreEqual(salary, calculatedSalary);
        }
    }
}
