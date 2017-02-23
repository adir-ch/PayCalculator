using NUnit.Framework;
using PayCalculator.core.BusinessComponents.Tax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.BusinessObjects.Test.Tax
{
    [TestFixture]
    public class DefaultTaxBracketShould
    {
        [Test]
        [TestCase(0, 100, 0.5, 50, ExpectedResult = true)]
        public bool CheckIfTaxableIncomeInTaxBracet(decimal lowerBand, decimal upperBand, decimal taxRate, decimal taxableIncome)
        {
            DefaultTaxBracket bracet = new DefaultTaxBracket(lowerBand, upperBand, taxRate);
            return bracet.IsInBracket(taxableIncome); 
        }
    }
}
