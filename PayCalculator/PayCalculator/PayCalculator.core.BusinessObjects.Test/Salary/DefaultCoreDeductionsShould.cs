using NUnit.Framework;
using PayCalculator.core.BusinessObjects.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.BusinessObjects.Test.Salary
{
    [TestFixture]
    public class DefaultCoreDeductionsShould
    {
        private DefaultCoreDeductions _deductions;

        [OneTimeSetUp]
        public void Init()
        {
            _deductions = new DefaultCoreDeductions(); 
        }

        [Test]
        public void ReturnDeductionReport()
        {
            Assert.IsNotEmpty(_deductions.GetDeductionsReport());
        }
    }
}
