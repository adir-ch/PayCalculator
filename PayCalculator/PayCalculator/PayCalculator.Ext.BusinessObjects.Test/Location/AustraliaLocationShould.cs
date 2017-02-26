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

namespace PayCalculator.Ext.BusinessObjects.Test.Location
{
    [TestFixture]
    public class AustraliaLocationShould
    {
        private AustraliaLocation _australiaLocation;
        private Mock<ISalaryStrategy> _salaryStrategyMock;
        private Injector _injector;

        [OneTimeSetUp]
        public void Init()
        {
            _salaryStrategyMock = new Mock<ISalaryStrategy>();
            _injector = Injector.Instance;
            _injector.RegisterInstance<ISalaryStrategy>(_salaryStrategyMock.Object, "AustraliaSalaryStrategy");

            _australiaLocation = new AustraliaLocation();
            string locationName = "Australia";
            _australiaLocation.LocationName = locationName;
        }

        [Test]
        public void SetLocationNameToAustralia()
        {
            string locationName = "Australia";
            _australiaLocation.LocationName = locationName;
            Assert.AreEqual(locationName, _australiaLocation.LocationName);
        }

        [Test]
        public void ReturnAustraliasSalaryStrategy()
        {
            var salaryStrategy = _australiaLocation.GetLocationSalaryStrategy();
            Assert.That(salaryStrategy, Is.TypeOf(typeof(AustraliaSalaryStrategy)));
        }
    }
}
