using PayCalculator.core.Model.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.BusinessObjects.Location
{
    public class LocationFactory : ILocationFactory
    {
        // implementing some kind of caching since location does not need to be 
        // created every time (for a specific location name)
        private IDictionary<string, ILocation> _locationsMap;

        public LocationFactory()
        {
            _locationsMap = new Dictionary<string, ILocation>();
        }

        public ILocation CreateLocation(string locationName)
        {
            ILocation location;
            if (_locationsMap.TryGetValue(locationName, out location) == false)
            {
                location = new DefaultCoreLocation();
                _locationsMap.Add(locationName, location); // add for next time
            }

            return location; 
        }
    }
}
