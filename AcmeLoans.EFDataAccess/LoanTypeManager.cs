using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLoans.EFDataAccess
{
    public class LoanTypeManager : BaseDataManager
    {
        public List<LoanType> GetLoanTypes()
        {
            return dbContext.LoanTypes.ToList();
        }
    }
}
