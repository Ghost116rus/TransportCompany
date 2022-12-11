using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCo.Model;

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


        #region Общие методы

        public static List<Orders> GetPendingOrders()
        {

            return new List<Orders>()
            {
                new Orders()
                {
                    Number = 1,
                    Status = "Wait",
                    Num_Receiving_storage = 1,
                    Total_volume = 50,
                    Total_mass = 100,
                    Total_cost = 100,
                    DateOfCreate = DateTime.Now,
                    Addres = "г. Казань, ул Вахитова 41"
                },
                new Orders()
                {
                    Number = 8,
                    Status = "Wait",
                    Num_Receiving_storage = 1,
                    Total_volume = 50,
                    Total_mass = 100,
                    Total_cost = 100,
                    DateOfCreate = DateTime.Now,
                    Addres = "г. Екатеринбург, ул Арбузова 15"
                },
            };
        }

        public static List<EventLog> GetEventsLog()
        {
            return new List<EventLog>()
            {
                new EventLog()
                {
                    Info = DateTime.Now.ToString() + " Водитель Калеев Д.А изменил свой статус с 'Прошел г. Казань' на 'прибыл в Нижний Новогород'"

                },
                                new EventLog()
                {
                    Info = DateTime.Now.ToString() + " Водитель Калеев Д.А изменил свой статус с 'Прошел г. Казань' на 'прибыл в Нижний Новогород'"

                },                                new EventLog()
                {
                    Info = DateTime.Now.ToString() + " Водитель Калеев Д.А изменил свой статус с 'Прошел г. Казань' на 'прибыл в Нижний Новогород'"

                },                                new EventLog()
                {
                    Info = DateTime.Now.ToString() + " Водитель Калеев Д.А изменил свой статус с 'Прошел г. Казань' на 'прибыл в Нижний Новогород'"

                },                                new EventLog()
                {
                    Info = DateTime.Now.ToString() + " Водитель Калеев Д.А изменил свой статус с 'Прошел г. Казань' на 'прибыл в Нижний Новогород'"

                }
            };
        }

        public static List<Transportation> GetActiveTransportations()
        {
            return new List<Transportation>()
            {
                new Transportation()
                {
                    Number = 1,
                    Addres = "г. Нижний Новгород, ул Чехова 3-а, д. 56",
                    Status = "Прошел г. Казань",
                    FullName = "Калеев Д.А"
                },
                new Transportation()
                {
                    Number = 8,
                    Addres = "г. Екатеринбург, ул. Губкина, д. 56",
                    Status = "На подъезде к г. Екатеринбург",
                    FullName = "Горохов А.С"
                },
            };
        }
        #endregion

        #region Работа с Заявками


        internal static List<Orders> GetAllOrders()
        {

            return new List<Orders>()
            {
                new Orders()
                {
                    Number = 1,
                    Status = "Wait",
                    Num_Receiving_storage = 1,
                    Total_volume = 50,
                    Total_mass = 100,
                    Total_cost = 100,
                    DateOfCreate = DateTime.Now,
                    Addres = "г. Казань, ул Вахитова 41"
                },
                new Orders()
                {
                    Number = 8,
                    Status = "Wait",
                    Num_Receiving_storage = 1,
                    Total_volume = 50,
                    Total_mass = 100,
                    Total_cost = 100,
                    DateOfCreate = DateTime.Now,
                    Addres = "г. Москва, ул Павлова 21"
                },
            };
        }

        public static Orders? GetDetailOrderInfo(int number)
        {
            return new Orders()
            {
                Number = 1,
                Status = "Wait",
                Num_Receiving_storage = 1,
                Total_volume = 50,
                Total_mass = 100,
                Total_cost = 100,
                DateOfCreate = DateTime.Now,
                Addres = "г. Казань, ул Вахитова 41"
            };
        }

        public static List<Product> GetAllProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Сatalogue_number = "1245689",
                    Name = "Холодильник LG12-58",
                    Type = "крупногабаритный",
                    Length = 800,
                    Width = 800,
                    Height = 1600,
                    Weight = 80,
                    Cost = 32_500
                },
                new Product()
                {
                    Сatalogue_number = "6895123",
                    Name = "Утюг LG8-32",
                    Type = "малогабаритный",
                    Length = 400,
                    Width = 200,
                    Height = 400,
                    Weight = 5,
                    Cost = 8500
                }
            };
        }


        #endregion
    }
}
