using Northwind.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.DataAccess.SqlServer
{
    public class SuppliersRepository : BaseRepository
    {
        public SuppliersRepository(): base()
        {

        }

        public List<Supplier> GetSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();
            try
            {
                sqlConnection.Open();
                string sql = @" SELECT [SupplierID],[CompanyName] FROM [dbo].[Suppliers]";

                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Supplier supplier = new Supplier();
                    supplier.SupplierID = Convert.ToInt32(reader["SupplierID"].ToString());
                    supplier.CompanyName = reader["CompanyName"].ToString();
                    suppliers.Add(supplier);
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }
            return suppliers;
        }
    }
}
