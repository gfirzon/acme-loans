using AcmeLoans.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AcmeLoans.API.Controllers
{
    public class LoanApplicationsController : ApiController
    {
        // POST api/values
        public void Post([FromBody]LoanApplication application)
        {
            int n = 1;
        }
        //GET api/values/5
        public LoanApplication Get(string lastName)
        {
            LoanApplication loan = new LoanApplication();
            loan.LastName = lastName;
            loan.Amount = 60000;

            return loan;
        }
        // GET api/values
        public IEnumerable<LoanApplication> Get()
        {
            List<LoanApplication> apps =  new List<LoanApplication>();

            apps.Add(new LoanApplication { LastName="AAA", Amount = 888 });
            apps.Add(new LoanApplication { LastName = "BBB", Amount = 999 });

            return apps;
        }
    }

}
