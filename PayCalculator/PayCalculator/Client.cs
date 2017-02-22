using log4net;
using PayCalculator.Contracts.Common;
using PayCalculator.Contracts.Employee;
using PayCalculator.Infra.WebApi;
using System;

namespace PayCalculator
{
    class Client
    {
        // this is actually a poor man way to mimic a REST API request
        private PayCalculatorWebApi _webApi = PayCalculatorWebApi.Instance;
        private readonly ILog _log = LogManager.GetLogger("ClientLogger");

        public Client()
        {
            _log.Debug("Starting Pay calculator client");
        }

        public void AddNewEmployee(string employeeName, string location, string grossSalary)
        {
            _log.DebugFormat("Adding new employee: {0}", employeeName);
            IServiceRequest addEmployeeRequest = new EmployeeAddServiceRequest()
            {
                EmployeeName = employeeName,
                EmployeeLocation = location,
                GrossSalary = grossSalary
            };

            var addEmployeeResponse = PayCalculatorWebApi.Instance.CallService(addEmployeeRequest);
            _log.Info(formatResponse(addEmployeeResponse));
        }

        public void CalculateEmployeeNetSalary(string employeeName)
        {
            _log.DebugFormat("Calculating employee net annual salary: {0}", employeeName); 
            
        }

        public string PrintEmployeeSalaryReport(string employeeName)
        {
            _log.DebugFormat("Generating salary report for employee: {0}", employeeName); 
            return String.Empty; 
        }

        private string formatResponse(IServiceResponse response)
        {
            return String.Format("got response back: {0}", response.DumpResponseHeader());
        }
        
        static void Main(string[] args)
        {
            string employeeName;
            string location;
            string grossSalary;
            ReadDataFromConsole(out employeeName, out location, out grossSalary);

            Client client = new Client();
            client.AddNewEmployee(employeeName, location, grossSalary);
            client.CalculateEmployeeNetSalary(employeeName); // going lazy 
            var employeeReport = client.PrintEmployeeSalaryReport(employeeName);

            Console.WriteLine("---------------------");
            Console.WriteLine(employeeReport);
            Console.ReadLine();
        }

        private static void ReadDataFromConsole(out string employeeName, out string location, out string grossSalary)
        {
            //Console.Write("Employee name: ");
            employeeName = "ADIR";  //Console.ReadLine();

            //Console.Write("Employee location: ");
            location = "Australia";  //Console.ReadLine();

            //Console.Write("Gross Salary: ");
            grossSalary = "200,000"; // Console.ReadLine();
        }
    }
}
