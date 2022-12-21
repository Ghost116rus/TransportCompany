using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TransportCo.DTO;
using TransportCo.Model;
using TransportCo.Model.Operator;

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

        #region Администратор

        #region Общие методы

        public static List<Orders> GetPendingOrders()
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync("http://localhost:5093/api/Order/PandingOrders");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<OrderDTO>>().Result;
            
            var orders = result.Select(order => new OrderDTO
            {
                Number = order.Number,
                Status = order.Status,
                Num_Receiving_storage = order.Num_Receiving_storage,
                Total_cost = order.Total_cost,
                Total_mass = order.Total_mass,
                Total_volume = order.Total_volume,
                DateOfCreate = order.DateOfCreate,
                DateOfComplete = order.DateOfComplete,
                Add
            }
            );

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
                },
                DriverLicense = "15896625"

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

        public static List<Product>? GetProductListForStorageByNumber(int number)
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

        #region Работа с водителями

        internal static List<Driver>? GetAllDrivers()
        {
            return new List<Driver>()
            {
                new Driver()
                {
                    FullName = "Калеев Д.А.",
                    Location = "Респ. Татарстан, г. Казань",
                    Status = "В рейсе"
                },
                new Driver()
                {
                    FullName = "Горохов А.С.",
                    Location = "Свердловская область, г. Екатеринбург",
                    Status = "В рейсе"
                },
                new Driver()
                {
                    FullName = "Гайфуллин Д.Р.",
                    Location = "Респ Башкортостан, г. Уфа",
                    Status = "Свобден"
                }
            };
        }
        internal static Driver GetDetailInfoAboutDriver(string driverLicense)
        {
            return new Driver()
            {
                DriverLicense = "15896625",
                FullName = "Калеев Д.А.",
                Location = "Респ. Татарстан, г. Казань",
                Status = "В рейсе",
                Addres = "Респ. Татарстан, г. Казань, 3-я кленовая 9\"Б\" кв 56",
                WorkExpirience = 15,
                Phone_number = "89520406725",
                Transportations = new List<Transportation>()
                {
                    new Transportation()
                    {
                        Number = 1,
                        RecievedAddres = "г. Нижний Новгород, ул Чехова 3-а, д. 56",
                        Status = "Прошел г. Казань",
                        Date_dispatch = DateTime.Now
                    },
                    new Transportation()
                    {
                        Number = 2,
                        RecievedAddres = "г. Нижний Новгород, ул Чехова 3-а, д. 56",
                        Status = "Исполнена",
                        Date_dispatch = DateTime.Now,
                        Delivery_date = DateTime.Now,

                    },
                }
            };
        }

        #endregion

        #region Работа с машинами
        public static List<Transport_vehicle>? GetAllVehicles()
        {
            return new List<Transport_vehicle>()
            {
                new Transport_vehicle()
                {
                    Vehicle_identification_number = "1BYS89116",
                    Name = "Форд Бронко",
                    Location = "Респб. Татарстан, г. Казань",
                    Status = "Свободен"
                },
                new Transport_vehicle()
                {
                    Vehicle_identification_number = "1BYS12116",
                    Name = "Форд Алгась",
                    Location = "Респб. Татарстан, г. Казань",
                    Status = "Свободен"
                }

            };
        }

        public static Transport_vehicle GetDetailInfoAboutVehicle(string vehicle_identification_number)
        {
            return new Transport_vehicle()
            {
                Vehicle_identification_number = "1BYS12116",
                Name = "Форд Алгась",
                Location = "Респб. Татарстан, г. Казань",
                Status = "Свободен",
                Fuel_consumption = 15
            };
        }

        public static bool RepairVehicle(string vehicle_identification_number)
        {
            throw new NotImplementedException();
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
                        FullName = "Калеев Д.А",
                        DriverLicense = "15896625"
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

        #endregion


        #region Диспетчер

        static int? storageNum;
        public static int max_volume = 30_000;


        public static List<ProductOperator> GetAllProductsByStorageNumber()
        {

            return new List<ProductOperator>()
            {
                new ProductOperator()
                {
                    Сatalogue_number = "1245689",
                    Name = "Холодильник LG12-58",
                    Type = "крупногабаритный",
                    Cost = 32_500,
                    Count = 15
                },
                new ProductOperator()
                {
                    Сatalogue_number = "6895123",
                    Name = "Утюг LG8-32",
                    Type = "малогабаритный",
                    Cost = 8500,
                    Count = 22
                }
            };
        }

        public static bool SaveChangesAboutCountInDB(string сatalogue_number, int count)
        {
            return true;
        }

        internal static List<ProductOrder> GetAllProductsForOrder()
        {
            return new List<ProductOrder>()
            {
                new ProductOrder()
                {
                    Сatalogue_number = "1245689",
                    Name = "Холодильник LG12-58",
                    Type = "крупногабаритный",
                    Volume = 800*800*1600 / 1_000_000,
                    Weight = 80,
                    Cost = 32_500
                },
                new ProductOrder()
                {
                    Сatalogue_number = "6895123",
                    Name = "Утюг LG8-32",
                    Type = "малогабаритный",
                    Volume = 400*400*200 / 1_000_000,
                    Weight = 5,
                    Cost = 8500
                }
            };
        }

        internal static List<ProductOrder> GetProductsListByName(string searchName)
        {
            return new List<ProductOrder>()
            {
                new ProductOrder()
                {
                    Сatalogue_number = "1245689",
                    Name = "Холодильник LG12-58",
                    Type = "крупногабаритный",
                    Volume = 800*800*1600/1000,
                    Weight = 80,
                    Cost = 32_500
                }
            };
        }

        public static bool CreateNewOrder(List<ProductOrder> orderProducts, int total_cost, int total_mass, int total_volume, ref string message)
        {
            return true;
        }


        #endregion
    }
}
