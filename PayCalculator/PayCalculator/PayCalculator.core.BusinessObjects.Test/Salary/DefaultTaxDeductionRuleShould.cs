using NUnit.Framework;
using PayCalculator.core.BusinessComponents.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.BusinessObjects.Test.Salary
{
    [TestFixture]
    public class DefaultTaxDeductionRuleShould
    {
        private DefaultTaxDeductionRule _defaultTaxDeductionRule;

        [OneTimeSetUp]
        public void Init()
        {
            _defaultTaxDeductionRule = new DefaultTaxDeductionRule(); 
        }

        [Test]
        public void NotReturnEmpltyDescription()
        {
            Assert.IsTrue(String.IsNullOrEmpty(_defaultTaxDeductionRule.GetRuleDescription()) == false);
        }

        [Test]
        public void ApplyRuleOnTaxableIncome([Values(200000)] decimal taxableIncome)
        {
            var calculatedTax = _defaultTaxDeductionRule.Apply(taxableIncome);
            Assert.AreEqual(calculatedTax, 55424); 
        }
    }
}
