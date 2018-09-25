using System;
using System.Collections.Generic;
using AcmeLoans.Common;
using AcmeLoans.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcmeLoans.DataAccessUnitTest
{
    [TestClass]
    public class LoanApplicationsUnitTests
    {
        [TestMethod]
        public void UpdateLoanApplication_TestMethod()
        {
            LoanApplication app = new LoanApplication
            {
                ApplicationId = 2,
                LoanTypeId = eLoanType.Retail,
                Amount = 500,
                IsProcessed = true,
                ProcessedDate = DateTime.Now
            };

            LoanApplicationsManager accessor = new LoanApplicationsManager();
            accessor.UpdateLoanApplication(app);
        }

        [TestMethod]
        public void UpdateLoanApplicationNullProcessedDate_TestMethod()
        {
            LoanApplication app = new LoanApplication
            {
                ApplicationId = 2,
                LoanTypeId = eLoanType.Retail,
                Amount = 500,
                IsProcessed = false,
                ProcessedDate = null
            };

            LoanApplicationsManager accessor = new LoanApplicationsManager();
            accessor.UpdateLoanApplication(app);
        }

        [TestMethod]
        public void InsertLoanApplication_TestMethod()
        {
            LoanApplication app = new LoanApplication
            {
                LoanTypeId = eLoanType.Car,
                Amount = 24940,
                IsProcessed = true,
                Created = DateTime.Now
            };

            LoanApplicationsManager accessor = new LoanApplicationsManager();
            int appId = accessor.InsertApplication(app);
        }

        [TestMethod]
        public void GetLoanApplications_TestMethod()
        {
            LoanApplicationsManager accessor = new LoanApplicationsManager();
            List<LoanApplication> list = accessor.GetLoanApplications();
        }

        [TestMethod]
        public void GetLoanApplicationsByProcessedType_TestMethod()
        {
            bool isProcessed = false;

            LoanApplicationsManager accessor = new LoanApplicationsManager();
            List<LoanApplication> list = accessor.GetLoanApplicationsByProcessedType(isProcessed);
        }

        [TestMethod]
        public void GetLoanApplicationById_TestMethod()
        {
            int appId = 3;

            LoanApplicationsManager accessor = new LoanApplicationsManager();
            LoanApplication app = accessor.GetApplicationById(appId);
        }

        [TestMethod]
        public void DeleteLoanApplicationById_TestMethod()
        {
            int appId = 6;

            LoanApplicationsManager accessor = new LoanApplicationsManager();
            accessor.DeleteApplication(appId);
        }
    }
}
