using Moq;
using NUnit.Framework;
using PayCalculator.core.BusinessObjects.Location;
using PayCalculator.core.Model.Location;
using PayCalculator.core.Model.Salary;
using PayCalculator.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bc = PayCalculator.core.BusinessObjects.Employee;
using sbc = PayCalculator.core.BusinessObjects.Salary;

namespace PayCalculator.core.BusinessObjects.Test.Employee
{
    [TestFixture]
    public class EmployeeShould
    {
        private bc.Employee _employee;
        private DefaultCoreLocation _location; 
        private Mock<ILocationFactory> _locationFactoryMock;
        private Mock<ISalaryStrategy> _salaryStrategyMock;
        private Injector _injector; 


        [OneTimeSetUp]
        public void Init()
        {
            _injector = Injector.Instance;
            _locationFactoryMock = new Mock<ILocationFactory>();
            _salaryStrategyMock = new Mock<ISalaryStrategy>(); 
            _injector.RegisterInstance<ILocationFactory>(_locationFactoryMock.Object, "LocationFactory");
            _injector.RegisterInstance<ISalaryStrategy>(_salaryStrategyMock.Object, "DefaultCoreSalaryStrategy");
            _location = new DefaultCoreLocation(); 
            _employee = new bc.Employee(_locationFactoryMock.Object);

            _locationFactoryMock.Setup(f => f.CreateLocation(It.IsAny<string>())).Returns(_location);
        }

        [Test]
        public void InitEmployeeObject([Values("Adir")] string name, 
                                       [Values("Australia", "NewZealand", "France")] string location,
                                       [Values("200000", "-250000", "0")] string grossSalary)
        {
            _employee.Init(name, location, grossSalary);

            Assert.AreEqual(_employee.Name, name);
            Assert.AreEqual(_employee.Location, location);
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
            _employee.Init("Adir", "Australia", "200000");
            _locationFactoryMock.Verify(f => f.CreateLocation(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void SetSalaryStrategyGrossSalary([Values("Adir")] string name, 
                                                 [Values("Australia")] string location,
                                                 [Values("200000", "0")] string grossSalary)
        {
            _salaryStrategyMock.SetupSet(st => st.GrossSalary=It.IsAny<decimal>()).Verifiable();
            _employee.Init(name, location, grossSalary);
            _salaryStrategyMock.VerifySet(prop => prop.GrossSalary = It.IsAny<decimal>()); 
        }

        [Test]
        public void InvokeSalaryCalculationUponRequest()
        {
            _salaryStrategyMock.Setup(f => f.Execute()).Returns(new sbc.Salary());
            _employee.Init("Adir", "Australia", "200000");
            _employee.CalculateNetSalary();
            _salaryStrategyMock.Verify(f => f.Execute(), Times.Once()); 
        }

        [Test]
        public void SetEmployeeSalaryPropertyAfterSalaryCalculation()
        {
            ISalary salaryObj = new sbc.Salary();
            _salaryStrategyMock.Setup(f => f.Execute()).Returns(salaryObj);
            _employee.Init("Adir", "Australia", "200000");
            _employee.CalculateNetSalary();
            Assert.AreEqual(_employee.EmployeeSalary, salaryObj);
        }
    }
}
