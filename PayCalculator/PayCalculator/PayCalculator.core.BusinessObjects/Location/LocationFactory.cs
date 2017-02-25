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

        // created the function as virtual to have an extension point without overriding the 
        // entire class implementation, only the location creation method. 
        public ILocation CreateLocation(string locationName)
        {
            ILocation location = RetriveExistingLocation(locationName);
            if (location != null)
            {
                return location; 
            }

            location = GenerateLocationObject(locationName);
            AddCreatedLocation(locationName, location); 
            return location; 
        }

        private ILocation RetriveExistingLocation(string locationName)
        {
            ILocation location; 
            _locationsMap.TryGetValue(locationName, out location);
            return location; 
        }

        private void AddCreatedLocation(string locationName, ILocation locationObject)
        {
            _locationsMap.Add(locationName, locationObject); // add for next time
        }

        protected virtual ILocation GenerateLocationObject(string locationName)
        {
            return new DefaultCoreLocation();
        }
    }
}
