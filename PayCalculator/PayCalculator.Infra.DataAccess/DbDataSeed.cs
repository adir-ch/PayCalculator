using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator.Infra.DataAccess
{
    public class DbDataSeed
    {
        public void SeedDb(IDB db)
        {
            LocationsSeed(db);
        }

        private void LocationsSeed(IDB db)
        {
            
        }
    }
}
