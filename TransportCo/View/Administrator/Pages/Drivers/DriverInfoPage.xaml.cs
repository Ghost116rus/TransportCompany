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

namespace TransportCo.View.Administrator.Pages.Drivers
{
    /// <summary>
    /// Логика взаимодействия для DriverInfoPage.xaml
    /// </summary>
    public partial class DriverInfoPage : Page
    {
        public DriverInfoPage()
        {
            InitializeComponent();
            DataContext = AdministratorWindow._mng;
        }
    }
}
