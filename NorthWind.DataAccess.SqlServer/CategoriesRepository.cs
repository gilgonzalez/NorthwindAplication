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
    public class CategoriesRepository : BaseRepository
    {
        public CategoriesRepository(): base()
        {
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                sqlConnection.Open();
                string sql = @" SELECT [CategoryID], [CategoryName], [Description], [Picture]
                                FROM [Northwind].[dbo].[Categories]";

                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Category category = new Category();
                    category.CategoryID = Convert.ToInt16(reader["CategoryID"].ToString());
                    category.CategoryName = reader["CategoryName"].ToString();
                    categories.Add(category);
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }
            return categories;
        }

    }
}
