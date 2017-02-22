using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
