using Northwind.Domain.Model;
using NorthWind.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Services
{
    public class CustomerService
    {
        public CustomerRepository customerRepository;

        public CustomerService() 
        {
            customerRepository = new CustomerRepository();
        }

        public bool CreateCustomer(Customer customer)
        {
            bool result = false;
            if (ValidateCustomer(customer) == "Valid")
            {
                customerRepository.createCustomer(customer);
                result = true;
            }
            return result;
        }

        public bool ExistOrdersAssignedToCustomer(string customerId)
        {
            return customerRepository.existOrdersAssignedToCustomer(customerId);
        }

        public bool RemoveCustomer(string customerId)
        {
            customerRepository.removeCustomer(customerId);
            return true;
        }



        public List<Customer> GetCustomers()
        {
            return customerRepository.GetCustomers();

        }

        public bool ExistCustomerId(string customerId)
        {
            return customerRepository.ExistCustomerId(customerId);
        }

        public string ValidateCustomer(Customer customer)
        {
            string message = "";
            message += validateCustomerId(customer.CustomerId);
            message += validateCompanyName(customer.CompanyName);
            message += validateContactName(customer.ContactName);
            message += validateContactTitle(customer.ContactTitle);
            message += validateAddress(customer.Address);
            message += validateCity(customer.City);
            message += validateRegion(customer.Region);
            message += validatePostalCode(customer.PostalCode);
            message += validateCountry(customer.Country);
            message += validatePhone(customer.Phone);
            message += validateFax(customer.Fax);

            if ( String.IsNullOrEmpty(message))
            {
                message = "Valid";
            }
            return message;
        }

        public string validateCustomerId(string customerId)
        {
            string message = "";
            if (String.IsNullOrEmpty(customerId))
            {
                message = "CustomerId no puede ser vacio. \n";
            }
            else if (customerId.Length > 40)
            {
                message = "CustomerId debe tener menos de 5 caracteres.  \n";
            }
            return message;
        }

        public string validateCompanyName(string companyName)
        {
            string message = "";
            if (String.IsNullOrEmpty(companyName))
            {
                message = "Company Name no puede ser vacio.  \n";
            }
            else if (companyName.Length > 40)
            {
                message = "Company Name debe tener menos de 40 caracteres.  \n";
            }
            return message;
        }

        public string validateContactName(string contactName)
        {
            string message = "";
             if (contactName!=null && contactName.Length > 30)
            {
                message = "Contacty Name debe tener menos de 30 caracteres.  \n";
            }
            return message;
        }

        public string validateContactTitle(string contactTitle)
        {
            string message = "";
            if (contactTitle != null && contactTitle.Length > 30)
            {
                message = "Contacty Title debe tener menos de 30 caracteres.  \n";
            }
            return message;
        }

        public string validateAddress(string contactTitle)
        {
            string message = "";
            if (contactTitle != null && contactTitle.Length > 60)
            {
                message = "Addresss debe tener menos de 60 caracteres.  \n";
            }
            return message;
        }

        public string validateCity(string city)
        {
            string message = "";
            if (city != null && city.Length > 15)
            {
                message = "City debe tener menos de 15 caracteres.  \n";
            }
            return message;
        }

        public string validateRegion(string region)
        {
            string message = "";
            if (region != null && region.Length > 15)
            {
                message = "Region debe tener menos de 15 caracteres.  \n";
            }
            return message;
        }

        public string validatePostalCode(string postalCode)
        {
            string message = "";
            if (postalCode != null && postalCode.Length > 10)
            {
                message = "Postal Code debe tener menos de 10 caracteres.  \n";
            }
            return message;
        }

        public string validateCountry(string country)
        {
            string message = "";
            if (country != null && country.Length > 15)
            {
                message = "Country debe tener menos de 15 caracteres.  \n";
            }
            return message;
        }

        public string validatePhone(string phone)
        {
            string message = "";
            if (phone != null && phone.Length > 10)
            {
                message = "Phone debe tener menos de 24 caracteres.  \n";
            }
            return message;
        }

        public string validateFax(string fax)
        {
            string message = "";
            if (fax != null && fax.Length > 24)
            {
                message = "Fax debe tener menos de 24 caracteres.  \n";
            }
            return message;
        }
    }
}
