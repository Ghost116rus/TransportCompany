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

namespace TransportCo.View.Administrator.UniversalWnd
{
    /// <summary>
    /// Логика взаимодействия для UniversalWindow.xaml
    /// </summary>
    public partial class UniversalWindow : Window
    {
        public Frame _universalFrame { get; set; }
        public UniversalWindow()
        {
            InitializeComponent();
            DataContext = AdministratorWindow._mng;

            _universalFrame = this.UniversalFrame;
        }
    }
}
