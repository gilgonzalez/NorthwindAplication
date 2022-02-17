using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.DataAccess.SqlServer
{
    public class BaseRepository
    {
        private string connectionString;
        protected SqlConnection sqlConnection;

        public BaseRepository()
        {
            connectionString = "Server=192.168.1.132;Database=Northwind;UID=SA;Password=<YourStrong@Passw0rd>;";
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = this.connectionString;
        }
    }
}
