using AcmeLoans.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLoans.DataAccess
{
    public class ApplicantsManager : DataAccessor
    {
        public List<Applicant> GetApplicants()
        {
            List<Applicant> list = new List<Applicant>();

            string connString = GetConnectionString();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = connString;
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Applicants";
            cmd.CommandType = System.Data.CommandType.Text;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {
                int id = Convert.ToInt32(reader["ApplicantId"]);
                string ssn = reader["SSN"].ToString();
                string lastName = reader["LastName"].ToString();
                string firstName = reader["FirstName"].ToString();
                DateTime birth = Convert.ToDateTime(reader["DateOfBirth"]);
                string street = reader["StreetAddress"].ToString();
                string city = reader["City"].ToString();
                int stateID = Convert.ToInt32(reader["StateID"]);
                string zip = reader["Zip"].ToString();
                string homePhone = reader["HomePhone"].ToString();
                string mobilePhone = reader["MobilePhone"].ToString();
                string email = reader["EMail"].ToString();

                Applicant app = new Applicant
                {
                    ApplicantId = id,
                    SSN = ssn,
                    LastName = lastName,
                    FirstName = firstName,
                    DateOfBirth = birth,
                    StreetAddress = street,
                    City = city,
                    StateID = stateID,
                    Zip = zip,
                    HomePhone = homePhone,
                    MobilePhone = mobilePhone,
                    EMail = email

                };
                list.Add(app);
            }

            reader.Close();
            cmd.Dispose();
            conn.Close();

            return list;

        }
        public void DeleteApplicant(int appId)
        {
                string connString = GetConnectionString();

                SqlConnection conn = new SqlConnection();

                conn.ConnectionString = connString;
                conn.Open();

                string query = @"sp_DeleteApplicant";
     
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@ApplicantId",
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

        public int InsertApplicant(Applicant app)
        {
            string connString = GetConnectionString();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = connString;
            conn.Open();

            string query = @"sp_InsertLoanApplicant";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@SSN",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = app.SSN,
                Size = app.SSN.Length
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@LastName",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Value = app.LastName,
                Size = app.LastName.Length
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@FirstName",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Value = app.FirstName,
                Size = app.FirstName.Length
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@DateOfBirth",
                SqlDbType = System.Data.SqlDbType.DateTime,
                Value = app.DateOfBirth
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@StreetAddress",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Value = app.StreetAddress,
                Size = app.StreetAddress.Length
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@City",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Value = app.City,
                Size = app.City.Length
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@StateID",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = app.StateID
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@Zip",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Value = app.Zip,
                Size = app.Zip.Length
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@HomePhone",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = app.HomePhone,
                Size = app.HomePhone.Length
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@MobilePhone",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = app.MobilePhone,
                Size = app.MobilePhone.Length
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@EMail",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Value = app.EMail,
                Size = app.EMail.Length
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@ApplicantId",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            });

            cmd.ExecuteNonQuery();

            int applicantId = Convert.ToInt32(cmd.Parameters["@ApplicantId"].Value);

            cmd.Dispose();
            conn.Close();

            return applicantId;
        }
        public Applicant GetApplicantById(int appId)
        {
            Applicant app = null;

            string connString = GetConnectionString();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = connString;
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "sp_GetApplicantByID";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@ApplicantId";
            param.SqlDbType = System.Data.SqlDbType.Int;
            param.Value = appId;

            cmd.Parameters.Add(param);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read() == true)
            {
                int id = Convert.ToInt32(reader["ApplicantId"]);
                string ssn = reader["SSN"].ToString();
                string lastName = reader["LastName"].ToString();
                string firstName = reader["FirstName"].ToString();
                DateTime birth = Convert.ToDateTime(reader["DateOfBirth"]);
                string street = reader["StreetAddress"].ToString();
                string city = reader["City"].ToString();
                int stateID = Convert.ToInt32(reader["StateID"]);
                string zip = reader["Zip"].ToString();
                string homePhone = reader["HomePhone"].ToString();
                string mobilePhone = reader["MobilePhone"].ToString();
                string email = reader["EMail"].ToString();

               app = new Applicant
                {
                    ApplicantId = id,
                    SSN = ssn,
                    LastName = lastName,
                    FirstName = firstName,
                    DateOfBirth = birth,
                    StreetAddress = street,
                    City = city,
                    StateID = stateID,
                    Zip = zip,
                    HomePhone = homePhone,
                    MobilePhone = mobilePhone,
                    EMail = email

                };
            }

            reader.Close();
            cmd.Dispose();
            conn.Close();

            return app;
        }
    }
}
