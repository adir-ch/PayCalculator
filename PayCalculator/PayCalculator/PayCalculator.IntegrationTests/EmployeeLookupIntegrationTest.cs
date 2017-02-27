using NUnit.Framework;
using PayCalculator.Contracts.Employee;
using PayCalculator.Infra.IoC;
using PayCalculator.Infra.WebApi;
using System;
using System.Collections.Generic;

namespace PayCalculator.IntegrationTests
{
    [TestFixture]
    public class EmployeeLookupIntegrationTest
    {
        private PayCalculatorWebApi _webApi;
        private Injector _injector;
        private string _employeeName;
        private EmployeeAddServiceRequest _employeeAddRequest;
        private EmployeeCalculateSalaryServiceRequest _employeeCalcSalaryRequest;
        private EmployeeLookupServiceRequest _employeeLookupRequest;
        private EmployeeLookupServiceResponse _expectedResponse; 

        [OneTimeSetUp]
        public void Init()
        {
            _employeeName = "Adir";
            _injector = Injector.Instance;
            _webApi = PayCalculatorWebApi.Instance;
            _employeeAddRequest = BuildEmployeeAddRequest();
            _employeeCalcSalaryRequest = BuildEmployeeCalcSalaryRequest();
            _employeeLookupRequest = BuildEmployeeLookupRequest();
            _expectedResponse = BuildEmployeeLookupExpectedResponse(); 
        }

        [Test]
        public void LookupEmployeeIntegrationTest()
        {
            var addResponse = _webApi.CallService(_employeeAddRequest);
            Assert.That(addResponse.Status, Is.True);

            var calcSalaryResponse = _webApi.CallService(_employeeCalcSalaryRequest);
            Assert.That(calcSalaryResponse.Status, Is.True);

            var lookupResponse = _webApi.CallService(_employeeLookupRequest) as EmployeeLookupServiceResponse;
            Assert.That(lookupResponse.Status, Is.EqualTo(_expectedResponse.Status));
            Assert.That(lookupResponse.ServiceName, Is.EqualTo(_expectedResponse.ServiceName));
            Assert.That(lookupResponse.RequestId, Is.EqualTo(_expectedResponse.RequestId));
            Assert.That(lookupResponse.NetAnnualSalary, Is.EqualTo(_expectedResponse.NetAnnualSalary));
            Assert.That(lookupResponse.TaxableIncome, Is.EqualTo(_expectedResponse.TaxableIncome));
            Assert.That(lookupResponse.Deductions, Is.EqualTo(_expectedResponse.Deductions)); 
        }

        private EmployeeLookupServiceRequest BuildEmployeeLookupRequest()
        {
            return new EmployeeLookupServiceRequest()
            {
                EmployeeName = _employeeName,
                ServiceName = "EmployeeLookupService",
                RequestId = "12345"
            };
        }

        private EmployeeLookupServiceResponse BuildEmployeeLookupExpectedResponse()
        {
            var deductions = new List<Tuple<string, decimal>>()
            {
                Tuple.Create<string, decimal>("Superannuation", (decimal)17351.600000),
                Tuple.Create<string, decimal>("Income Tax", (decimal)55424),
                Tuple.Create<string, decimal>("Medicare Levy", (decimal)3653),
                Tuple.Create<string, decimal>("Temporary Budget Repair Levy", (decimal)53)
            };

            return new EmployeeLookupServiceResponse()
            {
                Status = true,
                ServiceName = "EmployeeLookupService",
                RequestId = "12345",
                EmployeeName = _employeeName,
                GrossSalary = 200000,
                TaxableIncome = 182648.4M,
                NetAnnualSalary = 123518.4M,
                Deductions = deductions 
            };
        }

        private EmployeeAddServiceRequest BuildEmployeeAddRequest()
        {
            return new EmployeeAddServiceRequest()
            {
                EmployeeName = _employeeName,
                EmployeeLocation = "Australia",
                GrossSalary = "200000"
            };
        }

        private EmployeeCalculateSalaryServiceRequest BuildEmployeeCalcSalaryRequest()
        {
            return new EmployeeCalculateSalaryServiceRequest()
            {
                EmployeeName = _employeeName,
                ServiceName = "EmployeeCalculateSalaryService",
                RequestId = "12345"
            };
        }

    }
}
