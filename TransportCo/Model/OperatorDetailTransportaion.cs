using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using TransportCo.DTO;
using TransportCo.View.Administrator;
using TransportCo.View.Operator;

namespace TransportCo.Model
{
    public class OperatorDetailTransportaion : INotifyPropertyChanged
    {
        public int Number { get; set; }
        public int Num_Sending_storage { get; set; }
        public string Status { get; set; }
        public string RequestStatus { get; set; }
        public DateTime Date_dispatch { get; set; }


        public string Vehicle_identification_number { get; set; }
        public string Name { get; set; }

        public string fullName { get; set; }
        public string phoneNumber { get; set; }

        public List<ProductForListDTO> ProductsList { get; set; } = null;

        private void RefreshAll()
        {
            var copy = OperatorWindow._mng.SelectedTransportation;
            OperatorWindow._mng.GetTransportations = MyHttp.MyHttpClient.GetGetTransportations();
            OperatorWindow._mng.SendTransportations = MyHttp.MyHttpClient.GetSendTransportations();
            OperatorWindow._mng.SelectedTransportation = copy;
        }

        private RelayCommand? recieveProducts;
        public RelayCommand RecieveProducts
        {
            get
            {
                return recieveProducts ??
                    (recieveProducts = new RelayCommand(obj =>
                    {
                        string message = "Операция выполнена успешно";
                        MyHttp.MyHttpClient.RecieveProducts(Number, ref message);
                        RefreshAll();
                        MessageBox.Show(message);
                    }, 
                    obj => RequestStatus == "Доставляется"
                    ));
            }
        }

        private RelayCommand? sendProducts;
        public RelayCommand SendProducts
        {
            get
            {
                return sendProducts ??
                    (sendProducts = new RelayCommand(obj =>
                    {
                        string message = "Операция выполнена успешно";
                        MyHttp.MyHttpClient.SendProducts(Number, ref message);
                        RefreshAll();
                        MessageBox.Show(message);
                    },
                    obj => RequestStatus == "Обрабатывается"
                    ));
            }
        }

        private RelayCommand? cancelTransportation;
        public RelayCommand CancelTransportation
        {
            get
            {
                return cancelTransportation ??
                    (cancelTransportation = new RelayCommand(obj =>
                    {
                        string message = "Операция выполнена успешно";
                        MyHttp.MyHttpClient.CancelTransportation(Number, ref message);
                        RefreshAll();
                        MessageBox.Show(message);
                    },
                    obj => RequestStatus == "Обрабатывается"
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
