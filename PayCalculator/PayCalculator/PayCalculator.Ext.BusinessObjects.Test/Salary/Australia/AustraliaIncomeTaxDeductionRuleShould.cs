using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayCalculator.Ext.BusinessObjects.Salary.Australia.DeductionRules; 

namespace PayCalculator.Ext.BusinessObjects.Test.Salary.Australia
{
    [TestFixture]
    public class AustraliaIncomeTaxDeductionRuleShould
    {
        private IncomeTaxDeductionRule _deductionRule;

        [OneTimeSetUp]
        public void Init()
        {
            _deductionRule = new IncomeTaxDeductionRule(); 
        }

        [Test]
        public void SetAustralianTaxRuleDescription()
        {
            Assert.AreEqual(_deductionRule.GetRuleDescription(), "Income Tax"); 
        }
    }
}
