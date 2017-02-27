using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.Model.Tax
{
    public interface ITaxBracket
    {
        bool CanApplyBracket(decimal taxableIncome);
        decimal CalculateTaxBracket(decimal taxableIncome);
        bool IsInBracket(decimal taxableIncome);
    }
}
