using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TransportCo.Model;
using TransportCo.Model.Operator;
using TransportCo.View.Administrator;
using TransportCo.View.Administrator.Pages.OrdersP;
using TransportCo.View.Administrator.Pages.Products;
using TransportCo.View.Operator;
using TransportCo.View.Operator.Pages;
using TransportCo.View.Operator.YesOrNoWnd;

namespace TransportCo.ViewModel
{
    public class DataManagerOperatorVM : INotifyPropertyChanged
    {
        #region Главная страница

        #region Начало работы

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; NotifyPropertyChanged("UserName"); }
        }

        private int? storageNum;
        public int? StorageNum
        {
            get { return storageNum; }
            set { storageNum = value; NotifyPropertyChanged("StorageNum"); }
        }

        public DataManagerOperatorVM()
        {
            UserName = Model.User.CurrentUser.Name;
            StorageNum = Model.User.CurrentUser.ForignKeyToStorage;
        }

        #endregion

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

        #region Создание новой заявки

        private List<ProductOrder> allProductsCopy;

        private List<ProductOrder> allProducts;
        public List<ProductOrder> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; NotifyPropertyChanged("AllProducts"); }
        }

        #region Автоподсчитываемые свойства

        private int total_cost = 0;
        public int Total_cost
        {
            get { return total_cost; }
            set
            {
                total_cost = value;
                NotifyPropertyChanged("Total_cost");
            }
        }

        private int total_mass = 0;
        public int Total_mass
        {
            get { return total_mass; }
            set
            {
                total_mass = value;
                NotifyPropertyChanged("Total_mass");
            }
        }

        private int total_volume = 0;
        public int Total_volume
        {
            get { return total_volume; }
            set
            {
                total_volume = value;
                NotifyPropertyChanged("Total_volume");
            }
        }

        public void ResolveAuto(int old_count, int new_count, int cost, int volume, int mass)
        {
            Total_cost += cost * (new_count - old_count);
            Total_mass += mass * (new_count - old_count);
            Total_volume += volume * (new_count - old_count);
        }

        #endregion


        #region Работа со списком на заявку


        private void InsertIntoOrderProducts(ProductOrder value)
        {
            if (!OrderProducts.Exists(x => x == value))
            {
                OrderProducts.Insert(0, value); RefreshProductList();
            }

        }

        public void DeleteProductFromOrder(ProductOrder productOrder)
        {
            OrderProducts.Remove(productOrder); RefreshProductList();
        }
        private void RefreshProductList()
        {
            OperatorWindow._createPage.ProductList.Items.Refresh();
        }
        private void CleanAllInCreateOrderPage()
        {
            foreach (var item in AllProducts)
            {
                item.Count = 0;
            }

            OrderProducts = new List<ProductOrder>();
            SearchName = "";
            Total_cost = 0;
            Total_mass = 0;
            Total_volume = 0;

            RefreshProductList();
        }

        #endregion

        private string searchName = "";
        public string SearchName
        {
            get { return searchName; } 
            set
            {
                searchName = value;
                if (searchName != "")
                {
                    AllProducts = MyHttp.MyHttpClient.GetProductsListByName(searchName);
                }
                else
                {
                    AllProducts = allProductsCopy;
                }
                
                NotifyPropertyChanged("SearchName");
            }
        }

        private List<ProductOrder> orderProducts = new List<ProductOrder>();
        public List<ProductOrder> OrderProducts
        {
            get { return orderProducts; }
            set { orderProducts = value; NotifyPropertyChanged("OrderProducts"); }
        }

        private ProductOrder selectedProductToOrder;
        public ProductOrder SelectedProductToOrder
        {
            get { return selectedProductToOrder; }
            set
            {
                if (value != null)
                {
                    InsertIntoOrderProducts(value);
                }
                selectedProductToOrder = value;
            }
        }

        public void GetAllPRoducts()
        {
            allProductsCopy = MyHttp.MyHttpClient.GetAllProductsForOrder();
            AllProducts = allProductsCopy;
        }

        // Создание наконец заявки 

        private RelayCommand? сreateNewOrder;
        public RelayCommand CreateNewOrder
        {
            get
            {
                return сreateNewOrder ??
                    (сreateNewOrder = new RelayCommand(obj =>
                    {
                        if (Total_volume < 500)
                        {
                            MessageBox.Show("Слишком мало набранных товаров!\nНе отправлю такую заявку - возьмите больше товаров. Нужно хотя бы 500л");
                        }
                        else if (Total_volume > MyHttp.MyHttpClient.max_volume)
                        {
                            MessageBox.Show("Слишком много товаров -  мы столько перевезти не способны.");
                        }
                        else if (Total_mass > MyHttp.MyHttpClient.maxWeight)
                        {
                            MessageBox.Show("Слишком тяжело -  ни одна машина не потянет.");
                        }
                        else
                        {
                            string error = "";
                            if (!MyHttp.MyHttpClient.CreateNewOrder(OrderProducts, total_cost, total_mass, total_volume, ref error))
                            {
                                MessageBox.Show(error);
                            }
                            else
                            {
                                MessageBox.Show("Заявка успешно создана!"); 
                            }
                            CleanAllInCreateOrderPage();
                        }
                    }));
            }
        }


        #endregion

        #region Переход между страницами


        private RelayCommand? openMainPage;
        public RelayCommand OpenMainPage
        {
            get
            {
                return openMainPage ??
                    (openMainPage = new RelayCommand(obj =>
                    {
                        CleanAllInCreateOrderPage();
                        OperatorWindow._mainFrame.Content = OperatorWindow._mainPage;

                    }));
            }
        }

        private RelayCommand? openCreateOrderPage;
        public RelayCommand OpenCreateOrderPage
        {
            get
            {
                return openCreateOrderPage ??
                    (openCreateOrderPage = new RelayCommand(obj =>
                    {
                        //CleanAllInCreateOrderPage();
                        OperatorWindow._mainFrame.Content = OperatorWindow._createPage;

                    }));
            }
        }

        private RelayCommand? openOrdersPage;
        public RelayCommand OpenOrdersPage
        {
            get
            {
                return openOrdersPage ??
                    (openOrdersPage = new RelayCommand(obj =>
                    {
                        //CleanAllInCreateOrderPage();
                        AllOrders = MyHttp.MyHttpClient.GetAllOrders();
                        OperatorWindow._mainFrame.Content = OperatorWindow._requestPage;

                    }));
            }
        }


        #endregion

        #region Кнопки обновления данных

        private RelayCommand? refreshMainP;
        public RelayCommand RefreshMainP
        {
            get
            {
                return refreshMainP ??
                    (refreshMainP = new RelayCommand(obj =>
                    {
                        RefreshDataAboutProduct();
                        GetAllPRoducts();
                    }));
            }
        }

        #endregion

        #region Снова страница Заявок

        private Orders? selectedOrder = null;
        public Orders? SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                if (value != null) { ViewOrder(selectedOrder.Number); }
                else { OperatorRequestsPage._orderDetailFrame.Content = null; }

                NotifyPropertyChanged("SelectedOrder");
            }
        }

        private Orders? detailOrder;
        public Orders? DetailOrder
        {
            get { return detailOrder; }
            set { detailOrder = value; NotifyPropertyChanged("DetailOrder"); }
        }

        private List<Orders>? allOrders;
        public List<Orders> AllOrders
        {
            get { return allOrders; }
            set { allOrders = value; NotifyPropertyChanged("AllOrders"); }
        }

        public void ViewOrder(int number)
        {
            DetailOrder = MyHttp.MyHttpClient.GetDetailOrderInfo(number);

            OperatorRequestsPage._orderDetailFrame.Content = OperatorRequestsPage._operatorOrderDetailPage;
        }

        #endregion


        #region Кнопка выйти

        void Exit()
        {
            StartWindow authorizationWindow = new StartWindow();
            authorizationWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            authorizationWindow.Show();
            OperatorWindow._window.Close();
        }

        private RelayCommand goOut;
        public RelayCommand GoOut
        {
            get
            {
                return goOut ?? new RelayCommand(obj =>
                {
                    Exit();
                }
                );
            }
        }

        #endregion


        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
