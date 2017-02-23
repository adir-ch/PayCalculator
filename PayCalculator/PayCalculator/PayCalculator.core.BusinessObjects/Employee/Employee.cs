﻿using log4net;
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
        public ISalary EmployeeSalary { get; set; }

        public Employee()
        {
            EmployeeSalary = new Salary.Salary(); 
        }

        public void Init(string name, string location, string grossSalary)
        {
            Name = name;
            Location = location;
            EmployeeSalary.GrossSalary = decimal.Parse(grossSalary); ; 
            _log.DebugFormat("Init employee - Name: {0}, Location: {1}", Name, Location);
        }

        public ISalary CalculateNetSalary()
        {
            throw new NotImplementedException();
        }
    }
}