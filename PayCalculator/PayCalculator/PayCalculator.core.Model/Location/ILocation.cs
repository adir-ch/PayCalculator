using PayCalculator.core.Model.Salary;

namespace PayCalculator.core.Model.Location
{
    public interface ILocation
    {
        string LocationName { get; set; }
        ISalaryStrategy GetLocationSalaryStrategy(); 
    }
}
