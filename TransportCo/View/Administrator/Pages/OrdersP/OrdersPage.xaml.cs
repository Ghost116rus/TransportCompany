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

namespace TransportCo.View.Administrator.Pages.OrdersP
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {


        public static Frame _orderDetailFrame { get; set; }
        public static Page _detailPandingPage { get; set; }
        public static Page _detaiOrderPage { get; set; }

        public OrdersPage()
        {
            InitializeComponent();
            DataContext = AdministratorWindow._mng;
            _orderDetailFrame = this.OrderDetail;
            _detailPandingPage = new DetailOfPandingOrderPage();
        }
    }
}
