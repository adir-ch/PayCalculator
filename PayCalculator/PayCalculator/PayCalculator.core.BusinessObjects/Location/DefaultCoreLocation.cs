using PayCalculator.core.Model.Location;
using PayCalculator.core.Model.Salary;
using PayCalculator.Infra.IoC;

namespace PayCalculator.core.BusinessObjects.Location
{
    public class DefaultCoreLocation : ILocation
    {
        public string LocationName { get; set; }
        
        public DefaultCoreLocation()
        {
            LocationName = "DefaultCoreLocation";
        }
        
        public ISalaryStrategy GetLocationSalaryStrategy()
        {
            var salaryStrategy = Injector.Instance.Inject<ISalaryStrategy>("DefaultCoreSalaryStrategy");
            return salaryStrategy;
        }
    }
}
