using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TransportCo.Model
{
    public class Driver
    {
        public string DriverLicense { get; set; }
        public string FullName { get; set; }
        public string Addres { get; set; }
        public string Phone_number { get; set; }
        public string Driver_license_category { get; set; }
        public string Year_of_start_work { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }

    }
}
