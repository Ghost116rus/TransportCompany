

using System.Windows;
using TransportCo.View.Administrator;

namespace TransportCo.Model
{
    public class Transport_vehicle
    {
        public string Vehicle_identification_number { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public int Transported_volume { get; set; }
        public int Load_capacity { get; set; }
        public float Fuel_consumption { get; set; }
        public string Required_category { get; set; }


        private RelayCommand repair;
        public RelayCommand Repair
        {
            get
            {
                return repair ?? new RelayCommand(obj =>
                {
                    if (MyHttp.MyHttpClient.RepairVehicle(Vehicle_identification_number))
                    {
                        MessageBox.Show("Данные успешно отправились");

                    }
                    else
                    {
                        MessageBox.Show("Не удалось изменить данные");
                    }
                    AdministratorWindow._mng.RefreshVehicles();

                },
                (obj) => (Status == "В ремонте"));
            }
        }
    }
}