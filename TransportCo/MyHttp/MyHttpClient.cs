using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

            List<Orders> orders = result.Select(order => new Orders
            {
                Number = order.Number,
                Status = order.Status,
                Num_Receiving_storage = order.Num_Receiving_storage,
                Total_cost = order.Total_cost,
                Total_mass = order.Total_mass,
                Total_volume = order.Total_volume,
                DateOfCreate = order.DateOfCreate,
                DateOfComplete = order.DateOfComplete,
                Addres = order.Addres,
                DriverLicense = order.Driver_license_number
            }
            ).ToList();

            return orders;
        }

        public static List<Transportation> GetActiveTransportations()
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync("http://localhost:5093/api/Transportations/GetActiveTransportations");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<TRansportationDTO>>().Result;

            List<Transportation> transportations = result.Select(t => new Transportation
            {
                Number = t.Number,
                RecievedAddres = t.DeliveryAddres,
                Status = t.Status,
                Date_dispatch = t.Date_dispatch,
                Delivery_date = t.Delivery_date,
                driver = new Driver()
                {
                    FullName = t.FullName
                }
            }
            ).ToList();

            return transportations;
        }

        #endregion

        #region Работа с Заявками


        public static List<Orders> GetAllOrders()
        {

            HttpClient Client = new HttpClient();

            var response = Client.GetAsync("http://localhost:5093/api/Order/AllOrders");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<OrderDTO>>().Result;

            List<Orders> orders = result.Select(order => new Orders
            {
                Number = order.Number,
                Status = order.Status,
                Num_Receiving_storage = order.Num_Receiving_storage,
                Total_cost = order.Total_cost,
                Total_mass = order.Total_mass,
                Total_volume = order.Total_volume,
                DateOfCreate = order.DateOfCreate,
                DateOfComplete = order.DateOfComplete,
                Addres = order.Addres,
            }
            ).ToList();

            return orders;
        }

        public static Orders? GetDetailOrderInfo(int number)
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync($"http://localhost:5093/api/Order/DetailInfo?number={number}");

            var order = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<OrderDTO>().Result;

            Orders detailInfoOrder = new Orders()
            {
                Number = order.Number,
                Status = order.Status,
                Num_Receiving_storage = order.Num_Receiving_storage,
                Total_cost = order.Total_cost,
                Total_mass = order.Total_mass,
                Total_volume = order.Total_volume,
                DateOfCreate = order.DateOfCreate,
                DateOfComplete = order.DateOfComplete,
                Addres = order.Addres,
                transportationNum = order.TransportationNumber,
                DriverLicense = order.Driver_license_number,
                Requare_Products = order.productsList.Select(p => new Product
                {
                    Сatalogue_number = p.Сatalogue_number,
                    Name = p.Name,
                    Count = p.Count
                }).ToList()
            };
            

            return detailInfoOrder;
        }


        #endregion

        #region Работа с товарами
        public static List<Product> GetAllProducts()
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync("http://localhost:5093/api/Product/GetProducts");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<ProductsDTO>>().Result;

            var products = result.Select(p => new Product()
            {
                Сatalogue_number = p.Сatalogue_number,
                Name = p.Name,
                Type = p.Type,
                Length = p.Length,
                Width = p.Width,
                Height = p.Height,
                Weight = p.Weight,
                Cost = p.Cost
            }).ToList();

            return products;
        }

        internal static void SaveChangesAboutProductInDB(Product selectedProduct, ref string message)
        {
            message = "Данные успешно сохранены";
        }
        #endregion

        #region Работа со складами

        public static List<Product>? GetProductListForStorageByNumber(int number)
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync($"http://localhost:5093/api/Product/GetProductsByStorage?number={number}");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<ProductForListDTO>>().Result;

            var products = result.Select(p => new Product()
            {
                Сatalogue_number = p.Сatalogue_number,
                Name = p.Name,
                Count = p.Count
            }).ToList();

            return products;
        }

        public static List<Storage> GetAllStorage()
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync("http://localhost:5093/api/Storages");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<StorageDTO>>().Result;

            var storages = result.Select(p => new Storage()
            {
                Number = p.Storage_number,
                Addres = p.Addres,
                PhoneNumber = p.Phone_number
            }).ToList();

            return storages;
        }


        #endregion

        #region Работа с водителями

        public static List<Driver>? GetAllDrivers()
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync("http://localhost:5093/api/Drivers/GetAllDrivers");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<DriverDTO>>().Result;

            var drivers = result.Select(d => new Driver()
            {
                DriverLicense = d.Driver_license_number,
                FullName = d.FIO,
                Location = d.Location,
                Status = d.Status
            }).ToList();
            return drivers;
        }
        internal static Driver GetDetailInfoAboutDriver(string driverLicense)
        {
            if (driverLicense == "")
            {
                MessageBox.Show("Ошибка!");
                return null;
            }
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync($"http://localhost:5093/api/Drivers?Driver_license_number={driverLicense}");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<DriverDTO>().Result;

            var driver = new Driver()
            {
                DriverLicense = result.Driver_license_number,
                FullName = result.FIO,
                Addres = result.Addres,
                Phone_number = result.Phone_number,
                Driver_license_category = result.Driver_license_category,
                WorkExpirience = result.Expirience,
                Location = result.Location,
                Status = result.Status,
                Transportations = result.Transportations.Select(t => new Transportation()
                {
                    Number = t.Number,
                    Status = t.Status,
                    Date_dispatch = t.Date_dispatch,
                    RecievedAddres = t.DeliveryAddres
                }).ToList()
            };


            return driver;

            //return new Driver()
            //{
            //    DriverLicense = "15896625",
            //    FullName = "Калеев Д.А.",
            //    Location = "Респ. Татарстан, г. Казань",
            //    Status = "В рейсе",
            //    Addres = "Респ. Татарстан, г. Казань, 3-я кленовая 9\"Б\" кв 56",
            //    WorkExpirience = 15,
            //    Phone_number = "89520406725",
            //    Transportations = new List<Transportation>()
            //    {
            //        new Transportation()
            //        {
            //            Number = 1,
            //            RecievedAddres = "г. Нижний Новгород, ул Чехова 3-а, д. 56",
            //            Status = "Прошел г. Казань",
            //            Date_dispatch = DateTime.Now
            //        },
            //        new Transportation()
            //        {
            //            Number = 2,
            //            RecievedAddres = "г. Нижний Новгород, ул Чехова 3-а, д. 56",
            //            Status = "Исполнена",
            //            Date_dispatch = DateTime.Now,
            //            Delivery_date = DateTime.Now,

            //        },
            //    }
            //};
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

            HttpClient Client = new HttpClient();

            var response = Client.GetAsync("http://localhost:5093/api/Transportations/GetAllTransportations");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<TRansportationDTO>>().Result;

            List<Transportation> transportations = result.Select(t => new Transportation
            {
                Number = t.Number,
                RecievedAddres = t.DeliveryAddres,
                Status = t.Status,
                Date_dispatch = t.Date_dispatch,
                Delivery_date = t.Delivery_date,
                driver = new Driver()
                {
                    FullName = t.FullName
                }
            }
            ).ToList();

            return transportations;
        }

        public static Transportation GetDetailTransportationInfo(int number)
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync($"http://localhost:5093/api/Transportations/GetDetailInfoAboutTransportation?number={number}");

            var transportation = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<DetailTransportationDTO>().Result;

            Transportation detailInfoTransportation = new Transportation()
            {
                Number = transportation.Number,
                Num_Sending_storage = transportation.Num_Sending_storage,
                Status = transportation.Status,
                Sending_storage_Addres = transportation.Sending_storage_Addres,
                Date_dispatch=transportation.Date_dispatch,
                RecievedAddres=transportation.DeliveryAddres,
                Delivery_date = transportation.Delivery_date,
                Total_length = transportation.Total_length,
                Total_shipping_cost = transportation.Total_shipping_cost,
                Car_load = transportation.Car_load,
                vehicle = new Transport_vehicle()
                {
                    Vehicle_identification_number = transportation.Vehicle_identification_number,
                    Name = transportation.Name,
                },
                OrderNumber = transportation.RequestNumber,
                driver = new Driver()
                {
                    FullName = transportation.FullName,
                    DriverLicense = transportation.Driver_license_number
                }
            };

            return detailInfoTransportation;
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
