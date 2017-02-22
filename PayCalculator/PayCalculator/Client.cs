using log4net;
using PayCalculator.Contracts.Common;
using PayCalculator.Contracts.Employee;
using PayCalculator.Infra.WebApi;
using System;
using System.Collections.Generic;
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
            IServiceRequest employeeLookupRequest = new EmployeeLookupServiceRequest()
            {
                EmployeeName = employeeName
            };

            var employeeLookupResponse = PayCalculatorWebApi.Instance.CallService(employeeLookupRequest);
            _log.InfoFormat(formatResponse(employeeLookupResponse));
            return GenerateEmployeeSalaryReport(employeeLookupResponse as EmployeeLookupServiceResponse); 
        }

        private string GenerateEmployeeSalaryReport(EmployeeLookupServiceResponse response)
        {
            StringBuilder output = new StringBuilder();
            output.Append(String.Format("Name: {0}{1}", response.EmployeeName, System.Environment.NewLine));
            output.Append(String.Format("Employee location: {0}{1}", response.Location, System.Environment.NewLine));
            output.Append(String.Format("Gross Salary: ${0}{1}", Math.Round(response.GrossSalary, 2).ToString("N2"), System.Environment.NewLine));
            output.Append(System.Environment.NewLine);
            output.Append(String.Format("Taxable Income: ${0:00}{1}", Math.Round(response.TaxableIncome, 2).ToString("N2"), System.Environment.NewLine));
            output.Append(System.Environment.NewLine);
            output.Append(String.Format("Deductions: {0}", System.Environment.NewLine));
            output.Append(BuildSalaryReportDeductions(response.Deductions));
            output.Append(System.Environment.NewLine);
            output.Append(String.Format("Net annual salary: ${00:00}{1}", Math.Round(response.NetAnnualSalary, 2).ToString("N2"), System.Environment.NewLine));
            return output.ToString();
        }

        private string BuildSalaryReportDeductions(IList<Tuple<string, decimal>> deductions)
        {
            StringBuilder output = new StringBuilder();
            foreach (var deduction in deductions)
            {
                if (deduction.Item1 == "Superannuation")
                {
                    output.Append(String.Format("{0}: ${1:00}", deduction.Item1, deduction.Item2.ToString("N2")));
                }
                else
                {
                    output.Append(String.Format("{0}: ${1:00}", deduction.Item1, Math.Round(deduction.Item2).ToString("N2")));
                }

                output.Append(System.Environment.NewLine);
            }

            return output.ToString();
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
