using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCo.View.Operator;

namespace TransportCo.Model.Operator
{
    public class ProductOrder : INotifyPropertyChanged
    {
        public string Сatalogue_number { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Cost { get; set; }
        public int Weight { get; set; }

        public int Volume { get; set; }

        private int count = 0;
        public int Count
        {
            get { return count; }
            set
            {
                OperatorWindow._mng.ResolveAuto(count, value, Cost, Volume, Weight);
                count = value;
                NotifyPropertyChanged("Count");
            }
        }

        private RelayCommand? delete;
        public RelayCommand Delete
        {
            get
            {
                return delete ??
                    (delete = new RelayCommand(obj =>
                    {
                        Count = 0;
                        OperatorWindow._mng.DeleteProductFromOrder(this);

                    }));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
