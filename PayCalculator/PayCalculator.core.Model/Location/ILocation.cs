using PayCalculator.core.Model.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayCalculator.core.Model.Location
{
    public interface ILocation
    {
        string LocationName { get; set; }
        ISalaryStrategy GetLocationSalaryStrategy(); 
    }
}
