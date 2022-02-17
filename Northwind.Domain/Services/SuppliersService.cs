using Northwind.Domain.Model;
using NorthWind.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Services
{
    public class SuppliersService
    {
        public SuppliersRepository suppliersRepository;

        public SuppliersService() 
        {
            suppliersRepository = new SuppliersRepository();
        }

        public List<Supplier> GetSuppliers()
        {
            return suppliersRepository.GetSuppliers();

        }

    }
}
