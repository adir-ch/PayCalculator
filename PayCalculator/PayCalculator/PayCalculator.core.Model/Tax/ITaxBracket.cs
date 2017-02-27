
namespace PayCalculator.core.Model.Tax
{
    public interface ITaxBracket
    {
        bool CanApplyBracket(decimal taxableIncome);
        decimal CalculateTaxBracket(decimal taxableIncome);
        bool IsInBracket(decimal taxableIncome);
    }
}
