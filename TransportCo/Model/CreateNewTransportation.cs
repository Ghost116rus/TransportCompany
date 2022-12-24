using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TransportCo.DTO.CreateTransportation;
using TransportCo.View.Administrator;
using TransportCo.View.Administrator.Pages.TransportationP;

namespace TransportCo.Model
{
    public class CreateNewTransportation : INotifyPropertyChanged
    {
        // зона полей

        private CreateTransportationPage _page;

        private Orders _order;

        private int num_Sending_storage;
        private int total_length;
        private int car_load;
        private int total_shipping_cost;

        private string vehicleName;
        private string vehicleId;
        private string driverName;

        private bool IsComplete = false;

        // зона свойств
        public string RecievingAddres { get; set; }
        public int Num_Sending_storage
        {
            get { return num_Sending_storage; }
            set { num_Sending_storage = value; NotifyPropertyChanged("Num_Sending_storage"); }
        }

        public int Total_length
        {
            get { return total_length; }
            set { total_length = value; NotifyPropertyChanged("Total_length"); }
        }
        public int Car_load
        {
            get { return car_load; }
            set { car_load = value; _page.CarLoadLabel.Text = car_load.ToString(); }
        }
        public int Total_shipping_cost
        {
            get { return total_shipping_cost; }
            set { total_shipping_cost = value; _page.TotalLabel.Text = total_shipping_cost.ToString(); }
        }

        public string VehicleName
        {
            get { return vehicleName; }
            set { vehicleName = value; NotifyPropertyChanged("VehicleName"); }
        }
        public string VehicleId
        {
            get { return vehicleId; }
            set { vehicleId = value; NotifyPropertyChanged("VehicleId"); }
        }
        public string DriverName
        {
            get { return driverName; }
            set { driverName = value; NotifyPropertyChanged("DriverName"); }
        }

        public CreateNewTransportation(Orders order, CreateTransportationPage page)
        {
            _page = page;

            _order = order;
            StoragesList = MyHttp.MyHttpClient.GetStoragesByOrder(_order.Number);
            InfoStorageList = StoragesList.Select(s => new InfoObject
            {
                FirstString = s.Address,
                SecondString = s.TotalLength.ToString()
            }).ToList();

            RecievingAddres = order.Addres;

            _page.ComboboxStorage.Items.Refresh();
        }

        // Зона списков

        private List<SendingStoragesListDTO> StoragesList;
        public List<InfoObject> InfoStorageList { get; set; }

        private List<Vehicle> vehicleList;
        public List<InfoObject> InfoVehicleList { get; set; }

        private List<DriverForTrDTO> driverList;
        public List<InfoObject > InfoDriverList { get; set; }


        // Зона выбранных элементов

        private InfoObject selectedStorageNum;
        public InfoObject SelectedStorageNum
        {
            get { return selectedStorageNum; }
            set
            {
                selectedStorageNum = value;
                StorageIsSelected();
            }
        }

        private SendingStoragesListDTO selectedStorage;

        private void StorageIsSelected()
        {
            selectedStorage = StoragesList[_page.ComboboxStorage.SelectedIndex];
            Num_Sending_storage = selectedStorage.StorageID;
            Total_length = selectedStorage.TotalLength;

            vehicleList = MyHttp.MyHttpClient.GetVehiclesForOrder(selectedStorage.Address.Substring(0,
                selectedStorage.Address.IndexOf(',')), _order.Total_mass, _order.Total_volume);

            InfoVehicleList = vehicleList.Select(ts => new InfoObject
            {
                FirstString = ts.Name,
                SecondString = ts.Vehicle_identification_number
            }).ToList();

            _page.ComboboxVehicles.ItemsSource = InfoVehicleList;
            _page.ComboboxVehicles.Items.Refresh();
            _page.ComboboxVehicles.IsEnabled = true;
            _page.ComboboxDrivers.IsEnabled = false;
        }



        private InfoObject selectedVehicleIndex;
        public InfoObject SelectedVehicleIndex
        {
            get { return selectedVehicleIndex; }
            set
            {
                selectedVehicleIndex = value;
                if (value != null) { VehicleIsSelected(); }
                else
                {
                    Car_load = 0;
                    VehicleName = "";
                    VehicleId = "";
                }
                IsComplete = false;
            }
        }
        private Vehicle ts;

        private void VehicleIsSelected()
        {
            ts = vehicleList[_page.ComboboxVehicles.SelectedIndex];
            VehicleName = ts.Name;
            VehicleId = ts.Vehicle_identification_number;
            Car_load = (_order.Total_volume * 100 / ts.Transported_volume) ;

            driverList = MyHttp.MyHttpClient.GetDriverForOrder(selectedStorage.Address.Substring(0,
                selectedStorage.Address.IndexOf(',')), ts.Required_category);

            InfoDriverList = driverList.Select(dr => new InfoObject
            {
                FirstString = dr.Fullname,
                SecondString = dr.Expirience.ToString(),
                ThirdString = dr.CountOfTransportation.ToString(),
            }).ToList();

            _page.ComboboxDrivers.IsEnabled = true;
            _page.ComboboxDrivers.ItemsSource = InfoDriverList;
            _page.ComboboxDrivers.Items.Refresh();
        }

        private DriverForTrDTO driver;

        private InfoObject selectedDriverIndex;
        public InfoObject SelectedDriverIndex
        {
            get { return selectedDriverIndex; }
            set
            {
                selectedDriverIndex = value;
                if (value != null) { DriverIsSelected(); }
                else
                {
                    Total_shipping_cost = 0;
                    DriverName = "";
                }
            }
        }

        private void DriverIsSelected()
        {
            driver = driverList[_page.ComboboxDrivers.SelectedIndex];
            DriverName = driver.Fullname;
            var multiple = driver.Expirience > 3 ? (int)(driver.Expirience / 3) : 1;
            Total_shipping_cost = (int)(multiple * Total_length + 0.1 * _order.Total_cost + ts.Fuel_consumption * Total_length + ts.Fuel_consumption * _order.Total_mass);
            IsComplete = true;
        }


        private RelayCommand? createTrnsp;
        public RelayCommand CreateTrnsp
        {
            get
            {
                return createTrnsp ??
                    (createTrnsp = new RelayCommand(obj =>
                    {
                        string message = "Заявка успешно сохранена";
                        CreateTrnspRequest request = new CreateTrnspRequest()
                        {
                            requestNumber = _order.Number,
                            numSendingStorage = num_Sending_storage,
                            total_length = total_length,
                            car_load = car_load,
                            total_shipping_cost = total_shipping_cost,

                            vehicleID = ts.Vehicle_identification_number,
                            driverID = driver.Driver_license_number
                        };
                        MyHttp.MyHttpClient.CreateTransportation(request, ref message);
                        MessageBox.Show(message);
                        if (message == "Заявка успешно сохранена")
                        {
                            AdministratorWindow._mng.CloseUniversalWnd();
                        }
                    },
                    (e => IsComplete)
                    ));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

