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
using TransportCo.View.Operator.Pages;
using TransportCo.View.Administrator;
using TransportCo.ViewModel;
using System.Text.RegularExpressions;

namespace TransportCo.View.Operator
{
    /// <summary>
    /// Логика взаимодействия для OperatorWindow.xaml
    /// </summary>
    public partial class OperatorWindow : Window
    {
        public static Frame _mainFrame { get; set; }
        public static DataManagerOperatorVM _mng { get; set; }
        public static OperatorWindow _window { get; set; }


        public static MainPagexaml _mainPage { get; set; }
        public static CreateOrderPage _createPage { get; set; }
        public OperatorWindow()
        {
            InitializeComponent();

            // Создание контекста данных
            _mng = new DataManagerOperatorVM();
            DataContext = _mng;

            // Создание и сохранение статических переменных
            _mainFrame = this.MainFrame;
            _window = this;
            _mainPage = new MainPagexaml();
            _createPage = new CreateOrderPage();

            //_mainFrame.Content = mainPage;
            _mainFrame.Content = _mainPage;
            _mng.RefreshDataAboutProduct();
            _mng.GetAllPRoducts();
        }

    }

}
