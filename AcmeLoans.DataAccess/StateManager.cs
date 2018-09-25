using AcmeLoans.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLoans.DataAccess
{
    public class StateManager : DataAccessor
    {
        public List<State> GetStates()
        {
            List<State> list = new List<State>();

            string connString = GetConnectionString();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = connString;
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from States";
            cmd.CommandType = System.Data.CommandType.Text;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {
                int id = Convert.ToInt32(reader["StateID"]);
                string stateCode = reader["StateCode"].ToString();
                string stateName = reader["StateName"].ToString();
 
                State state = new State
                {
                    StateID = id,
                    StateCode = stateCode,
                    StateName = stateName
                    
                };
                list.Add(state);
            }

            reader.Close();
            cmd.Dispose();
            conn.Close();

            return list;

        }
 
    }
}
