using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit9
{
    internal class DataAccess
    {
        private string auth;
        public DataAccess(string connectionString)
        {
            auth = connectionString;
            Test();
        }

        public DataTable RunProcedure(string name)
        {
            using(SqlConnection sqlConnection = new SqlConnection(auth))
            {
                DataTable dataTable = new DataTable();
                SqlCommand cmd = new SqlCommand($"EXECUTE dbo.{name}");
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dataTable.Load(reader);
                return dataTable;
            }
            
        }

        private void Test()
        {
            using (SqlConnection sqlConnection = new SqlConnection(auth))
            {
                sqlConnection.Open();
                sqlConnection.Close();
            }
        }
    }
}
