using log4net;
using PayCalculator.Infra.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            Console.Write("Employee name: ");
            employeeName = Console.ReadLine();

            Console.Write("Employee location: ");
            location = Console.ReadLine();

            Console.Write("Gross Salary: ");
            grossSalary = Console.ReadLine();
        }
    }
}
