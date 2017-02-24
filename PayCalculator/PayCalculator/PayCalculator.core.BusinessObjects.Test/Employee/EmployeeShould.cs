using Moq;
using NUnit.Framework;
using PayCalculator.core.BusinessObjects.Location;
using PayCalculator.core.Model.Location;
using PayCalculator.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bc = PayCalculator.core.BusinessObjects.Employee;

namespace PayCalculator.core.BusinessObjects.Test.Employee
{
    [TestFixture]
    public class EmployeeShould
    {
        private bc.Employee _employee;
        private DefaultCoreLocation _location; 
        private Mock<ILocationFactory> _locationFactoryMock;
        private Injector _injector; 


        [OneTimeSetUp]
        public void Init()
        {
            _locationFactoryMock = new Mock<ILocationFactory>(); 
            _injector.RegisterInstance<ILocationFactory>(_locationFactoryMock.Object, "LocationFactory");
            _location = new DefaultCoreLocation(); 
            _employee = new bc.Employee(); 
        }

        [Test]
        public void InitEmployeeObject([Values("Adir")] string name, 
                                       [Values("Australia", "NewZealand", "France")] string location,
                                       [Values("200000", "-250000", "0")] string grossSalary)
        {
            _employee.Init(name, location, grossSalary);

            Assert.AreEqual(_employee.Name, name);
            Assert.AreEqual(_employee.Location, location);
            Assert.AreEqual(_employee.EmployeeSalary.GrossSalary.ToString(), grossSalary);
        }

        [Test]
        public void ThrowAnExceptionOnIncorrectSalaryFormatInput ([Values("Adir")] string name,
                                                                  [Values("Australia")] string location,
                                                                  [Values("INCORRECT")] string grossSalary)
        {
            Assert.Throws<FormatException>(() => { _employee.Init(name, location, grossSalary); });
        }

        [Test]
        public void CallLocationFactoryToCreateSalaryStrategyOnInit()
        {
            _locationFactoryMock.Setup(f => f.CreateLocation(It.IsAny<string>())).Returns(_location); 
            _employee.Init("Adir", "Australia", "200000");
            _locationFactoryMock.Verify(f => f.CreateLocation(It.IsAny<string>()), Times.Once());
        }
    }
}
