using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.DAL.Interfaces;
using TransportCompany.Domain.Entities;

namespace TransportCompany.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TransportCompanyContext _context;

        public UserRepository(TransportCompanyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetOperators()
        {
            var users = await _context.Users
                .Where(u => u.TypeOfUser == 1)
                .Include(u => u.Storage)
                    .ThenInclude(s => s.Location)
                .ToListAsync();
            return users;
        }

        public async Task<User> Login(string login, string password)
        {
            var user = await _context.Users.
                FirstOrDefaultAsync(user => user.Login == login && user.Password == password);

            return user;
        }
    }
}
