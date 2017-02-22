using PayCalculator.core.DAO.Common;
using PayCalculator.core.Model.Employee;
using PayCalculator.Infra.IoC;
using cbc = PayCalculator.core.BusinessComponents.Employee;

namespace PayCalculator.core.DAO.Employee
{
    public class EmployeeDao : EntityDaoBase, IEmployeeDao
    {
        public void Save(IEmployee employee)
        {
            _db.CreateOrUpdate(employee.Name, employee);
        }

        public bool Delete(string employeeName)
        {
            return _db.Delete(employeeName);
        }

        public IEmployee GetOrCreateNew(string employeeName)
        {
            var employee = Get(employeeName);
            if (employee == null)
            {
                employee = Injector.Instance.Inject<IEmployee>();
            }

            return employee;
        }

        public IEmployee Get(string employeeName)
        {
            var employee = _db.Read(employeeName) as cbc.Employee;
            return employee;
        }
    }
}
