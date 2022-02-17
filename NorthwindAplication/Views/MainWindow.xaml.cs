using Northwind.Presentation.Views;
using Northwind.Presentation.Views.Customers;
using Northwind.Presentation.Views.Dashboard;
using Northwind.Presentation.Views.Reports;
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
                        this._contentUserControl.Content = new OrdersByDateView();
                        break;

                    case "Manual de Usuario":
                        try
                        {
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            string path = AppDomain.CurrentDomain.BaseDirectory + @"/Files/Manual de Usuario Northwind.pdf";
                            Uri pdf = new Uri(path, UriKind.RelativeOrAbsolute);
                            process.StartInfo.FileName = pdf.LocalPath;
                            process.Start();
                            process.WaitForExit();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Could not open the file.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                }
            }

        }

    }
}
