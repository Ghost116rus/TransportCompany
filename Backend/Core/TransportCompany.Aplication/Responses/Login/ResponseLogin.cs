using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.Aplication.BO;

namespace TransportCompany.Aplication.Responses.Login
{
    public class ResponseLogin
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
        public int Type { get; set; }
        public string UserName { get; set; }
        public int? ForignKeyToStorage { get; set; }
        public string? Driver_license_number { get; set; }
    }
}
