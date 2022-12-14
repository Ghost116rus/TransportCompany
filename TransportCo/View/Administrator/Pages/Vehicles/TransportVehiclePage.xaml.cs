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

namespace TransportCo.View.Administrator.Pages.Vehicles
{
    /// <summary>
    /// Логика взаимодействия для TransportVehiclePage.xaml
    /// </summary>
    public partial class TransportVehiclePage : Page
    {
        public static Frame _vehicleInfoFrame { get; set; }
        public static DetailVehiclePage _detailVehiclePage { get; set; }
        public TransportVehiclePage()
        {
            InitializeComponent();
            DataContext = AdministratorWindow._mng;

            _vehicleInfoFrame = this.VehicleInfo;
            _detailVehiclePage = new DetailVehiclePage();
        }
    }
}
