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
using TransportCo.View.Administrator.Pages.OrdersP;
using TransportCo.View.Administrator.Pages.Products;
using TransportCo.View.Administrator.Pages.TransportationP;
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


        public static MainPage _mainPage { get; set; }
        public static OrdersPage _ordersPage { get; set; }
        public static ProductsPage _productsPage { get; set; }
        public static TransportationPage _transportationPage { get; set; }

        public static bool exit { get; set; } = false;


        public AdministratorWindow()
        {
            InitializeComponent();

            // Создание контекста данных
            _mng = new DataManagerAdminVM();
            DataContext = _mng;

            // Создание и сохранение статических переменных
            _mainFrame = this.MainFrame;
            _window = this;
            _mainPage = new MainPage();
            _ordersPage = new OrdersPage();
            _productsPage = new ProductsPage();

            _transportationPage= new TransportationPage();

            //_mainFrame.Content = mainPage;
            _mainFrame.Content = _mainPage;
        }

        protected override void OnClosed(EventArgs e)
        {
            if (exit)
            {

            }
            else
            {
                base.OnClosed(e);
                Application.Current.Dispatcher.InvokeShutdown();
            }

        }
    }
}
