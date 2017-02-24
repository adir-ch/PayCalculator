using NUnit.Framework;
using PayCalculator.core.BusinessObjects.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.BusinessObjects.Test.Location
{
    [TestFixture]
    public class LocationFactoryShould
    {
        private LocationFactory _locationFactory;

        [OneTimeSetUp]
        public void Init()
        {
            _locationFactory = new LocationFactory();
        }

        [Test]
        public void CreateAndAddNewLocation([Values("location1", "location2")] string location)
        {
            var createdLocation = _locationFactory.CreateLocation(location);
            Assert.AreEqual(location, createdLocation.LocationName);
        }
    }
}
