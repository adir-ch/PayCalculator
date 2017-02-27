using NUnit.Framework;
using PayCalculator.Contracts.Employee;
using PayCalculator.Infra.IoC;
using PayCalculator.Infra.WebApi;


namespace PayCalculator.IntegrationTests
{
    [TestFixture]
    public class EmployeeCalculateSalaryIntegrationTest
    {
        private PayCalculatorWebApi _webApi;
        private Injector _injector;
        private string _employeeName;
        private EmployeeAddServiceRequest _employeeAddRequest;
        private EmployeeCalculateSalaryServiceRequest _employeeCalcSalaryRequest;
        private EmployeeCalculateSalaryServiceResponse _expectedResponse;

        [OneTimeSetUp]
        public void Init()
        {
            _employeeName = "Adir";
            _injector = Injector.Instance;
            _webApi = PayCalculatorWebApi.Instance;
            _employeeAddRequest = BuildEmployeeAddRequest();
            _employeeCalcSalaryRequest = BuildEmployeeCalcSalaryRequest();
            _expectedResponse = EmployeeCalculateSalaryExpectedRespose();
        }

        [Test]
        public void EmployeeIntegrationTest()
        {
            var addResponse = _webApi.CallService(_employeeAddRequest);
            Assert.That(addResponse.Status, Is.True);

            var calcSalaryResponse = _webApi.CallService(_employeeCalcSalaryRequest) as EmployeeCalculateSalaryServiceResponse;
            Assert.That(calcSalaryResponse.Status, Is.EqualTo(_expectedResponse.Status));
            Assert.That(calcSalaryResponse.ServiceName, Is.EqualTo(_expectedResponse.ServiceName));
            Assert.That(calcSalaryResponse.NetAnnualSalary, Is.EqualTo(_expectedResponse.NetAnnualSalary));
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

        private EmployeeCalculateSalaryServiceResponse EmployeeCalculateSalaryExpectedRespose()
        {
            return new EmployeeCalculateSalaryServiceResponse()
            {
                Status = true,
                ServiceName = "EmployeeCalculateSalaryService",
                RequestId = "12345",
                NetAnnualSalary = 123518.4M
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
    }
}
