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

namespace TransportCo.View.Administrator.Pages.Products
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public static Frame _productDetailFrame { get; set; }
        public static ChangeDataOdProductPage _productChangeDataPage { get; set; }

        public ProductsPage()
        {
            InitializeComponent();
            DataContext = AdministratorWindow._mng;

            _productDetailFrame = this.ProductDetail;

            _productChangeDataPage = new ChangeDataOdProductPage();
        }
    }
}
