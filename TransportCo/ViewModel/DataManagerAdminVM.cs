using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TransportCo.Model;
using TransportCo.View.Administrator;
using TransportCo.View.Administrator.Pages.OrdersP;
using TransportCo.View.Administrator.Pages.Products;
using TransportCo.View.Administrator.Pages.TransportationP;
using TransportCo.View.Administrator.UniversalWnd;

namespace TransportCo.ViewModel
{
    public class DataManagerAdminVM : INotifyPropertyChanged
    {
        #region Общие методы

        private bool WndNowActive = false;

        private UniversalWindow newUniversalWnd = new UniversalWindow();

        private void cleanAllPages()
        {
            OrdersPage._orderDetailFrame.Content = null;
            TransportationPage._transportationDetailFrame.Content = null;
        }

        private void CreateNewWnd()
        {
            if (newUniversalWnd.IsInitialized == true)
            {
                newUniversalWnd.Close();
            }
            newUniversalWnd = new UniversalWindow();
            newUniversalWnd.Owner = AdministratorWindow._window;
            newUniversalWnd.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            WndNowActive = true;
        }
        public void CloseUniversalWnd()
        {
            if (newUniversalWnd.IsInitialized == true)
            {
                newUniversalWnd.Close();
            }
        }

        private RelayCommand? createTransportationbtn;
        public RelayCommand CreateTransportationBtn
        {
            get
            {
                return createTransportationbtn ??
                    (createTransportationbtn = new RelayCommand(obj =>
                    {
                        CreateTransportation();
                    }
                    ));
            }
        }
        public void CreateTransportation()
        {
            if (newUniversalWnd.IsActive)
            {

                newUniversalWnd._universalFrame.Content = null;
            }
            else
            {
                CreateNewWnd();
                newUniversalWnd._universalFrame.Content = null;

                newUniversalWnd.ShowDialog();
                WndNowActive = false;
            }
        }

        public void ViewPendingOrder(int NumberOfOrder)
        {
            DetailOrder = MyHttp.MyHttpClient.GetDetailOrderInfo(NumberOfOrder);

            CreateNewWnd();
            newUniversalWnd._universalFrame.Content = OrdersPage._detailPandingPage;
            newUniversalWnd.ShowDialog();

            WndNowActive = false;
            cleanAllPages();
        }

        public void ViewTranspWnd(int numberOfTransp)
        {
            if (newUniversalWnd.IsActive)
            {

                ViewTransportatioDetails(numberOfTransp);
            }
            else
            {
                CreateNewWnd();
                ViewTransportatioDetails(numberOfTransp);

                newUniversalWnd.ShowDialog();
                WndNowActive = false;
                cleanAllPages();
            }
        }

        private void ViewOrderpWnd(int orderNumber)
        {
            if (newUniversalWnd.IsActive)
            {

                ViewOrder(orderNumber);
            }
            else
            {
                CreateNewWnd();
                ViewOrder(orderNumber);

                newUniversalWnd.ShowDialog();
                WndNowActive = false;
                cleanAllPages();
            }

        }

        #endregion


        #region Общие заявки и перевозки

        private List<Transportation> activeTransportations = MyHttp.MyHttpClient.GetActiveTransportations();

        public List<Transportation> ActiveTransportations
        {
            get { return activeTransportations; }
            set { activeTransportations = value; NotifyPropertyChanged("ActiveTransportations"); }
        }


        #endregion


        #region Главная страница

        private List<Orders> mainPageOrders = MyHttp.MyHttpClient.GetPendingOrders();

        public List<Orders> MainPageOrders
        {
            get { return mainPageOrders; }
            set { mainPageOrders = value; NotifyPropertyChanged("MainPageOrders"); }
        }

        private List<EventLog> allEvents = MyHttp.MyHttpClient.GetEventsLog();

        public List<EventLog> AllEvents
        {
            get { return allEvents; }
            set { allEvents = value; NotifyPropertyChanged("AllEvents"); }
        }



        #endregion

        #region Страница заявок

        private TabItem? selectedTabItem;
        public TabItem SelectedTabItem
        {
            get { return selectedTabItem; }
            set 
            { 
                selectedTabItem = value;
                RefreshOrders();
            }
        }

        private Orders? selectedOrder = null;
        public Orders? SelectedOrder
        {
            get { return selectedOrder; }
            set 
            { 
                selectedOrder = value;
                if (value != null) { ViewOrder(selectedOrder.Number); }
                //else { OrdersPage._orderDetailFrame.Content = null; }

                NotifyPropertyChanged("SelectedOrder");
            }
        }

        private Orders? detailOrder;
        public Orders? DetailOrder
        {
            get { return detailOrder; }
            set { detailOrder = value; NotifyPropertyChanged("DetailOrder"); }
        }

        private List<Orders>? pendingOrders;
        public List<Orders> PendingOrders
        {
            get { return pendingOrders; }
            set { pendingOrders = value; NotifyPropertyChanged("PendingOrders"); }
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
            Page? detailPage = null;
            if (DetailOrder.transportationNum == -1)
            {
                detailPage = OrdersPage._detailPandingPage;
            }
            else if (DetailOrder.transportationNum != -1)
            {
                detailPage = OrdersPage._detaiOrderPage;
            }
            if (WndNowActive)
            {
                newUniversalWnd._universalFrame.Content = detailPage;
            }
            else
            {
                OrdersPage._orderDetailFrame.Content = detailPage;
            }

        }

