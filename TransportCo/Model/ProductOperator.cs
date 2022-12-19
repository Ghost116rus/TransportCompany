using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCo.View.Operator;

namespace TransportCo.Model
{
    public class ProductOperator : INotifyPropertyChanged
    {
        public string Сatalogue_number { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Cost { get; set; }

        private int count;
        public int Count 
        { 
            get { return count; }
            set
            {
                OperatorWindow._mng.ChangeProduct(count, this);
                count = value;
                NotifyPropertyChanged("Count");
            }
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
