using Microsoft.Practices.Unity;
using System;
using System.Threading;

namespace PayCalculator.Infra.WebApi
{
    public class PayCalculatorWebApi
    {
        private static readonly Lazy<PayCalculatorWebApi> _instance = new Lazy<PayCalculatorWebApi>(() => new PayCalculatorWebApi());
        //private static PayCalculatorWebApi _instance;
        private readonly Injector _injector;

        public static PayCalculatorWebApi Instance
        {
            get { return _instance.Value; }
        }

        private PayCalculatorWebApi()
        {
            _injector = IoC.Injector.Instance;
        }

        public IServiceResponse CallService(IServiceRequest request)
        {
            IBusinessService service;
            switch (request.ServiceName)
            {
                case "EmployeeAddService":
                    {
                        service = _injector.Inject<IBusinessService>("EmployeeAddService");
                        break;
                    }

                case "EmployeeCalculateSalaryService":
                    {
                        service = _injector.Inject<IBusinessService>("EmployeeCalculateSalaryService");
                        break;
                    }

                case "EmployeeLookupService":
                    {
                        service = _injector.Inject<IBusinessService>("EmployeeLookupService");
                        break;
                    }

                default:
                    throw new NotImplementedException();
            }

            return service.Execute(request);
        }
    }
}
