using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TransportCo.MyHttp;
using TransportCo.View.Administrator;

namespace TransportCo.Model
{
    public class Orders
    {
        public int Number { get; set; }
        public string Status { get; set; }
        public int Total_volume { get; set; }
        public int Total_mass { get; set; }
        public int Total_cost { get; set; }


        public DateTime DateOfCreate { get; set; }
        public DateTime? DateOfComplete { get; set; }

        public int Num_Receiving_storage { get; set; }
        public string Addres { get; set; }

        public int transportationNum { get; set; } = -1;
        public string DriverLicense { get; set; } = "";
        public List<Product> Requare_Products { get; set; } = null;

        

        private RelayCommand? pendingOrder;
        public RelayCommand PendingOrder
        {
            get
            {
                return pendingOrder ??
                    (pendingOrder = new RelayCommand(obj =>
                    {
                        AdministratorWindow._mng.ViewPendingOrder(this.Number);
                    }
                    ));
            }
        }

        private RelayCommand? transportationDetails;
        public RelayCommand TransportationDetails
        {
            get
            {
                return transportationDetails ??
                    (transportationDetails = new RelayCommand(obj =>
                    {
                        AdministratorWindow._mng.ViewTranspWnd(this.transportationNum);
                    }
                    ));
            }
        }

    }
}
