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
    }
}
