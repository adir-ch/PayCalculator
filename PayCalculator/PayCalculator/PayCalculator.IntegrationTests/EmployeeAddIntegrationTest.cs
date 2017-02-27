using NUnit.Framework;
using PayCalculator.Contracts.Employee;
using PayCalculator.Infra.IoC;
using PayCalculator.Infra.WebApi;

namespace PayCalculator.IntegrationTests
{
    [TestFixture]
    public class EmployeeAddIntegrationTest
    {
        private PayCalculatorWebApi _webApi;
        private Injector _injector;
        private EmployeeAddServiceRequest _sentRequest;
        private EmployeeAddServiceResponse _expectedResponse;

        [OneTimeSetUp]
        public void Init()
        {
            _injector = Injector.Instance; 
            _webApi = PayCalculatorWebApi.Instance;
            _sentRequest = BuildEmployeeAddRequest();
            _expectedResponse = BuildEmployeeAddExpectedRespose(); 
        }

        [Test]
        public void AddEmployeeIntegrationTest()
        {
            var response = _webApi.CallService(_sentRequest) as EmployeeAddServiceResponse;
            Assert.That(response.RequestId, Is.EqualTo(_expectedResponse.RequestId));
            Assert.That(response.Status, Is.EqualTo(_expectedResponse.Status));
            Assert.That(response.Message, Is.EqualTo(_expectedResponse.Message));
            Assert.That(response.ServiceName, Is.EqualTo(_expectedResponse.ServiceName)); 
        }

        private EmployeeAddServiceResponse BuildEmployeeAddExpectedRespose()
        {
            return new EmployeeAddServiceResponse()
            {
                Status = true, 
                ServiceName = "EmployeeAddService",
                Message = "Employee added successfully",
                RequestId = "12345"
            };
        }

        private EmployeeAddServiceRequest BuildEmployeeAddRequest()
        {
            return new EmployeeAddServiceRequest()
            {
                EmployeeName = "Adir",
                EmployeeLocation = "Australia",
                GrossSalary = "200000",
                RequestId = "12345"
            };
        }
    }
}
