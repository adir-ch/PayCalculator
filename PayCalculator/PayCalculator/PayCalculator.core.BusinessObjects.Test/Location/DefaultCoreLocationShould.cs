using NUnit.Framework;
using PayCalculator.core.BusinessObjects.Location;
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
        private Injector _injector; 

        [OneTimeSetUp]
        public void Init()
        {
            _injector = Injector.Instance;
            _defaultCoreLocation = new DefaultCoreLocation(); 
        }

        [Test]
        public void StoreLocationName()
        {
            string locationName = "AnyLocation";
            _defaultCoreLocation.LocationName = locationName;

            Assert.AreEqual(locationName, _defaultCoreLocation.LocationName);
        }
    }
}
