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


namespace TransportCo.View.Operator.Pages.Transportation
{
    /// <summary>
    /// Логика взаимодействия для TransportationsPage.xaml
    /// </summary>
    public partial class TransportationsPage : Page
    {
        public static Frame _transportationDetailFrame { get; set; }
        public static Page _GetTransportationPage { get; set; }
        public static Page _SendTransportationPage { get; set; }
        public TransportationsPage()
        {
            InitializeComponent();
            DataContext = OperatorWindow._mng;
            _transportationDetailFrame = this.TransportationDetail;
            _GetTransportationPage = new GetTransportationPage();
            _SendTransportationPage = new SendTransportationPage();
        }
    }
}
