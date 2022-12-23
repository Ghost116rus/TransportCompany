using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCo.Model.User
{
    public static class CurrentUser
    {
        public static string Name { get; set; }
        public static string typeOfAccount { get; set; }
        public static int? ForignKeyToStorage { get; set; }
        public static string? Driver_license_number { get; set; }
    }
}