        private RelayCommand? openWndTranspDetail;
        public RelayCommand OpenWndTranspDetail
        {
            get
            {
                return openWndTranspDetail ??
                    (openWndTranspDetail = new RelayCommand(obj =>
                    {
                        if (DetailOrder.transportationNum != -1)
                        {
                            ViewTranspWnd(DetailOrder.transportationNum);
                        }

                    }
                    ));
            }
        }


        private void RefreshOrders()
        {
            PendingOrders = MyHttp.MyHttpClient.GetPendingOrders();
            AllOrders = MyHttp.MyHttpClient.GetAllOrders();
            if (DetailOrder != null)
            {
                DetailOrder = MyHttp.MyHttpClient.GetDetailOrderInfo(DetailOrder.Number);
            }
        }
        private void CleanOrdersPage()
        {
            SelectedOrder = null;
            OrdersPage._orderDetailFrame.Content = null;
            DetailOrder = null;
            AllOrders = null;
            PendingOrders = null;
        }

        #endregion

        #region Страница товаров

        private Product? selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set 
            { 
                selectedProduct = value;
                if (value == null) 
                    { ProductsPage._productDetailFrame.Content = null; } 
                NotifyPropertyChanged("SelectedProduct");
            }
        }




        private List<Product> allProducts = MyHttp.MyHttpClient.GetAllProducts();
        public List<Product> AllProducts 
        { 
            get { return allProducts; }
            set { allProducts = value; NotifyPropertyChanged("AllProducts"); }
        }

        public void Change(Product product)
        {
            SelectedProduct = product;
            
            if (ProductsPage._productDetailFrame.Content != ProductsPage._productChangeDataPage)
            {
                ProductsPage._productDetailFrame.Content = ProductsPage._productChangeDataPage;
            }

        }

        #endregion

        #region Страница Перевозок

        private List<Transportation> allTransportations = MyHttp.MyHttpClient.GetAllTransportations();

        public List<Transportation> AllTransportations
        {
            get { return allTransportations; }
            set { allTransportations = value; NotifyPropertyChanged("AllTransportations"); }
        }

        private Transportation? detailTransportation;
        public Transportation DetailTransportation
        {
            get { return detailTransportation; }
            set { detailTransportation = value; NotifyPropertyChanged("DetailTransportation"); }
        }

        private RelayCommand? openWndOrderDetail;
        public RelayCommand OpenWndOrderDetail
        {
            get
            {
                return openWndOrderDetail ??
                    (openWndOrderDetail = new RelayCommand(obj =>
                    {
                        ViewOrderpWnd(DetailTransportation.OrderNumber);
                    }
                    ));
            }
        }

        public void ViewTransportatioDetails(int number)
        {
            DetailTransportation = MyHttp.MyHttpClient.GetDetailTransportationInfo(number);
            if (WndNowActive)
            {
                newUniversalWnd._universalFrame.Content = TransportationPage._detailTransportationPage;
            }
            else
            {
                TransportationPage._transportationDetailFrame.Content = TransportationPage._detailTransportationPage;
            }

        }

        #endregion

        #region Кнопки Обновить данные

        private RelayCommand? updateOrders;
        public RelayCommand UpdateOrders
        {
            get
            {
                return updateOrders ??
                    (updateOrders = new RelayCommand(obj =>
                    {
                        RefreshOrders();
                        allEvents = MyHttp.MyHttpClient.GetEventsLog();
                    }));
            }
        }

        #endregion

        #region Кнопки перехода между страницами

        private RelayCommand? openOrdersPage;
        public RelayCommand OpenOrdersPage
        {
            get
            {
                return openOrdersPage ??
                    (openOrdersPage = new RelayCommand(obj =>
                    {
                        CleanOrdersPage();
                        RefreshOrders();
                        allEvents = MyHttp.MyHttpClient.GetEventsLog();
                        AdministratorWindow._mainFrame.Content = AdministratorWindow._ordersPage;
                    }));
            }
        }

        private RelayCommand? mainp;
        public RelayCommand MainP
        {
            get
            {
                return mainp ??
                    (mainp = new RelayCommand(obj =>
                    {
                        //
                        CleanOrdersPage();
                        allEvents = MyHttp.MyHttpClient.GetEventsLog();
                        AdministratorWindow._mainFrame.Content = AdministratorWindow._mainPage;
                    }));
            }
        }

        private RelayCommand? productP;
        public RelayCommand ProductP
        {
            get
            {
                return productP ??
                    (productP = new RelayCommand(obj =>
                    {
                        //
                        SelectedProduct = null;
                        allEvents = MyHttp.MyHttpClient.GetEventsLog();
                        AdministratorWindow._mainFrame.Content = AdministratorWindow._productsPage;
                    }));
            }
        }

        private RelayCommand? transporationP;
        public RelayCommand TransporationP
        {
            get
            {
                return transporationP ??
                    (transporationP = new RelayCommand(obj =>
                    {
                        //
                        allEvents = MyHttp.MyHttpClient.GetEventsLog();
                        AdministratorWindow._mainFrame.Content = AdministratorWindow._transportationPage;
                    }));
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
