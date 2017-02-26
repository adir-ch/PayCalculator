using PayCalculator.core.Model.Location;
using PayCalculator.core.Model.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Location
{
    public class GermanyLocation : ILocation
    {
        public string LocationName { get; set; }

        public GermanyLocation()
        {
            LocationName = "Germany";  // take the value for DB
        }

        public ISalaryStrategy GetLocationSalaryStrategy()
        {
            throw new NotImplementedException();
        }
    }
}
