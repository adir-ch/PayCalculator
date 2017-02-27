
namespace PayCalculator.core.Model.Salary
{
    public interface ISalaryStrategy
    {
        decimal GrossSalary { get; set; }
        ISalary Execute();
    }
}
