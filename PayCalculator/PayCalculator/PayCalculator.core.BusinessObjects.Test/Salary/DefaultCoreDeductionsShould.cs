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
        private DeductionsBase _deductionsBase;

        [OneTimeSetUp]
        public void Init()
        {
            _deductionsBase = new DeductionsBase(); 
        }

        [Test]
        public void ReturnDeductionReport()
        {
            Assert.IsNotEmpty(_deductionsBase.GetDeductionsReport());
        }
    }
}
