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
using TransportCo.View.Administrator.Pages.Main;
using TransportCo.ViewModel;

namespace TransportCo.View.Administrator
{
    /// <summary>
    /// Логика взаимодействия для AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        public static Frame _mainFrame { get; set; }
        public static DataManagerAdminVM _mng { get; set; }
        public static AdministratorWindow _window { get; set; }
        public AdministratorWindow()
        {
            InitializeComponent();

            _mng = new DataManagerAdminVM();
            DataContext = _mng;

            _mainFrame = this.MainFrame;
            _window = this;

            _mainFrame.Content = new MainPage();
        }
    }
}
