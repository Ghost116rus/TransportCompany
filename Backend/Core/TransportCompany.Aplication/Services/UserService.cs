using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.Aplication.BO;
using TransportCompany.Aplication.Interfaces;
using TransportCompany.Aplication.Requests;
using TransportCompany.Aplication.Responses.Login;
using TransportCompany.DAL.Interfaces;

namespace TransportCompany.Aplication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<OperatorsBO>> GetAllOperators()
        {
            var users = await _userRepository.GetOperators();
            var operators = users.Select(u => new OperatorsBO
            {
                Login = u.Login,
                Password = u.Password,
                UserName = u.UserName,
                StorageNumber = u.Storage.Storage_number,
                Addres = u.Storage.Location.Addres
            });
            return operators;
        }

        public async Task<ResponseLogin> Login(RequestLogin requestLogin)
        {
            if (requestLogin == null)
                return new ResponseLogin { IsSuccess = false, Error = "Неизвестная ошибка" };

            var user = await _userRepository.Login(requestLogin.Login, requestLogin.Password);

            if (user == null)
                return new ResponseLogin { IsSuccess = false, Error = "Неправильный логин или пароль" };

            return new ResponseLogin { IsSuccess = true, 
                Type = user.TypeOfUser, UserName = user.UserName, 
                ForignKeyToStorage = user.ForignKeyToStorage, Driver_license_number = user.ForignKeyToDriver};
        }
    }
}
