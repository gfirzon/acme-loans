using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicants.Models
{
    public class ApplicationViewModel
    {
        public int ApplicationId { get; set; }
        public int LoanTypeId { get; set; }
        public decimal Amount { get; set; }
        public string AmountForVm { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime Created { get; set; }
        public string CreatedForVm { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public string ProcesedDateVm { get; set; }
        public string Description { get; set; }

    }
}