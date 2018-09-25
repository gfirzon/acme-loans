using AcmeLoans.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLoans.DataAccess
{
    public class LoanApplicationsManager : DataAccessor
    {
        public void DeleteApplication(int appId)
        {
            string connString = GetConnectionString();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = connString;
            conn.Open();

            string query = @"sp_DeleteLoanApplication";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@ApplicationId",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = appId
            });

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }

        /// <summary>
        /// Return ID of the newly created record
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public int InsertApplication(LoanApplication app)
        {
            string connString = GetConnectionString();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = connString;
            conn.Open();

            string query = @"sp_InsertLoanApplication";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@LoanTypeId",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = app.LoanTypeId
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@Amount",
                SqlDbType = System.Data.SqlDbType.Money,
                Value = app.Amount,
                Direction = System.Data.ParameterDirection.Input
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@IsProcessed",
                SqlDbType = System.Data.SqlDbType.Bit,
                Value = app.IsProcessed
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@Created",
                SqlDbType = System.Data.SqlDbType.DateTime,
                Value = app.Created
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@appId",
                SqlDbType = System.Data.SqlDbType.Int,
                //Value = 0,
                Direction = System.Data.ParameterDirection.Output
            });

            cmd.ExecuteNonQuery();

            int appId = Convert.ToInt32(cmd.Parameters["@appId"].Value);

            cmd.Dispose();
            conn.Close();

            return appId;
        }

        public void InsertApplication_Unused(LoanApplication app)
        {
            string connString = GetConnectionString();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = connString;
            conn.Open();

            string query = @"insert into Applications (LoanTypeId, Amount, IsProcessed, Created) values ";
            query += "(@LoanTypeId, @Amount, @IsProcessed, @Created)";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@LoanTypeId",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = app.LoanTypeId
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@Amount",
                SqlDbType = System.Data.SqlDbType.Money,
                Value = app.Amount
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@IsProcessed",
                SqlDbType = System.Data.SqlDbType.Bit,
                Value = app.IsProcessed
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@Created",
                SqlDbType = System.Data.SqlDbType.DateTime,
                Value = app.Created
            });

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }

        public LoanApplication GetApplicationById(int appId)
        {
            LoanApplication app = null;

            string connString = GetConnectionString();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = connString;
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "sp_GetLoanApplicationById";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@ApplicationId";
            param.SqlDbType = System.Data.SqlDbType.Int;
            param.Value = appId;

            cmd.Parameters.Add(param);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read() == true)
            {
                int id = Convert.ToInt32(reader["ApplicationId"]);
                eLoanType loanTypeId = (eLoanType)(Convert.ToInt32(reader["LoanTypeId"]));
                decimal amount = Convert.ToDecimal(reader["Amount"]);
                bool isProcessed = Convert.ToBoolean(reader["IsProcessed"]);
                DateTime created = Convert.ToDateTime(reader["Created"]);
                DateTime? processedDate = reader["ProcessedDate"] != DBNull.Value ?
                    Convert.ToDateTime(reader["ProcessedDate"]) : (DateTime?)null;

                app = new LoanApplication
                {
                    ApplicationId = id,
                    LoanTypeId = loanTypeId,
                    Amount = amount,
                    IsProcessed = isProcessed,
                    Created = created,
                    ProcessedDate = processedDate
                };
            }

            reader.Close();
            cmd.Dispose();
            conn.Close();

            return app;
        }

        public List<LoanApplication> GetLoanApplications()
        {
            List<LoanApplication> list = new List<LoanApplication>();

            string connString = GetConnectionString();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = connString;
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Applications";
            cmd.CommandType = System.Data.CommandType.Text;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {
                int id = Convert.ToInt32(reader["ApplicationId"]);
                eLoanType loanTypeId = (eLoanType)Convert.ToInt32(reader["LoanTypeId"]);
                decimal amount = Convert.ToDecimal(reader["Amount"]);
                bool isProcessed = Convert.ToBoolean(reader["IsProcessed"]);
                DateTime created = Convert.ToDateTime(reader["Created"]);
                DateTime? processedDate = reader["ProcessedDate"] != DBNull.Value ?
                    Convert.ToDateTime(reader["ProcessedDate"]) : (DateTime?)null;

                LoanApplication app = new LoanApplication
                {
                    ApplicationId = id,
                    LoanTypeId = loanTypeId,
                    Amount = amount,
                    IsProcessed = isProcessed,
                    Created = created,
                    ProcessedDate = processedDate
                };
                list.Add(app);
            }

            reader.Close();
            cmd.Dispose();
            conn.Close();

            return list;
        }

        public List<LoanApplication> GetLoanApplicationsByProcessedType(bool isProcessed)
        {
            List<LoanApplication> list = new List<LoanApplication>();

            string connString = GetConnectionString();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = connString;
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "sp_GetLoanApplicationsByProcessedType";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@IsProcessed",
                SqlDbType = System.Data.SqlDbType.Bit,
                Value = isProcessed
            });

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {
                int id = Convert.ToInt32(reader["ApplicationId"]);
                eLoanType loanTypeId = (eLoanType)Convert.ToInt32(reader["LoanTypeId"]);
                decimal amount = Convert.ToDecimal(reader["Amount"]);
                bool isProc = Convert.ToBoolean(reader["IsProcessed"]);
                DateTime created = Convert.ToDateTime(reader["Created"]);
                DateTime? processedDate = reader["ProcessedDate"] != DBNull.Value ?
                    Convert.ToDateTime(reader["ProcessedDate"]) : (DateTime?)null;

                LoanApplication app = new LoanApplication
                {
                    ApplicationId = id,
                    LoanTypeId = loanTypeId,
                    Amount = amount,
                    IsProcessed = isProc,
                    Created = created,
                    ProcessedDate = processedDate
                };
                list.Add(app);
            }

            reader.Close();
            cmd.Dispose();
            conn.Close();

            return list;

        }

        public void UpdateLoanApplication(LoanApplication app)
        {
            string connString = GetConnectionString();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = connString;
            conn.Open();

            string query = @"sp_UpdateLoanApplication";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@ApplicationId",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = app.ApplicationId
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@LoanTypeId",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = app.LoanTypeId
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@Amount",
                SqlDbType = System.Data.SqlDbType.Money,
                Value = app.Amount
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@IsProcessed",
                SqlDbType = System.Data.SqlDbType.Bit,
                Value = app.IsProcessed
            });

            object v1 = DBNull.Value;
            if(app.ProcessedDate.HasValue)
            {
                v1 = app.ProcessedDate.Value;
            }

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@ProcessedDate",
                IsNullable = true,
                SqlDbType = System.Data.SqlDbType.DateTime,
                Value = v1
            });

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }
    }
}
