using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TransportCo.Model;
using TransportCo.MyHttp;
using TransportCo.View.Administrator;
using TransportCo.View.Administrator.Pages.Drivers;
using TransportCo.View.Administrator.Pages.OrdersP;
using TransportCo.View.Administrator.Pages.Products;
using TransportCo.View.Administrator.Pages.StoragesP;
using TransportCo.View.Administrator.Pages.TransportationP;
using TransportCo.View.Administrator.Pages.Vehicles;
using TransportCo.View.Administrator.UniversalWnd;
using TransportCo.View.Operator;

namespace TransportCo.ViewModel
{
    public class DataManagerAdminVM : INotifyPropertyChanged
    {
        #region Первичные методы

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; NotifyPropertyChanged("UserName"); }
        }

        public DataManagerAdminVM()
        {
            UserName = Model.User.CurrentUser.Name;
            allTransportations = MyHttp.MyHttpClient.GetAllTransportations();
            allProducts = MyHttp.MyHttpClient.GetAllProducts();
            allStorages = MyHttp.MyHttpClient.GetAllStorage();


            allDrivers = MyHttp.MyHttpClient.GetAllDrivers();
            allVehicles = MyHttp.MyHttpClient.GetAllVehicles();
        }

        #endregion

        #region Общие методы

        private bool WndNowActive = false;

        private UniversalWindow newUniversalWnd = new UniversalWindow();

        private void cleanAllPages()
        {
            OrdersPage._orderDetailFrame.Content = null;
            TransportationPage._transportationDetailFrame.Content = null;
            DriversPage._driverInfoFrame.Content = null;
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
            CreateNewTransportationClass = new CreateNewTransportation(DetailOrder, AdministratorWindow._createTransportationPage);
            if (newUniversalWnd.IsActive)
            {
                newUniversalWnd._universalFrame.Content = AdministratorWindow._createTransportationPage;
            }
            else
            {
                CreateNewWnd();
                newUniversalWnd._universalFrame.Content = AdministratorWindow._createTransportationPage;

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
        public void ViewDriverpWnd(string driver_license)
        {
            if (newUniversalWnd.IsActive)
            {

                ViewDetailDriverInfo(driver_license);
            }
            else
            {
                CreateNewWnd();
                ViewDetailDriverInfo(driver_license);

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

        public Transportation? SelectedTransportation { get; set; } = null;

        private RelayCommand? viewSelectedTransportation;
        public RelayCommand ViewSelectedTransportation
        {
            get
            {
                return viewSelectedTransportation ??
                    (viewSelectedTransportation = new RelayCommand(obj =>
                    {
                        if (SelectedTransportation != null)
                        {
                            ViewTranspWnd(SelectedTransportation.Number);
                        }

                    }
                    ));
            }
        }

        private List<Orders> mainPageOrders = MyHttp.MyHttpClient.GetPendingOrders();

        public List<Orders> MainPageOrders
        {
            get { return mainPageOrders; }
            set { mainPageOrders = value; NotifyPropertyChanged("MainPageOrders"); }
        }



        #endregion

        #region Страница заявок

        private TabItem? selectedTabItemOrders;
        public TabItem SelectedTabItemOrders
        {
            get { return selectedTabItemOrders; }
            set 
            { 
                selectedTabItemOrders = value;
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

        private RelayCommand? openWndDriverDetail;
        public RelayCommand OpenWndDriverDetail
        {
            get
            {
                return openWndDriverDetail ??
                    (openWndDriverDetail = new RelayCommand(obj =>
                    {
                        if (DetailOrder.transportationNum != -1)
                        {
                            ViewDriverpWnd(DetailOrder.DriverLicense);
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


        private List<Product> allProducts;
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
        
        private void SaveChangesAboutProductInDB(ref string message)
        {
            MyHttp.MyHttpClient.SaveChangesAboutProductInDB(SelectedProduct, ref message);
        }

        private RelayCommand? saveChangesAboutProduct;
        public RelayCommand SaveChangesAboutProduct
        {
            get
            {
                return saveChangesAboutProduct ??
                    (saveChangesAboutProduct = new RelayCommand(obj =>
                    {
                        string message = "";
                        if (SelectedProduct != null)
                        {
                            if (SelectedProduct.Type == "крупногабаритный" || SelectedProduct.Type == "малогабаритный")
                            {
                                SaveChangesAboutProductInDB(ref message);
                                if (message == "Данные успешно сохранены")
                                {
                                    SelectedProduct = null;
                                }
                            }
                            else
                            {
                                message = "Вы должны ввести в тип либо \"крупногабаритный\", либо \"малогабаритный\"";
                            }

                            MessageBox.Show(message);
                        }
                    }
                    ));
            }
        }

        #endregion

        #region Страница складов

        private Storage? storage;
        public Storage SelectedStorage
        {
            get { return storage; }
            set
            {
                storage = value;
                if (value != null) { ViewProductList(storage.Number); }
                else { StoragesPage._productListFrame.Content = null; }
                NotifyPropertyChanged("SelectedStorage");
            }
        }

        private List<Storage> allStorages;
        public List<Storage> AllStorages
        {
            get { return allStorages; }
            set { allStorages = value; NotifyPropertyChanged("AllStorages"); }
        }

        private void ViewProductList(int number)
        {
            if (storage.Products == null)
            {
                storage.Products = MyHttp.MyHttpClient.GetProductListForStorageByNumber(number);
            }
            StoragesPage._productListFrame.Content = StoragesPage._productListPage;
        }

        #endregion

        #region Работа с водителями

        private Driver selectedDriver;
        public Driver SelectedDriver
        {
            get { return selectedDriver; }
            set 
            {
                selectedDriver = value;
                if (value != null) { ViewDetailDriverInfo(SelectedDriver.DriverLicense); }
                else { DriversPage._driverInfoFrame.Content = null; }
                NotifyPropertyChanged("SelectedDriver");
            }
        }
        private Driver? detailDriverInfo;
        public Driver DetailDriverInfo
        {
            get { return detailDriverInfo; }
            set { detailDriverInfo = value; NotifyPropertyChanged("DetailDriverInfo"); }
        }

        private void ViewDetailDriverInfo(string driverLicense)
        {
            DetailDriverInfo = MyHttpClient.GetDetailInfoAboutDriver(driverLicense);
            if (WndNowActive)
            {
                newUniversalWnd._universalFrame.Content = DriversPage._driverInfoPage;
            }
            else
            {
                DriversPage._driverInfoFrame.Content = DriversPage._driverInfoPage;
            }
        }

        private List<Driver> allDrivers;
        public List<Driver> AllDrivers
        {
            get { return allDrivers; }
            set { allDrivers = value; NotifyPropertyChanged("AllDrivers"); }
        }

        #endregion

        #region Страница машин

        private Transport_vehicle selectedVehicle;
        public Transport_vehicle SelectedVehicle
        {
            get { return selectedVehicle; }
            set
            {
                selectedVehicle = value;
                if (value != null) { ViewDetailVehicleInfo(SelectedVehicle.Vehicle_identification_number); }
                else { TransportVehiclePage._vehicleInfoFrame.Content = null; }
                NotifyPropertyChanged("SelectedVehicle");
            }
        }
        private Transport_vehicle? detailVehicleInfo;
        public Transport_vehicle DetailVehicleInfo
        {
            get { return detailVehicleInfo; }
            set { detailVehicleInfo = value; NotifyPropertyChanged("DetailVehicleInfo"); }
        }

        private void ViewDetailVehicleInfo(string Vehicle_identification_number)
        {
            DetailVehicleInfo = MyHttpClient.GetDetailInfoAboutVehicle(Vehicle_identification_number);
            if (WndNowActive)
            {
                newUniversalWnd._universalFrame.Content = TransportVehiclePage._detailVehiclePage;
            }
            else
            {
                TransportVehiclePage._vehicleInfoFrame.Content = TransportVehiclePage._detailVehiclePage;
            }
        }

        private List<Transport_vehicle> allVehicles;
        public List<Transport_vehicle> AllVehicles
        {
            get { return allVehicles; }
            set { allVehicles = value; NotifyPropertyChanged("AllVehicles"); }
        }

        public void RefreshVehicles()
        {
            allVehicles = MyHttp.MyHttpClient.GetAllVehicles();
            if (DetailVehicleInfo != null)
            {
                ViewDetailVehicleInfo(DetailVehicleInfo.Vehicle_identification_number);
            }
        }

        #endregion

        #region Страница Перевозок

        private TabItem? selectedTabItemTransportation;
        public TabItem SelectedTabItemTransportation
        {
            get { return selectedTabItemTransportation; }
            set
            {
                selectedTabItemTransportation = value;
                RefreshTransportations();
            }
        }

        private List<Transportation> allTransportations;

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

        private void CleanTransportationPage()
        {
            SelectedOrder = null;
            TransportationPage._transportationDetailFrame.Content = null;
            DetailTransportation = null;
            ActiveTransportations = null;
            AllTransportations = null;
        }

        private void RefreshTransportations()
        {
            ActiveTransportations = MyHttp.MyHttpClient.GetActiveTransportations();
            AllTransportations = MyHttp.MyHttpClient.GetAllTransportations();
            if (DetailTransportation != null)
            {
                DetailTransportation = MyHttp.MyHttpClient.GetDetailTransportationInfo(DetailTransportation.Number);
            }
        }

        private RelayCommand? openWndDriverDetailFromTransportation;
        public RelayCommand OpenWndDriverDetailFromTransportation
        {
            get
            {
                return openWndDriverDetailFromTransportation ??
                    (openWndDriverDetailFromTransportation = new RelayCommand(obj =>
                    {
                        ViewDriverpWnd(DetailTransportation.driver.DriverLicense);
                    }
                    ));
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
                    }));
            }
        }

        private RelayCommand? refreshVehiclePage;
        public RelayCommand RefreshVehiclePage
        {
            get
            {
                return refreshVehiclePage ??
                    (refreshVehiclePage = new RelayCommand(obj =>
                    {
                        RefreshVehicles();
                    }));
            }
        }



        #endregion

        #region Кнопки перехода между страницами

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
                        AdministratorWindow._mainFrame.Content = AdministratorWindow._mainPage;
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
                        CleanOrdersPage();
                        RefreshOrders();                        
                        AdministratorWindow._mainFrame.Content = AdministratorWindow._ordersPage;
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
                        AdministratorWindow._mainFrame.Content = AdministratorWindow._productsPage;
                    }));
            }
        }


        private RelayCommand? storageP;
        public RelayCommand StorageP
        {
            get
            {
                return storageP ??
                    (storageP = new RelayCommand(obj =>
                    {
                        //
                        SelectedStorage = null;                        
                        AdministratorWindow._mainFrame.Content = AdministratorWindow._storagesPage;
                    }));
            }
        }


        private RelayCommand? driversP;
        public RelayCommand DriversP
        {
            get
            {
                return driversP ??
                    (driversP = new RelayCommand(obj =>
                    {
                        SelectedDriver = null;                      
                        AdministratorWindow._mainFrame.Content = AdministratorWindow._driversPage;
                    }));
            }
        }

        private RelayCommand? vehicleP;
        public RelayCommand VehicleP
        {
            get
            {
                return vehicleP ??
                    (vehicleP = new RelayCommand(obj =>
                    {
                        //                        
                        AdministratorWindow._mainFrame.Content = AdministratorWindow._transportVehiclePage;
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
                        CleanTransportationPage();
                        RefreshTransportations();                        
                        AdministratorWindow._mainFrame.Content = AdministratorWindow._transportationPage;
                    }));
            }
        }

        #endregion

        #region Кнопка выйти

        void Exit()
        {
            StartWindow authorizationWindow = new StartWindow();
            authorizationWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            authorizationWindow.Show();
            AdministratorWindow._window.Close();
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


        #region Раздел создания

        #region Создание перевозки



        private CreateNewTransportation? createNewTransportationClass;
        public CreateNewTransportation CreateNewTransportationClass
        {
            get { return createNewTransportationClass; }
            set { createNewTransportationClass = value; NotifyPropertyChanged("CreateNewTransportationClass"); }
        }

        #endregion

        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
