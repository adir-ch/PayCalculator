
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
