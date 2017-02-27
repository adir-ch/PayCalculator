using PayCalculator.core.Model.Common;
using System;
using System.Collections.Generic;

namespace PayCalculator.Infra.DataAccess
{
    public class MemoryDB : IDB
    {
        Dictionary<string, IDBEntity> _db;

        private static readonly Lazy<MemoryDB> _instance = new Lazy<MemoryDB>(() => CreateAndSeedMemoryDB());

        private static MemoryDB CreateAndSeedMemoryDB()
        {
            var db = new MemoryDB();
            var seed = new DbDataSeed();
            seed.SeedDb(db);
            return db;
        }

        public static MemoryDB Instance
        {
            get { return _instance.Value; }
        }

        private MemoryDB()
        {
            _db = new Dictionary<string, IDBEntity>();
        }

        public bool Create(string key, IDBEntity entity)
        {
            _db.Add(key, entity);
            return true;
        }

        public bool CreateOrUpdate(string key, IDBEntity entity)
        {
            if (Read(key) != null)
            {
                Update(key, entity);
            }
            else
            {
                Create(key, entity);
            }

            return true;
        }

        public IDBEntity Read(string key)
        {
            IDBEntity entity = null;
            _db.TryGetValue(key, out entity);
            return entity;
        }

        public bool Update(string key, IDBEntity entity)
        {
            _db[key] = entity;
            return true;
        }

        public bool Delete(string key)
        {
            return _db.Remove(key);
        }
    }
}
