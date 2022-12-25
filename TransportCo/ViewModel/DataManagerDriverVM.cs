using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TransportCo.Model;
using TransportCo.MyHttp;
using TransportCo.View.Administrator;
using TransportCo.View.Driver;

namespace TransportCo.ViewModel
{
    public class DataManagerDriverVM : INotifyPropertyChanged
    {
        private bool Hastrnsp = false;
        public DataManagerDriverVM()
        {
            DetailTransportation = MyHttp.MyHttpClient.GetDetailTransportationInfoByLicenseNumber(Model.User.CurrentUser.Driver_license_number);
            DetailDriverInfo = MyHttpClient.GetDetailInfoAboutDriver(Model.User.CurrentUser.Driver_license_number);
            if (DetailTransportation != null)
            {
                Hastrnsp = true;
            }
        }

        private Transportation? detailTransportation;
        public Transportation DetailTransportation
        {
            get { return detailTransportation; }
            set { detailTransportation = value; NotifyPropertyChanged("DetailTransportation"); }
        }

        private Driver? detailDriverInfo;
        public Driver DetailDriverInfo
        {
            get { return detailDriverInfo; }
            set { detailDriverInfo = value; NotifyPropertyChanged("DetailDriverInfo"); }
        }

        private bool TextIsChanged = false;
        private void ChangeTextBtn()
        {
            DriverWindow._wnd.StatusBox.IsEnabled = !TextIsChanged;
            if (TextIsChanged)
            {
                DriverWindow._wnd.ChangeTextBtn.Content = "Изменить статус";
                var message = MyHttp.MyHttpClient.ChangeStatus(DetailTransportation.Number, DetailTransportation.Status);
                MessageBox.Show(message);
            }
            else
            {
                DriverWindow._wnd.ChangeTextBtn.Content = "Сохранить изменения";
            }
        }

        private RelayCommand? changeText;
        public RelayCommand ChangeText
        {
            get
            {
                return changeText ??
                    (changeText = new RelayCommand(obj =>
                    {
                        ChangeTextBtn(); TextIsChanged = !TextIsChanged;
                    },
                    obj => Hastrnsp
                    ));
            }
        }

        void Exit()
        {
            StartWindow authorizationWindow = new StartWindow();
            authorizationWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            authorizationWindow.Show();
            DriverWindow._wnd.Close();
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

        private RelayCommand refreshAll;
        public RelayCommand RefreshAll
        {
            get
            {
                return refreshAll ?? new RelayCommand(obj =>
                {
                    DetailTransportation = MyHttp.MyHttpClient.GetDetailTransportationInfoByLicenseNumber(Model.User.CurrentUser.Driver_license_number);
                    DetailDriverInfo = MyHttpClient.GetDetailInfoAboutDriver(Model.User.CurrentUser.Driver_license_number);
                    if (DetailTransportation != null) { Hastrnsp = true; }
                    else { Hastrnsp = false; }
                }
                );
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
