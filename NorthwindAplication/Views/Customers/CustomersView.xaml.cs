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
    /// Lógica de interacción para Customers.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {

        private CustomerService customerService;
        public CustomersView()
        {
            InitializeComponent();
            customerService = new CustomerService();
            dataGrid.ItemsSource = customerService.GetCustomers();
        }



        private void NewCustomer_Click(object sender, RoutedEventArgs e)
        {
            NewCustomer newCustomer = new NewCustomer();
            if (newCustomer.ShowDialog() == true)
            {
                //nombre = cliente.Nombre;
                //DNI = cliente.DNI;
                //arrayClientes[posArray] = new Clientes(nombre, DNI);
                //MessageBox.Show("Nuevo cliente " + nombre + " creado correctamente con DNI " + DNI, "BBDD Actualizada", MessageBoxButton.OK, MessageBoxImage.Information);
                //posArray += 1;

                dataGrid.ItemsSource = customerService.GetCustomers();
            }
    }

        private void RemoveCustomer_Click(object sender, RoutedEventArgs e)
        {

            if (dataGrid.SelectedItem is Customer)
            {
                string customerId = (dataGrid.SelectedItem as Customer).CustomerId;
                if (!this.customerService.ExistOrdersAssignedToCustomer(customerId))
                {
                    this.customerService.RemoveCustomer(customerId);
                }
                else
                {
                    MessageBox.Show("El cliente no puede ser eliminado porque existen ordenes asignadas a él.");
                }


                dataGrid.ItemsSource = customerService.GetCustomers();

            }
        }
    }

}
