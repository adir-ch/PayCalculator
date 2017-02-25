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
        public override ILocation CreateLocation(string locationName)
        {
            throw new NotImplementedException();
        }
    }
}
