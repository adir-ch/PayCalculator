using PayCalculator.Infra.DataAccess;

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
