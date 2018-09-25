using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLoans.Common
{
    public class LoanApplication
    {
        public int ApplicationId { get; set; }
        public eLoanType LoanTypeId { get; set; }
        public decimal Amount { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime Created { get; set; }
        public DateTime? ProcessedDate { get; set; }
    }
}
