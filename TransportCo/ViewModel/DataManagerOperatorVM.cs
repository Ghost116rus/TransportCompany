using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TransportCo.Model;
using TransportCo.View.Administrator.Pages.Products;
using TransportCo.View.Operator.YesOrNoWnd;

namespace TransportCo.ViewModel
{
    public class DataManagerOperatorVM : INotifyPropertyChanged
    {
        #region Главная страница

        public bool IsChangedProduct = false;
        public bool UserSayTrue = false;
        private bool Skip = false;

        private int oldCount = 0;
        public void ChangeProduct(int Count, ProductOperator product)
        {
            if (!Skip)
            {
                if (SelectedProduct != product) { SelectedProduct = product; }
                oldCount = Count;
                IsChangedProduct = true;
                Skip = true;
            }
        }

        private ProductOperator? selectedProduct;
        public ProductOperator SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                if (IsChangedProduct && oldCount != SelectedProduct.Count)
                {
                    Window window = new DialogWnd();
                    window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    window.ShowDialog();
                    if (UserSayTrue)
                    {
                        bool answer = MyHttp.MyHttpClient.SaveChangesAboutCountInDB(SelectedProduct.Сatalogue_number, SelectedProduct.Count);

                        if (!answer)
                        {
                            SelectedProduct.Count = oldCount;
                        }
                    }
                    else
                    {
                        SelectedProduct.Count = oldCount;
                    }
                }

                IsChangedProduct = false;
                Skip = false;
                selectedProduct = value;
                //if (value == null)

                NotifyPropertyChanged("SelectedProduct");
            }
        }


        private List<ProductOperator> storageProducts;
        public List<ProductOperator> StorageProducts
        {
            get { return storageProducts; }
            set { storageProducts = value; NotifyPropertyChanged("StorageProducts"); }
        }

        public void RefreshDataAboutProduct()
        {
            Skip = true;
            StorageProducts = MyHttp.MyHttpClient.GetAllProductsByStorageNumber();
            Skip = false;
        }

        #endregion


        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
