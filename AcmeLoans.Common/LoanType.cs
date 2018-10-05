using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLoans.Common
{
    public class LoanType
    {
        public eLoanType LoanTypeId { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// needed for client to get string version of object of this class
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Description;
        }
    }
}
