using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLoans.EFDataAccess
{
    public abstract class BaseDataManager
    {
        protected AcmeLoansEntitiesEF dbContext = null;

        public BaseDataManager()
        {
            dbContext = new AcmeLoansEntitiesEF();
        }
    }
}
