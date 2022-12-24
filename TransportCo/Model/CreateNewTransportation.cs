using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TransportCo.DTO.CreateTransportation;
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

        private string vehicleID;
        private string vriverId;


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
        public List<InfoObject> InfoVehicleList { get; set; }      

        private List<Vehicle> vehicleList;


        // Зона выбранных элементов

        private InfoObject selectedStorageNum;
        public InfoObject SelectedStorageNum
        {
            get { return selectedStorageNum; }
            set
            {
                selectedStorageNum = value; NotifyPropertyChanged("InfoStorages");
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
        }



        private InfoObject selectedVehicleIndex;
        public InfoObject SelectedVehicleIndex
        {
            get { return selectedVehicleIndex; }
            set
            {
                selectedVehicleIndex = value; NotifyPropertyChanged("SelectedVehicleIndex");
            }
        }




        private int selectedVehicle;
        public int SelectedVehicle
        {
            get { return selectedVehicle; }
            set
            {
                selectedVehicle = value;

                NotifyPropertyChanged("SelectedVehicle");
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

