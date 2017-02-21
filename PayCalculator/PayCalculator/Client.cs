using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayCalculator
{
    class Client
    {
        static void Main(string[] args)
        {
            string employeeName;
            string location;
            string grossSalary;
            ReadDataFromConsole(out employeeName, out location, out grossSalary);

            Client client = new Client();
            string employeeReport = "working on it"; 

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
