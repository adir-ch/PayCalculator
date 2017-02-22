using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.Model.Location
{
    public interface ILocationFactory
    {
        ILocation CreateLocation(string locationName); 
    }
}
