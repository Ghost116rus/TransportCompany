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
using TransportCo.View.Administrator.UniversalWnd;

namespace TransportCo.ViewModel
{
    public class DataManagerAdminVM : INotifyPropertyChanged
    {
        #region Общие методы и поля

        private UniversalWindow newUniversalWnd = new UniversalWindow();

        public void ViewPendingOrder(int NumberOfOrder)
        {
            DetailOrder = MyHttp.MyHttpClient.GetDetailOrderInfo(NumberOfOrder);
            newUniversalWnd = new UniversalWindow();
            newUniversalWnd._universalFrame.Content = OrdersPage._detailPandingPage;

            newUniversalWnd.Owner = AdministratorWindow._window;
            newUniversalWnd.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newUniversalWnd.ShowDialog();
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
                newUniversalWnd = new UniversalWindow();
                newUniversalWnd._universalFrame.Content = null;

                newUniversalWnd.Owner = AdministratorWindow._window;
                newUniversalWnd.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                newUniversalWnd.ShowDialog();
            }
        }

        #endregion


        #region Главная страница

        private List<Orders> mainPageOrders = MyHttp.MyHttpClient.GetPendingOrders();

        public List<Orders> MainPageOrders
        {
            get { return mainPageOrders; }
            set { mainPageOrders = value; NotifyPropertyChanged("MainPageOrders"); }
        }


        private List<Transportation> activeTransportations = MyHttp.MyHttpClient.GetActiveTransportations();

        public List<Transportation> ActiveTransportations
        {
            get { return activeTransportations; }
            set { activeTransportations = value; NotifyPropertyChanged("ActiveTransportations"); }
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
                if (value != null) { ViewOrder(); }
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


        public void ViewOrder()
        {
            DetailOrder = MyHttp.MyHttpClient.GetDetailOrderInfo(SelectedOrder.Number);
            if (DetailOrder.transportation == null)
            {
                OrdersPage._orderDetailFrame.Content = OrdersPage._detailPandingPage;
            }
            else if (DetailOrder.transportation != null)
            {
                OrdersPage._orderDetailFrame.Content = OrdersPage._detaiOrderPage;
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

        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
