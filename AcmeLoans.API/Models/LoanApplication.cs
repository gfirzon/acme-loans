using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcmeLoans.API.Models
{
    public class LoanApplication
    {
        public string LastName { get; set; }
        public decimal Amount { get; set; }
    }
}