using NUnit.Framework;
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
    }
}
