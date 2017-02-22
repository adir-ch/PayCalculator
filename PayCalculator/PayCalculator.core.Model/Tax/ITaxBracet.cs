using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.Model.Tax
{
    public interface ITaxBracet
    {
        bool CanApplyBracet(decimal taxableIncome);
        decimal CalculateTaxBracet(decimal taxableIncome);
    }
}
