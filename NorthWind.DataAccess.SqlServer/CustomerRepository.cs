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
    public class CustomerRepository : BaseRepository
    {
        public CustomerRepository(): base()
        {




        }

        public bool ExistCustomerId(string CustomerId)
        {
            try
            {
                sqlConnection.Open();

                string sql = @" SELECT Count(*) FROM Customers where CustomerId = @CustomerId";

                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

                sqlCommand.Parameters.Add("@CustomerId", SqlDbType.NChar);
                sqlCommand.Parameters["@CustomerId"].Value = CustomerId;

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
        public void createCustomer(Customer customer)
        {
            try
            {
                sqlConnection.Open();

                string sql = @" INSERT INTO [dbo].[Customers]
                                   ([CustomerID]
                                   ,[CompanyName]
                                   ,[ContactName]
                                   ,[ContactTitle]
                                   ,[Address]
                                   ,[City]
                                   ,[Region]
                                   ,[PostalCode]
                                   ,[Country]
                                   ,[Phone]
                                   ,[Fax])
                             VALUES
                                   (@CustomerID
                                   ,@CompanyName
                                   ,@ContactName
                                   ,@ContactTitle
                                   ,@Address
                                   ,@City
                                   ,@Region
                                   ,@PostalCode
                                   ,@Country
                                   ,@Phone
                                   ,@Fax)";


                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

                sqlCommand.Parameters.Add("@CustomerId", SqlDbType.NChar);
                sqlCommand.Parameters.Add("@CompanyName", SqlDbType.NVarChar);
                sqlCommand.Parameters.Add("@ContactName", SqlDbType.NVarChar);
                sqlCommand.Parameters.Add("@ContactTitle", SqlDbType.NVarChar);
                sqlCommand.Parameters.Add("@Address", SqlDbType.NVarChar);
                sqlCommand.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCommand.Parameters.Add("@Region", SqlDbType.NVarChar);
                sqlCommand.Parameters.Add("@PostalCode", SqlDbType.NVarChar);
                sqlCommand.Parameters.Add("@Country", SqlDbType.NVarChar);
                sqlCommand.Parameters.Add("@Phone", SqlDbType.NVarChar);
                sqlCommand.Parameters.Add("@Fax", SqlDbType.NVarChar);

                sqlCommand.Parameters["@CustomerId"].Value = customer.CustomerId;
                sqlCommand.Parameters["@CompanyName"].Value = customer.CompanyName;
                sqlCommand.Parameters["@ContactName"].Value = (object)customer.ContactName ?? DBNull.Value;
                sqlCommand.Parameters["@ContactTitle"].Value = (object)customer.ContactTitle ?? DBNull.Value;
                sqlCommand.Parameters["@Address"].Value = (object)customer.Address ?? DBNull.Value;
                sqlCommand.Parameters["@City"].Value = (object)customer.City ?? DBNull.Value;
                sqlCommand.Parameters["@Region"].Value = (object)customer.Region ?? DBNull.Value;
                sqlCommand.Parameters["@PostalCode"].Value = (object)customer.PostalCode ?? DBNull.Value ;
                sqlCommand.Parameters["@Country"].Value = (object)customer.Country ?? DBNull.Value ;
                sqlCommand.Parameters["@Phone"].Value = (object)customer.Phone ?? DBNull.Value ;
                sqlCommand.Parameters["@Fax"].Value = (object)customer.Fax ?? DBNull.Value;


                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }
        }

        public bool existOrdersAssignedToCustomer(string customerId)
        {
            try
            {
                sqlConnection.Open();

                string sql = @" SELECT Count(*) FROM Orders where CustomerId = @CustomerId";

                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

                sqlCommand.Parameters.Add("@CustomerId", SqlDbType.NChar);
                sqlCommand.Parameters["@CustomerId"].Value = customerId;

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

        public void removeCustomer(string customerId)
        {

            try
            {
                sqlConnection.Open();

                string sql = @" DELETE FROM Customers where CustomerId = @CustomerId";

                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

                sqlCommand.Parameters.Add("@CustomerId", SqlDbType.NChar);
                sqlCommand.Parameters["@CustomerId"].Value = customerId;

                sqlCommand.ExecuteNonQuery();


                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }

}
        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                sqlConnection.Open();
                string sql = @" SELECT [CustomerID],[CompanyName],[ContactName],[ContactTitle],[Address],
                                       [City] ,[Region] ,[PostalCode],[Country],[Phone],[Fax] 
                                FROM Customers";
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerId = reader["CustomerId"].ToString();
                    customer.CompanyName = reader["CompanyName"].ToString();
                    customer.ContactName = reader["ContactName"].ToString();
                    customer.ContactTitle = reader["ContactTitle"].ToString();
                    customer.Address = reader["Address"].ToString();
                    customer.City = reader["City"].ToString();
                    customer.Region = reader["Region"].ToString();
                    customer.PostalCode = reader["PostalCode"].ToString();
                    customer.Country = reader["Country"].ToString();
                    customer.Phone = reader["Phone"].ToString();
                    customer.Fax = reader["Fax"].ToString();
                    customers.Add(customer);
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }
            return customers;
        }


     

    }
}
