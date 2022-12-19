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

namespace TransportCo.View.Operator.YesOrNoWnd
{
    /// <summary>
    /// Логика взаимодействия для DialogWnd.xaml
    /// </summary>
    public partial class DialogWnd : Window
    {
        public DialogWnd()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OperatorWindow._mng.UserSayTrue = true;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OperatorWindow._mng.UserSayTrue = false;
            this.Close();
        }
    }
}
