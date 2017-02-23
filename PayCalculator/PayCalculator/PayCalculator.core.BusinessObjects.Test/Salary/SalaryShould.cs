using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cbc = PayCalculator.core.BusinessObjects.Salary; 

namespace PayCalculator.core.BusinessObjects.Test.Salary
{
    [TestFixture]
    public class SalaryShould
    {
        [Test]
        public void CotainInitializedData([Values(1000, 0, -1000)] decimal grossSalary, 
                                          [Values(1000, 0, -1000)] decimal taxableIncome, 
                                          [Values(1000, 0, -1000)] decimal netAnuualSalary)
        {
            cbc.Salary salary = new cbc.Salary();
            salary.GrossSalary = grossSalary;
            salary.TaxableIncome = taxableIncome;
            salary.NetAnnualSalary = netAnuualSalary;

            var deductionsList = new List<Tuple<string, decimal>>() { Tuple.Create<string, decimal>("a", (decimal)100),
                                                                      Tuple.Create<string, decimal>("b", (decimal)200),
                                                                      Tuple.Create<string, decimal>("c", (decimal)300)};
            salary.Deductions = deductionsList; 
            Assert.AreEqual(salary.GrossSalary, grossSalary);
            Assert.AreEqual(salary.TaxableIncome, taxableIncome);
            Assert.AreEqual(salary.NetAnnualSalary, netAnuualSalary);
            Assert.AreEqual(salary.Deductions, deductionsList); 
        }
    }
}
