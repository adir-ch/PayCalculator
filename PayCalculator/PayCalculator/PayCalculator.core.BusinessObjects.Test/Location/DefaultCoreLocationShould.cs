using Moq;
using NUnit.Framework;
using PayCalculator.core.BusinessObjects.Location;
using PayCalculator.core.BusinessObjects.Salary;
using PayCalculator.core.Model.Salary;
using PayCalculator.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.BusinessObjects.Test.Location
{
    [TestFixture]
    public class DefaultCoreLocationShould
    {
        private DefaultCoreLocation _defaultCoreLocation;
        private Mock<ISalaryStrategy> _salaryStrategyMock; 
        private Injector _injector; 

        [OneTimeSetUp]
        public void Init()
        {
            _salaryStrategyMock = new Mock<ISalaryStrategy>(); 
            _injector = Injector.Instance;
            _injector.RegisterInstance<ISalaryStrategy>(_salaryStrategyMock.Object, "DefaultCoreSalaryStrategy");

            _defaultCoreLocation = new DefaultCoreLocation(); 
        }

        [Test]
        public void StoreLocationName()
        {
            string locationName = "AnyLocation";
            _defaultCoreLocation.LocationName = locationName;

            Assert.AreEqual(locationName, _defaultCoreLocation.LocationName);
        }

        [Test]
        public void ReturnDefaultCoreLocationStrategy()
        {
            var salaryStrategy = _defaultCoreLocation.GetLocationSalaryStrategy();
            Assert.AreEqual(salaryStrategy, _salaryStrategyMock.Object);
        }

        [Test]
        public void ReturnDefaultCoreLocationName()
        {
            Assert.AreEqual(_defaultCoreLocation.LocationName, "DefaultCoreLocation");
        }

    }
}
