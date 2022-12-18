using System;
using TransportCo.View.Administrator;

namespace TransportCo.Model
{
    public class Transportation
    {
        public int Number { get; set; }
        public int Num_Sending_storage { get; set; }
        public string Sending_storage_Addres { get; set; }
        public DateTime Date_dispatch { get; set; }
        public DateTime Delivery_date { get; set; }
        public int Total_time { get; set; }
        public int Total_length { get; set; }
        public int Car_load { get; set; }
        public int Total_shipping_cost { get; set; }
        public string Status { get; set; }
        public Transport_vehicle vehicle { get; set; }
        public Driver driver { get; set; }

        public int OrderNumber { get; set; }
        public string RecievedAddres { get; set; }
        public string SendAddres { get; set; }


        private RelayCommand? transportatioDetails;
        public RelayCommand TransportatioDetails
        {
            get
            {
                return transportatioDetails ??
                    (transportatioDetails = new RelayCommand(obj =>
                    {
                        AdministratorWindow._mng.ViewTransportatioDetails(this.Number);
                    }
                    ));
            }
        }

    }
}