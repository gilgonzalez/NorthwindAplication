using Northwind.Domain.Model;
using NorthWind.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Services
{
    public class CategoriesService
    {
        public CategoriesRepository categoriesRepository;

        public CategoriesService() 
        {
            categoriesRepository = new CategoriesRepository();
        }

        public List<Category> GetCategories()
        {
            return categoriesRepository.GetCategories();

        }
    }
}
