using log4net;
using PayCalculator.core.Model.Employee;
using PayCalculator.core.Model.Location;
using PayCalculator.core.Model.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.BusinessObjects.Employee
{
    public class Employee : IEmployee
    {
        protected readonly ILog _log = LogManager.GetLogger("Employee");

        public string Name { get; set; }
        public string Location { get; set; }
        public ISalary Salary { get; set; }

        public Employee()
        {
        }

        public void Init(string name, string location, string grossSalary)
        {
            Name = name;
            Location = location;
            Salary.GrossSalary = grossSalary; 
            _log.DebugFormat("Init employee - Name: {0}, Location: {1}, Gross salary={2}", Name, Location, Salary.GrossSalary);
        }


        public ISalary CalculateNetSalary()
        {
            throw new NotImplementedException();
        }
    }
}
