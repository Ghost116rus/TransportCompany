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
using System.Windows.Shapes;
using TransportCo.ViewModel;

namespace TransportCo.View.Driver
{
    /// <summary>
    /// Логика взаимодействия для DriverWindow.xaml
    /// </summary>
    public partial class DriverWindow : Window
    {
        public static DriverWindow _wnd { get; set; }
        public DriverWindow()
        {
            InitializeComponent();
            DataContext = new DataManagerDriverVM();
            _wnd = this;
        }
    }
}
