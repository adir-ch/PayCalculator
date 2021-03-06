﻿using PayCalculator.core.Model.Location;
using PayCalculator.core.Model.Salary;
using PayCalculator.Infra.IoC;

namespace PayCalculator.Ext.BusinessObjects.Location
{
    public class AustraliaLocation : ILocation
    {
        public string LocationName { get; set; }

        public AustraliaLocation()
        {
            LocationName = "Australia"; // take the value for DB
        }

        public ISalaryStrategy GetLocationSalaryStrategy()
        {
            var salaryStrategy = Injector.Instance.Inject<ISalaryStrategy>("AustraliaSalaryStrategy");
            return salaryStrategy;
        }
    }
}
