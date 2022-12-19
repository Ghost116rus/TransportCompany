using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TransportCo.Model;
using TransportCo.View;

namespace TransportCo.ViewModel
{
    public class DataManagerAuthorizationVM : INotifyPropertyChanged
    {
        #region Свойства 

        private string? login;
        public string? Login
        {
            get { return login; }
            set { login = value; NotifyPropertyChanged("Login"); }
        }

        private string? password;
        public string? Password
        {
            get { return password; }
            set { password = value; NotifyPropertyChanged("Password"); }
        }

        private string? errorlog;
        public string? Errorlog
        {
            get { return errorlog; }
            set { errorlog = value; NotifyPropertyChanged("Errorlog"); }
        }

        #endregion

        #region Команды

        private RelayCommand authorization;
        public RelayCommand Authorization
        {
            get
            {
                return authorization ?? new RelayCommand(obj =>
                {
                    Errorlog = "";
                    if ((login != null && password != null) && (login != "" && password != ""))
                    {
                        string? error = null;
                        string? type = null;

                        if (MyHttp.MyHttpClient.Authorizate(login, password, ref error, ref type))
                        {
                            OpenWindow(type); return;
                        }
                        else
                        {
                            Errorlog = error;
                        }
                    }
                    else
                    {
                        Errorlog = "Введите логин и пароль";
                    }
                }
                );
            }
        }

        #endregion

        private void OpenWindow(string type)
        {
            Window window = null;

            if (type == "Admin")
            {
                window = new View.Administrator.AdministratorWindow();
            }
            else if (type == "Operator")
            {
                window = new View.Operator.OperatorWindow();
            }
            else
            {
                window = new View.Driver.DriverWindow();
            }

            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
            StartWindow._window.Close();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
