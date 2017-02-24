using PayCalculator.core.Model.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.BusinessObjects.Location
{
    public class LocationFactory
    {
        public ILocation CreateLocation(string locationName)
        {
            var location = new DefaultCoreLocation();
            location.LocationName = locationName;
            return location; 
        }
    }
}
