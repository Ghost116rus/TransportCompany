using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.Aplication.Requests;
using TransportCompany.Aplication.Responses.Login;

namespace TransportCompany.Aplication.Interfaces
{
    public interface IUserService
    {
        Task<ResponseLogin> Login(RequestLogin requestlogin);
    }
}
