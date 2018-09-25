using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLoans.EFDataAccess
{
    public class LoanApplicationsManager : BaseDataManager
    {
        public Application GetApplicationById(int appId)
        {
            var app = dbContext.Applications.Where(m => m.ApplicationId == appId).FirstOrDefault();
            return app;
        }

        /// <summary>
        /// should delete application having specified ID
        /// </summary>
        /// <param name="appId"></param>
        public void DeleteApplication(int appId)
        {
            Application o = dbContext.Applications.Where(m => m.ApplicationId == appId).FirstOrDefault();


            if (o != null)
            {
                dbContext.Applications.Remove(o);
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Should create a new Application record getting the values from the parameter
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public int InsertApplication(Application app)
        {
            dbContext.Applications.Add(app);
            dbContext.SaveChanges();

            return app.ApplicationId;
        }

        /// <summary>
        /// Should return all Applications in the table
        /// </summary>
        /// <returns></returns>
        public List<Application> GetLoanApplications()
        {
            List<Application> list = dbContext.Applications.ToList();

            return list;
        }

        /// <summary>
        /// Should return all Applications in the table having specified processed type
        /// </summary>
        /// <returns></returns>
        public List<Application> GetLoanApplicationsByProcessedType(bool isProcessed)
        {
            List<Application> list = dbContext.Applications.Where(m =>m.IsProcessed == isProcessed).ToList();

            return list;
        }

        /// <summary>
        /// should update table record using values in the param
        /// Note: use the app id as the criteria
        /// </summary>
        /// <param name="app"></param>
        public void UpdateLoanApplication(Application app)
        {
            Application o = dbContext.Applications.Where(m => m.ApplicationId == app.ApplicationId).FirstOrDefault();

            if(o != null)
            {
                o.Amount = app.Amount;
                o.LoanTypeId = app.LoanTypeId;
                o.ProcessedDate = app.ProcessedDate;
                o.IsProcessed = app.IsProcessed;

                dbContext.SaveChanges();
            }
            
        }
    }
}
