using PayCalculator.core.Model.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.Model.Employee
{
    public interface IEmployeeDao
    {
        void Save(IEmployee employee);
        bool Delete(string employeeName);
        IEmployee GetOrCreateNew(string employeeName);
        IEmployee Get(string employeeName);
    }
}
