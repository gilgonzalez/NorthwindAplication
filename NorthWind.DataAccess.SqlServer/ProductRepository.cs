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
    public class ProductRepository : BaseRepository
    {
        public ProductRepository(): base()
        {

        }

        public bool ExistProductName(string productName)
        {
            try
            {
                sqlConnection.Open();

                string sql = @" SELECT Count(*) FROM Products where ProductName = @ProductName";

                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

                sqlCommand.Parameters.Add("@ProductName", SqlDbType.NVarChar);
                sqlCommand.Parameters["@ProductName"].Value = productName;

                int count = (int)sqlCommand.ExecuteScalar();

                sqlConnection.Close();

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }

        }

        public void createProduct(Product product)
        {
            try
            {
                sqlConnection.Open();

                string sql = @" INSERT INTO [dbo].[Products]
                               ([ProductName]
                               ,[SupplierID]
                               ,[CategoryID]
                               ,[QuantityPerUnit]
                               ,[UnitPrice]
                               ,[UnitsInStock]
                               ,[UnitsOnOrder]
                               ,[ReorderLevel]
                               ,[Discontinued])
                         VALUES
                               (@ProductName
                               ,@SupplierID
                               ,@CategoryID
                               ,@QuantityPerUnit
                               ,@UnitPrice
                               ,@UnitsInStock
                               ,@UnitsOnOrder
                               ,0
                               ,0)";


                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

                sqlCommand.Parameters.Add("@ProductName", SqlDbType.NVarChar);
                sqlCommand.Parameters.Add("@SupplierID", SqlDbType.Int);
                sqlCommand.Parameters.Add("@CategoryID", SqlDbType.Int);
                sqlCommand.Parameters.Add("@QuantityPerUnit", SqlDbType.NVarChar);
                sqlCommand.Parameters.Add("@UnitPrice", SqlDbType.Money);
                sqlCommand.Parameters.Add("@UnitsInStock", SqlDbType.SmallInt);
                sqlCommand.Parameters.Add("@UnitsOnOrder", SqlDbType.SmallInt);

                sqlCommand.Parameters["@ProductName"].Value = product.ProductName;
                sqlCommand.Parameters["@SupplierID"].Value = (object)product.SupplierID ?? DBNull.Value;
                sqlCommand.Parameters["@CategoryID"].Value = (object)product.CategoryID ?? DBNull.Value;
                sqlCommand.Parameters["@QuantityPerUnit"].Value = (object)product.QuantityPerUnit ?? DBNull.Value;
                sqlCommand.Parameters["@UnitPrice"].Value = (object)product.UnitPrice ?? DBNull.Value;
                sqlCommand.Parameters["@UnitsInStock"].Value = (object)product.UnitsInStock ?? DBNull.Value;
                sqlCommand.Parameters["@UnitsOnOrder"].Value = (object)product.UnitsOnOrder ?? DBNull.Value;

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }
        }

        public bool existOrderDetailsAssignedToProduct(int productId)
        {
            try
            {
                sqlConnection.Open();

                string sql = @" SELECT Count(*) FROM [Order Details] where ProductID = @ProductId";

                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

                sqlCommand.Parameters.Add("@ProductId", SqlDbType.Int);
                sqlCommand.Parameters["@ProductId"].Value = productId;

                int count = (int)sqlCommand.ExecuteScalar();

                sqlConnection.Close();

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }
        }

        public void removeProduct(int productId)
        {

            try
            {
                sqlConnection.Open();

                string sql = @" DELETE FROM [Products] where ProductID = @ProductID";

                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

                sqlCommand.Parameters.Add("@ProductID", SqlDbType.Int);
                sqlCommand.Parameters["@ProductID"].Value = productId;

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }

}

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                sqlConnection.Open();
                string sql = @" SELECT [ProductID],[ProductName],[SupplierID],[CategoryID],
                                        [QuantityPerUnit],[UnitPrice],[UnitsInStock],[UnitsOnOrder]
                                FROM [Northwind].[dbo].[Products]";

                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductID = Convert.ToInt32(reader["ProductID"]);
                    product.ProductName = reader["ProductName"].ToString();
                    product.SupplierID = Convert.ToInt32(reader["SupplierID"]);
                    product.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    product.QuantityPerUnit = reader["QuantityPerUnit"].ToString();
                    product.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                    product.UnitsInStock = Convert.ToInt16(reader["UnitsInStock"]);
                    products.Add(product);
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }
            return products;
        }

    }
}
