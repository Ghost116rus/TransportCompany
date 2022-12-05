using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCo.MyHttp
{
    public static class MyHttpClient
    {
        static int currentIdUser;

        #region АВТОРИЗАЦИЯ

        public static bool Authorizate(string login, string password, ref string error, ref string typeOfAccount)
        {
            if (login == "admin" && password == "admin")
            {
                typeOfAccount = "Admin";
                return true;
            }
            if (login == "driver" && password == "123")
            {
                typeOfAccount = "Driver";
                return true;
            }
            if (login == "Operator" && password == "123")
            {
                typeOfAccount = "Operator";
                return true;
            }
            error = "Аккаунт не найден!\n";
            return false;
        }

        #endregion
    }
}
