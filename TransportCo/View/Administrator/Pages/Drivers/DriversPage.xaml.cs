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
using TransportCo.View.Administrator.Pages.StoragesP;

namespace TransportCo.View.Administrator.Pages.Drivers
{
    /// <summary>
    /// Логика взаимодействия для DriversPage.xaml
    /// </summary>
    public partial class DriversPage : Page
    {
        public static Frame _driverInfoFrame { get; set; }
        public static DriverInfoPage _driverInfoPage{ get; set; }

        public DriversPage()
        {
            InitializeComponent();
            DataContext = AdministratorWindow._mng;

            _driverInfoFrame = this.DriverInfo;
            _driverInfoPage = new DriverInfoPage();
        }
    }
}
