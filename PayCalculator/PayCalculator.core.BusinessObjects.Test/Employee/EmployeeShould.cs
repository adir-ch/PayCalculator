using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cbc = PayCalculator.core.BusinessObjects.Employee;

namespace PayCalculator.core.BusinessObjects.Test.Employee
{
    [TestFixture]
    public class EmployeeShould
    {
        [Test]
        public void InitEmployeeObject([Values("Adir1", "Adir2")] string name, 
                                       [Values("Australia", "NewZealand")] string location,
                                       [Values("200000", "-250000", "0")] string grossSalary)
        {
            cbc.Employee employee = new cbc.Employee();
            employee.Init(name, location, grossSalary); 

            Assert.AreEqual(employee.Name, name);
            Assert.AreEqual(employee.Location, location);
            Assert.AreEqual(employee.Salary.GrossSalary , grossSalary);
        }
    }
}
