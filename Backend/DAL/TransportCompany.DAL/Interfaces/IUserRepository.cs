using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.Domain.Entities;

namespace TransportCompany.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Login(string login, string password);
        Task<IEnumerable<User>> GetOperators();
    }
}
