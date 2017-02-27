
namespace PayCalculator.core.Model.Tax
{
    public interface ITaxCalculator
    {
        decimal CalculateTax(decimal taxableIncome);
    }
}
