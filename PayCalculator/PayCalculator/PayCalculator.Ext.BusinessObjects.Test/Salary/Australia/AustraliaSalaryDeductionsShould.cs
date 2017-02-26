using Moq;
using NUnit.Framework;
using PayCalculator.core.BusinessObjects.Salary;
using PayCalculator.core.BusinessObjects.Tax;
using PayCalculator.core.Model.Salary;
using PayCalculator.core.Model.Tax;
using PayCalculator.Ext.BusinessObjects.Salary.Australia;
using PayCalculator.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayCalculator.Ext.BusinessObjects.Test.Salary.Australia;

namespace PayCalculator.core.BusinessObjects.Test.Salary
{
    [TestFixture]
    public class DefaultCoreDeductionsShould
    {
        private AustraliaSalaryDeductions _deductions;
        private Injector _injector;

        [OneTimeSetUp]
        public void Init()
        {
            _injector = Injector.Instance;
            _deductions = new AustraliaSalaryDeductions(); 
        }
    }
}
