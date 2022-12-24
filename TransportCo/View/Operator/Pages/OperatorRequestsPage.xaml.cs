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

namespace TransportCo.View.Operator.Pages
{
    /// <summary>
    /// Логика взаимодействия для OperatorRequestsPage.xaml
    /// </summary>
    public partial class OperatorRequestsPage : Page
    {
        public static Frame _orderDetailFrame { get; set; }
        public static Page _operatorOrderDetailPage { get; set; }
        public OperatorRequestsPage()
        {
            InitializeComponent();
            DataContext = OperatorWindow._mng;

            _orderDetailFrame = this.OrderDetail;
            _operatorOrderDetailPage = new OperatorOrderDetailPage();
        }
    }
}
