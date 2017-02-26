using PayCalculator.core.BusinessObjects.Location;
using PayCalculator.core.Model.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Location
{
    public class LocationFactoryExt : LocationFactory
    {
        protected override ILocation GenerateLocationObject(string locationName)
        {
            return new DefaultCoreLocation();
        }
    }
}
