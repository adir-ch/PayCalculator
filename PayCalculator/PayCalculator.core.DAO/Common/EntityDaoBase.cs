using PayCalculator.Infra.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.core.DAO.Common
{
    public class EntityDaoBase
    {
        protected IDB _db;

        public EntityDaoBase()
        {
            _db = MemoryDB.Instance; // TODO: inject
        }
    }
}
