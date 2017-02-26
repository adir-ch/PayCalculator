using NUnit.Framework;
using PayCalculator.core.BusinessObjects.Location;
using PayCalculator.core.Model.Location;
using PayCalculator.Ext.BusinessObjects.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Test.Location
{
    [TestFixture]
    public class LocationFactoryExtShould
    {
        private LocationFactoryExt _locationFactory;

        [OneTimeSetUp]
        public void Init()
        {
            _locationFactory = new LocationFactoryExt();
        }

        [Test]
        public void CreateAndAddNewLocation([Values("Australia", "Germany", "USA")] string location)
        {
            var createdLocation = _locationFactory.CreateLocation(location);
            Assert.AreEqual(createdLocation.LocationName, "DefaultCoreLocation");
        }

        [Test]
        public void ReturnSameLocationIfAlreadyCreated([Values("Australia", "Germany", "USA")] string location)
        {
            var createdLocation = _locationFactory.CreateLocation(location);
            var existingLocation = _locationFactory.CreateLocation(location);
            Assert.AreEqual(createdLocation, existingLocation);
        }

        [Test]
        [TestCase("Australia", typeof(AustraliaLocation))]
        [TestCase("Germany", typeof(GermanyLocation))]
        [TestCase("USA", typeof(DefaultCoreLocation))]
        public void ReturnSpecificLocationInstance(string location, Type instanceType)
        {
            var createdObject = _locationFactory.CreateLocation(location);
            Assert.AreEqual(instanceType, createdObject.GetType());
        }
    }
}
