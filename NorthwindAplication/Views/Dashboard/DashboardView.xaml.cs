using Microsoft.Reporting.WinForms;
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

namespace Northwind.Presentation.Views.Dashboard
{
    /// <summary>
    /// Lógica de interacción para InitView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();

            CustomerService customerService = new CustomerService();
            List<Customer> customers = customerService.GetCustomers();

            //Definición del rdlc que usará para mostrar los datos.
            this._reportViewer.LocalReport.ReportPath = "Reports/ReportCustomersPerCountry.rdlc";

            //Definición de la fuente de datos
            ReportDataSource TestDataSource = new ReportDataSource();
            TestDataSource.Name = "DataSetCustomers";
            TestDataSource.Value = customers;

            //Asociación del DataSource con el el reporte.
            this._reportViewer.LocalReport.DataSources.Add(TestDataSource);

            _reportViewer.RefreshReport();
        }
    }

}
