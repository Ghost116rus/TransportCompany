﻿using System;
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

namespace TransportCo.View.Administrator.Pages.StoragesP
{
    /// <summary>
    /// Логика взаимодействия для StoragesPage.xaml
    /// </summary>
    /// 
    public partial class StoragesPage : Page
    {
        public static Frame _productListFrame { get; set; }
        public static ProductListPage _productListPage { get; set; }

        public StoragesPage()
        {
            InitializeComponent();
            DataContext = AdministratorWindow._mng;

            _productListFrame = this.ProductList;

            _productListPage = new ProductListPage();
        }
    }
}
