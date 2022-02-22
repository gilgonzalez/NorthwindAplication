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
            connectionString = "Server=192.168.213.130;Database=Northwind;UID=SA;Password=MeGustaMuchoDocker1;";
            //Hola


            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = this.connectionString;
        }
    }
}
