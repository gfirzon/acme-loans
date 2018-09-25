using System;
using System.Collections.Generic;
using AcmeLoans.Common;
using AcmeLoans.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcmeLoans.DataAccessUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetLoanTypes_TestMethod()
        {
            LoanTypeManager accessor = new LoanTypeManager();
            List<LoanType> list = accessor.GetLoanTypes();

            Assert.IsTrue(list.Count == 4, "Number of elements does not match!");
        }

        [TestMethod]
        public void GetLoanTypeExisting_TestMethod()
        {
            LoanTypeManager accessor = new LoanTypeManager();
            LoanType o = accessor.GetLoanType(2);

            Assert.IsNotNull(o);
        }

        [TestMethod]
        public void GetLoanTypeNonExisting_TestMethod()
        {
            LoanTypeManager accessor = new LoanTypeManager();
            LoanType o = accessor.GetLoanType(22);

            Assert.IsNull(o);
        }


        [TestMethod]
        public void DisplayLoanTypes_TestMethod()
        {
            LoanTypeManager accessor = new LoanTypeManager();
            List<LoanType> list = accessor.GetLoanTypes();

            Assert.IsTrue(list.Count == 4, "Number of elements does not match!");

            foreach (LoanType item in list)
            {
                Console.WriteLine("ID: {0} Desc: {1}", item.LoanTypeId, item.Description);
            }
        }
    }
}
