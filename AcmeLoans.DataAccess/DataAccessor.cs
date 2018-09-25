using AcmeLoans.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

//http://csharp-station.com/Tutorial/AdoDotNet/Lesson06

namespace AcmeLoans.DataAccess
{
    public class DataAccessor
    {
        protected string GetConnectionString()
        {
            string result = ConfigurationManager.ConnectionStrings["AcmeLoansConnection"].ToString();
            return result;
            //return @"Data Source=.\SQLEXPRESS;Initial Catalog=AcmeLoans;Integrated Security=SSPI;";
        }
    }
}
