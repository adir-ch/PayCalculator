using PayCalculator.core.Model.Common;

namespace PayCalculator.Infra.DataAccess
{
    public interface IDB
    {
        bool Create(string key, IDBEntity entity);
        bool CreateOrUpdate(string key, IDBEntity entity);
        IDBEntity Read(string key);
        bool Update(string key, IDBEntity entity);
        bool Delete(string key);

    }
}
