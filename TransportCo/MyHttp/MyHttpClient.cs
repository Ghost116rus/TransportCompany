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

                },
                new EventLog()
                {
                    Info = DateTime.Now.ToString() + " Водитель Калеев Д.А изменил свой статус с 'Прошел г. Казань' на 'прибыл в Нижний Новогород'"

                }, 
                new EventLog()
                {
                    Info = DateTime.Now.ToString() + " Водитель Калеев Д.А изменил свой статус с 'Прошел г. Казань' на 'прибыл в Нижний Новогород'"

                },
                new EventLog()
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
                    RecievedAddres = "г. Нижний Новгород, ул Чехова 3-а, д. 56",
                    Status = "Прошел г. Казань",
                    driver = new Driver()
                    {
                        FullName = "Калеев Д.А"
                    }
                    
                },
                new Transportation()
                {
                    Number = 8,
                    RecievedAddres = "г. Екатеринбург, ул. Губкина, д. 56",
                    Status = "На подъезде к г. Екатеринбург",
                    driver = new Driver()
                    {
                        FullName = "Горохов А.С"
                    }                    
                },
            };
        }
        #endregion

        #region Работа с Заявками

        public static List<Orders> GetAllOrders()
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
                Addres = "г. Казань, ул Вахитова 41",
                transportationNum = 1,
                Requare_Products = new List<Product>()
                {
                    new Product()
                    {
                        Сatalogue_number = "1245689",
                        Name = "Холодильник LG12-58",
                        Type = "крупногабаритный",
                        Count = 5,
                    },
                    new Product()
                    {
                         Сatalogue_number = "6895123",
                        Name = "Утюг LG8-32",
                        Type = "малогабаритный",
                        Count = 15,
                    },
                }
        };
        }


        #endregion

        #region Работа с товарами
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

        internal static void SaveChangesAboutProductInDB(Product selectedProduct, ref string message)
        {
            message = "Данные успешно сохранены";
        }
        #endregion

        #region Работа со складами

        internal static List<Product>? GetProductListForStorageByNumber(int number)
        {
            return new List<Product>()
            {
                new Product()
                {
                    Сatalogue_number = "1245689",
                    Name = "Холодильник LG12-58",
                    Count = 15
                },
                new Product()
                {
                    Сatalogue_number = "6895123",
                    Name = "Утюг LG8-32",
                    Type = "малогабаритный",
                    Count = 59
                },
                new Product()
                {
                    Сatalogue_number = "1234557",
                    Name = "Монитор LGB158-C32",
                    Type = "малогабаритный",
                    Count = 22
                }
            };
        }

        public static List<Storage> GetAllStorage()
        {
            return new List<Storage>()
            {
                new Storage()
                {
                    Number = 5,
                    Addres = "Респ. Татарстан, г. Казань, ул. Академика Кирпичникова 65",
                    PhoneNumber = "89520406725"
                },
                new Storage()
                {
                    Number = 8,
                    Addres = "Респ. Карелия, г. Булдык, ул. Академика Азимова 88",
                    PhoneNumber = "89520406725"
                },
                new Storage()
                {
                    Number = 5,
                    Addres = "Московская область, г. Москва, ул. Дружбы народов 7",
                    PhoneNumber = "89520406725"
                }
            };
        }


        #endregion

        #region Работа с Перевозками

        public static List<Transportation> GetAllTransportations()
        {
            return new List<Transportation>()
            {
                new Transportation()
                {
                    Number = 1,
                    RecievedAddres = "г. Нижний Новгород, ул Чехова 3-а, д. 56",
                    Status = "Прошел г. Казань",
                    driver = new Driver()
                    {
                        FullName = "Калеев Д.А"
                    }
                },
                new Transportation()
                {
                    Number = 8,
                    RecievedAddres = "г. Екатеринбург, ул. Губкина, д. 56",
                    Status = "На подъезде к г. Екатеринбург",
                    driver = new Driver()
                    {
                        FullName = "Горохов А.С"
                    }
                    
                },
                new Transportation()
                {
                    Number = 16,
                    RecievedAddres = "г. Екатеринбург, ул. Губкина, д. 56",
                    Status = "На подъезде к г. Екатеринбург",
                    driver = new Driver()
                    {
                        FullName = "Гайфуллин Д.Р"
                    }
                    
                },
            };
        }

        public static Transportation GetDetailTransportationInfo(int number)
        {
            return new Transportation()
            {
                Number = 1,
                RecievedAddres = "г. Нижний Новгород, ул Чехова 3-а, д. 56",
                Status = "Прошел г. Казань",
                driver = new Driver()
                {
                    FullName = "Калеев Д.А"
                }
            };
        }

        #endregion
    }
}
