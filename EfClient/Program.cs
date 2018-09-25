using AcmeLoans.Common;
using AcmeLoans.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetApplicationById();
            //InsertApplication();
            //UpdateLoanApplication();
            //DeleteApplication();
            //GetLoanApplications();
            GetLoanApplicationsByProcessedType();

            //continue using same logic

            Console.WriteLine("Press enter to continue");
            Console.ReadKey();
        }

        private static void GetApplicationById()
        {
            int id = 1;

            LoanApplicationsManager manager = new LoanApplicationsManager();
            var app = manager.GetApplicationById(id);

            Console.WriteLine("{0,-4}{1, -18}{2, -15}{3,-10}", "Id", "Loan Type Id", "Amount", "Created");
            Console.WriteLine("{0,-4}{1, -18}{2, -15:C}{3,-10}", 
                app.ApplicationId, app.LoanTypeId, app.Amount, app.Created.ToString("MM/dd/yyyy"));
        }

        public static void DeleteApplication()
        {
            int id = 1;

            LoanApplicationsManager manager = new LoanApplicationsManager();
            manager.DeleteApplication(id);
        }

        public static void InsertApplication()
        {
            Application app = new Application {
                Amount = 30000.00m,
                Created = DateTime.Now,
                IsProcessed = false,
                LoanTypeId = (int)eLoanType.Retail,
            };

            LoanApplicationsManager manager = new LoanApplicationsManager();
            int appId = manager.InsertApplication(app);

            Console.WriteLine("Application record was created with ID: {0}", appId);

        }

        public static void GetLoanApplications()
        {
            LoanApplicationsManager manager = new LoanApplicationsManager();
            List<Application> list = manager.GetLoanApplications();

            Console.WriteLine("{0,-4}{1, -18}{2, -15}{3,-10}", "Id", "Loan Type Id", "Amount", "Created");

            foreach (var app in list)
            {
                Console.WriteLine("{0,-4}{1, -18}{2, -15:C}{3,-10}",
                    app.ApplicationId, app.LoanTypeId, app.Amount, app.Created.ToString("MM/dd/yyyy"));
            }
        }

        public static void GetLoanApplicationsByProcessedType()
        {
            bool isProcessed = true;

            LoanApplicationsManager manager = new LoanApplicationsManager();
            List<Application> list = manager.GetLoanApplicationsByProcessedType(isProcessed);

            Console.WriteLine("{0,-4}{1, -18}{2, -15}{3,-10}", "Id", "Loan Type Id", "Amount", "Created");

            foreach (var app in list)
            {
                Console.WriteLine("{0,-4}{1, -18}{2, -15:C}{3,-10}",
                    app.ApplicationId, app.LoanTypeId, app.Amount, app.Created.ToString("MM/dd/yyyy"));
            }
        }

        public static void UpdateLoanApplication()
        {
            Application app = new Application
            {
                ApplicationId = 2,
                LoanTypeId = (int)eLoanType.Retail,
                Amount = 1500,
                IsProcessed = true,
                ProcessedDate = DateTime.Now
            };

            LoanApplicationsManager manager = new LoanApplicationsManager();
            manager.UpdateLoanApplication(app);

            //check to see if update worked
            var updatedApp = manager.GetApplicationById(app.ApplicationId);

            if(updatedApp != null)
            {
                Console.WriteLine("{0,-4}{1, -18}{2, -15}{3,-10}", "Id", "Loan Type Id", "Amount", "Created");
                Console.WriteLine("{0,-4}{1, -18}{2, -15:C}{3,-10}",
                    updatedApp.ApplicationId, updatedApp.LoanTypeId, updatedApp.Amount, updatedApp.Created.ToString("MM/dd/YYYY"));
            }

        }
    }
}
