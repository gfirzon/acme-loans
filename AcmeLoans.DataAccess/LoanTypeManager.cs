using AcmeLoans.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLoans.DataAccess
{
    public class LoanTypeManager : DataAccessor
    {
        public List<LoanType> GetLoanTypes()
        {
            List<LoanType> list = new List<LoanType>();

            string connString = GetConnectionString();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = connString;
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from LoanTypes";
            cmd.CommandType = System.Data.CommandType.Text;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {
                eLoanType id = (eLoanType)Convert.ToInt32(reader["LoanTypeId"]);
                string desc = reader["Description"].ToString();

                LoanType loanType = new LoanType { LoanTypeId = id, Description = desc };
                list.Add(loanType);
            }

            reader.Close();
            cmd.Dispose();
            conn.Close();

            return list;
        }

        public LoanType GetLoanType(int loanTypeId)
        {
            LoanType loanType = null;

            string connString = GetConnectionString();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = connString;
            conn.Open();

            //string query = string.Format("select * from LoanTypes where LoanTypeId = {0}", loanTypeId);
            string query = "select * from LoanTypes where LoanTypeId = @LoanTypeId";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@LoanTypeId",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = loanTypeId
            });

            SqlDataReader reader = cmd.ExecuteReader();

            bool found = reader.Read();
            if (found == true)
            {

                loanType = new LoanType
                {
                    LoanTypeId = (eLoanType) Convert.ToInt32(reader["LoanTypeId"]),
                    Description = reader["Description"].ToString()
                };
            }

            //clean up

            reader.Close();
            cmd.Dispose();
            conn.Close();

            return loanType;
        }
       
    }
}
