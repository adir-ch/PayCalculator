using Moq;
using NUnit.Framework;
using PayCalculator.core.BusinessObjects.Location;
using PayCalculator.core.Model.Location;
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
    public class LocationFactoryExtShould
    {
        private LocationFactoryExt _locationFactory;
        private Mock<ILocation> _specificLocation;
        private Injector _injector; 

        [OneTimeSetUp]
        public void Init()
        {
            _specificLocation = new Mock<ILocation>();
            _injector = Injector.Instance; 
            _locationFactory = new LocationFactoryExt();
        }

        [SetUp] 
        public void BeforeEach()
        {
            _injector.RegisterInstance<ILocation>(new AustraliaLocation(), "AustraliaLocation");
            _injector.RegisterInstance<ILocation>(new GermanyLocation(), "GermanyLocation");
            _injector.RegisterInstance<ILocation>(new DefaultCoreLocation(), "DefaultCoreLocation");
        }

        [Test]
        [TestCase("Australia", ExpectedResult = "Australia")]
        [TestCase("Germany", ExpectedResult = "Germany")]
        [TestCase("USA", ExpectedResult = "DefaultCoreLocation")]
        public string CreateAndAddNewLocation(string location)
        {
            var createdLocation = _locationFactory.CreateLocation(location);
            return createdLocation.LocationName;
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
