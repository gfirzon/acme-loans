using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLoans.EFDataAccess
{
    public class ApplicantsManager : BaseDataManager
    {

        public List<Applicant> GetApplicants()
        {
            var list = dbContext.Applicants.ToList();
            return list;
        }

        public Applicant GetApplicantById(int id)
        {
            Applicant applicant = dbContext.Applicants.Where(m => m.ApplicantID == id).FirstOrDefault();
            return applicant;
        }
    }
}
