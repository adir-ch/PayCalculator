using NUnit.Framework;
using PayCalculator.core.BusinessObjects.Location;

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
            Assert.AreEqual(createdLocation.LocationName, "DefaultCoreLocation");
        }

        [Test]
        public void ReturnSameDefaultCoreLocationIfAlreadyCreated([Values("location1", "location2")] string location)
        {
            var createdLocation = _locationFactory.CreateLocation(location);
            var existingLocation = _locationFactory.CreateLocation(location);
            Assert.AreEqual(createdLocation, existingLocation);
        }
    }
}
