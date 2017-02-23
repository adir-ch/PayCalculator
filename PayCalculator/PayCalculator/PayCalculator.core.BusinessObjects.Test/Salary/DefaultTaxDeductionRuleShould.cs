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
        public void ReturnEmpltyDescription()
        {
            Assert.IsTrue(String.IsNullOrEmpty(_defaultTaxDeductionRule.GetRuleDescription()) == false);
        }

        [Test]
        public void ReturnDefaultTaxDeductionRuleDescription()
        {
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");
        }
    }
}
