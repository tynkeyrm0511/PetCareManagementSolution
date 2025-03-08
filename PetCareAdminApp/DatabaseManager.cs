using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCareAdminApp
{
    class DatabaseManager
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["PetCareDB"].ConnectionString;

        public SqlConnection layChuoiKetNoi()
        {
            return new SqlConnection(connectionString);
        }
    }
}
