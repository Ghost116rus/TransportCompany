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
    /// Логика взаимодействия для SendTransportationPage.xaml
    /// </summary>
    public partial class SendTransportationPage : Page
    {
        public SendTransportationPage()
        {
            InitializeComponent();
            DataContext = OperatorWindow._mng;
        }
    }
}
