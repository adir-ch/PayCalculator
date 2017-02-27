using NUnit.Framework;
using PayCalculator.core.BusinessObjects.Tax;

namespace PayCalculator.core.BusinessObjects.Test.Tax
{
    [TestFixture]
    public class DefaultTaxBracketShould
    {
        [Test]
        [TestCase(0, 100, 0.5, 50, ExpectedResult = true)]
        [TestCase(0, 100, 0.5, 300, ExpectedResult = false)]
        [TestCase(0, 100, 0.5, 0, ExpectedResult = true)]
        [TestCase(0, 100, 0.5, 100, ExpectedResult = true)]
        [TestCase(0, 100, 0.5, -10, ExpectedResult = false)]
        public bool CheckIfTaxableIncomeInTaxBracet(decimal lowerBand, decimal upperBand, decimal taxRate, decimal taxableIncome)
        {
            DefaultTaxBracket bracet = new DefaultTaxBracket(lowerBand, upperBand, taxRate);
            return bracet.IsInBracket(taxableIncome); 
        }

        [Test]
        [TestCase(0, 100, 0.5, 50, ExpectedResult = true)]
        [TestCase(0, 100, 0.5, 300, ExpectedResult = true)]
        [TestCase(0, 100, 0.5, 0, ExpectedResult = true)]
        [TestCase(50, 100, 0.5, 10, ExpectedResult = false)]
        public bool CheckIfBracetCanBeApplied(decimal lowerBand, decimal upperBand, decimal taxRate, decimal taxableIncome)
        {
            DefaultTaxBracket bracket = new DefaultTaxBracket(lowerBand, upperBand, taxRate);
            return bracket.CanApplyBracket(taxableIncome);
        }

        [Test]
        [TestCase(0, 100, 0.5, 50, ExpectedResult = 25)]
        [TestCase(0, 100, 0.5, 300, ExpectedResult = 50)]
        [TestCase(0, 100, 0.5, 0, ExpectedResult = 0)]
        [TestCase(11, 50, 0.5, 24, ExpectedResult = 7)]
        public decimal CalculateTaxBracket(decimal lowerBand, decimal upperBand, decimal taxRate, decimal taxableIncome)
        {
            DefaultTaxBracket bracket = new DefaultTaxBracket(lowerBand, upperBand, taxRate);
            return bracket.CalculateTaxBracket(taxableIncome);
        }
    }
}
