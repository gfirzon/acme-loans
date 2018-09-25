using AcmeLoans.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicants.Models;

namespace WebApplicants.Helpers
{
    public static class ApplicationExtensions
    {
        public static ApplicationViewModel ToViewModel(this Application m, List<LoanType> loanList)
        {
            var vm = new ApplicationViewModel
            {
                ApplicationId = m.ApplicationId,
                LoanTypeId = (int)m.LoanTypeId,
                Amount = m.Amount,
                AmountForVm = String.Format("{0:C}", m.Amount),
                IsProcessed = m.IsProcessed,
                Created = m.Created,
                CreatedForVm = m.Created.ToString("MM/dd/yyyy"),
                ProcessedDate = m.ProcessedDate,
                ProcesedDateVm = m.ProcessedDate.HasValue ? m.ProcessedDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                Description = loanList.Where(x => x.LoanTypeId == m.LoanTypeId).FirstOrDefault().Description
            };

            return vm;
        }
    }
}