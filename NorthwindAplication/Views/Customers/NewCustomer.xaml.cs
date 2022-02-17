using Northwind.Domain.Model;
using Northwind.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Northwind.Presentation.Views.Customers
{
    /// <summary>
    /// Lógica de interacción para NewCustomer.xaml
    /// </summary>
    public partial class NewCustomer : Window
    {
        public NewCustomer()
        {
            InitializeComponent();
        }

        private void CreateNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerService customerService = new CustomerService();

            Customer customer = new Customer();
            customer.CustomerId = tbCustomerId.Text;
            customer.CompanyName = tbCompanyName.Text;
            customer.ContactName = tbContactName.Text;
            customer.ContactTitle = tbContactTitle.Text;
            customer.Address = tbAddress.Text;
            customer.City = tbCity.Text;
            customer.Region = tbRegion.Text;
            customer.PostalCode = tbPostalCode.Text;
            customer.Country = tbCountry.Text;
            customer.Phone = tbPhone.Text;

            string messageValidation = customerService.ValidateCustomer(customer);
            if(messageValidation == "Valid")
            {
                if( customerService.ExistCustomerId(customer.CustomerId) == false)
                {
                    customerService.CreateCustomer(customer);
                    this.DialogResult = true;
                }
                else
                {
                    messageValidation = "El customerId debe ser único. Por favor indique otro CustomerId";
                }
            }
            
            if(messageValidation != "Valid")
            {
                MessageBox.Show(messageValidation);
            }

        }
    }
}
