using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCo.DTO.Authorizate
{
    public class ResponseLoginDTO
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
        public int Type { get; set; }
        public string UserName { get; set; }
        public int? ForignKeyToStorage { get; set; }
        public string? Driver_license_number { get; set; }
    }
}
