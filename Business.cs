using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit9
{
    public class Business
    {
        private DataAccess database;

        public Business(string username, string password) 
        {
            database = new DataAccess("Data Source=JOSH-PC\\SQLEXPRESS;" +
                                        "Database=Northwind;" +
                                        "TrustServerCertificate=True;" +
                                        $"User id = {username};" +
                                        $"Password = {password};");
        }


        public DataTable GetTable(string procedureName)
        {
            return database.RunProcedure(procedureName);
        }
    }
}
