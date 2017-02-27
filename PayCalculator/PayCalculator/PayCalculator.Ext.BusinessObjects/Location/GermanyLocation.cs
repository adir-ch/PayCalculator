using PayCalculator.core.Model.Location;
using PayCalculator.core.Model.Salary;
using PayCalculator.Infra.IoC;

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
            var salaryStrategy = Injector.Instance.Inject<ISalaryStrategy>("GermanySalaryStrategy");
            return salaryStrategy;
        }
    }
}
