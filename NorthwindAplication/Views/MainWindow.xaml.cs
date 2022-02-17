using Northwind.Presentation.Views;
using Northwind.Presentation.Views.Customers;
using Northwind.Presentation.Views.Dashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Northwind.Presentation
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public UserControl CenterApp { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this._contentUserControl.Content = new DashboardView();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(sender is MenuItem)
            {
                MenuItem item = sender as MenuItem;
                switch (item.Header)
                {
                    case "Clientes":
                        this._contentUserControl.Content = new CustomersView();
                        break;
                    case "Dashboard":
                        this._contentUserControl.Content = new DashboardView();
                        break;

                    case "Pedidos por fecha":
                        this._contentUserControl.Content = new DashboardView();
                        break;

                    case "Productos Comprados por cliente":
                        this._contentUserControl.Content = new DashboardView();
                        break;
                }
            }

        }

    }
}
