using System;
using System.Collections.Generic;
using AcmeLoans.Common;
using AcmeLoans.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcmeLoans.DataAccessUnitTest
{
    [TestClass]
    public class ApplicantsUnitTests
    {
        [TestMethod]
        public void GetLoanApplicants_TestMethod()
        {
            ApplicantsManager accessor = new ApplicantsManager();
            List<Applicant> list = accessor.GetApplicants();
            Assert.IsTrue(list.Count == 1);
        }

        [TestMethod]
        public void InsertApplicant_TestMethod()
        {
            ApplicantsManager accessor = new ApplicantsManager();

            Applicant o = new Applicant {
                SSN = "111223333",
                LastName = "Jones",
                FirstName = "Peter",
                DateOfBirth = new DateTime(1988, 1, 9),
                StreetAddress = "1313 Mockingbird Ln",
                City = "Dallas",
                StateID = 1,
                Zip = "75234",
                HomePhone = "2142337701",
                MobilePhone = "2143439999",
                EMail = "test@test.com"
            };

            int id = accessor.InsertApplicant(o);

            Assert.IsTrue(id > 0);
        }
    }
}
