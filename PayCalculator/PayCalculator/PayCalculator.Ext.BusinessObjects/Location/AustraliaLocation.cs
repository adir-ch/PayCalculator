using PayCalculator.core.Model.Location;
using PayCalculator.core.Model.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Ext.BusinessObjects.Location
{
    public class AustraliaLocation : ILocation
    {
        public string LocationName { get; set; }

        public AustraliaLocation()
        {
            LocationName = "Australia"; 
        }

        public ISalaryStrategy GetLocationSalaryStrategy()
        {
            throw new NotImplementedException(); 
        }
    }
}
