using PayCalculator.core.Model.Common;
using PayCalculator.core.Model.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.Model.Employee
{
    public interface IEmployee : IDBEntity
    {

        string Name { get; set; }
        string Location { get; set; }
        ISalary EmployeeSalary { get; set; }

        void Init(string name, string location, string grossSalary);
        ISalary CalculateNetSalary();
    }
}
