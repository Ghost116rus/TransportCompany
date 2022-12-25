using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using TransportCo.DTO;
using TransportCo.DTO.Authorizate;
using TransportCo.DTO.CreateTransportation;
using TransportCo.DTO.Operator;
using TransportCo.Model;
using TransportCo.Model.Operator;

namespace TransportCo.MyHttp
{
    public static class MyHttpClient
    {


        #region АВТОРИЗАЦИЯ

        public static bool Authorizate(string login, string password, ref string error)
        {
            HttpClient Client = new HttpClient();

            var request = new RequestLoginDTO()
            {
                Login = login,
                Password = password,
            };

            try
            {
                var response = Client.PostAsJsonAsync("http://localhost:5093/api/User/Authorizate", request)
                    .Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<ResponseLoginDTO>().Result;

                switch(response.Type)
                {
                    case 0:
                        Model.User.CurrentUser.typeOfAccount = "Admin";
                        break;
                    case 1:
                        Model.User.CurrentUser.typeOfAccount = "Operator";
                        break;
                    case 2:

                        Model.User.CurrentUser.typeOfAccount = "Driver";
                        break;
                    default:
                        Model.User.CurrentUser.typeOfAccount = "Unknown";
                        error = "Неизвестный тип аккаунта - повторите попытку";
                        return false;
                        break;
                }
                Model.User.CurrentUser.Name = response.UserName;

                if (response.ForignKeyToStorage != null)
                {
                    storageNum = response.ForignKeyToStorage;
                    Model.User.CurrentUser.ForignKeyToStorage = response.ForignKeyToStorage;
                }
                if (response.Driver_license_number != null)
                {
                    Model.User.CurrentUser.Driver_license_number = response.Driver_license_number;
                }
                
                

                return response.IsSuccess;
            }
            catch (Exception)
            {
                error = "Ошибка при запросе - неполадка с сетью(";
                return false;
            }
        }

        #endregion

        #region Администратор

        #region Общие методы

        public static List<Orders> GetNotPandingOrders()
            {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync("http://localhost:5093/api/Order/NoPandingOrders");

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

        public static void CancelOrder(int number, ref string message)
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync($"http://localhost:5093/api/Order/CancelOrder?number={number}")
                .Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<BasicResponse>().Result;

            if (response.IsSuccess) { message = "Операция выполнена успешно"; }
            else
            {
                message = response.Error;
            }
            return;
        }

        #endregion

        #region Работа с Заявками

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
                PhoneNumber = "+7" + p.Phone_number
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

            var response = Client.GetAsync($"http://localhost:5093/api/Drivers/GetDetailInfo?Driver_license_number={driverLicense}");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<DriverDTO>().Result;

            var driver = new Driver()
            {
                DriverLicense = result.Driver_license_number,
                FullName = result.FIO,
                Addres = result.Addres,
                Phone_number = "+7" + result.Phone_number,
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
        }

        #endregion

        #region Работа с машинами
        public static List<Transport_vehicle>? GetAllVehicles()
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync("http://localhost:5093/api/Vehicle/GetAllVehicles");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<VehicleDTO>>().Result;

            var vehicles = result.Select(ts => new Transport_vehicle
            {
                Vehicle_identification_number = ts.Vehicle_identification_number,
                Name = ts.Name,
                Location = ts.Location,
                Status = ts.Status
            }).ToList();

            return vehicles;
        }

        public static Transport_vehicle GetDetailInfoAboutVehicle(string vehicle_identification_number)
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync($"http://localhost:5093/api/Vehicle/GetVehicleByNumber?number={vehicle_identification_number}");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<VehicleDTO>().Result;

            var vehicle = new Transport_vehicle()
            {
                Vehicle_identification_number = result.Vehicle_identification_number,
                Name = result.Name,
                Location = result.Location,
                Load_capacity = result.Load_capacity,
                Status = result.Status,
                Fuel_consumption = result.Fuel_consumption,
                Required_category = result.Required_category,
                Transported_volume = result.Transported_volume
            };

            return vehicle;
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

        #region Создание Перевозки

        public static List<SendingStoragesListDTO> GetStoragesByOrder(int requestId)
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync($"http://localhost:5093/api/Storages/{requestId}");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<SendingStoragesListDTO>>().Result;

            return result;
        }

        public static List<Vehicle> GetVehiclesForOrder(string Location, int TotalMass, int TotalVolume)
        {
            HttpClient Client = new HttpClient();


            var request = new GetVehicleForOrderRequest()
            {
                Location = Location,
                TotalMass = TotalMass,
                TotalVolume = TotalVolume
            };

            var result = Client.PostAsJsonAsync("http://localhost:5093/api/Vehicle/GetVehicleForOrder", request)
                .Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<VehicleDTO>>().Result;

            var vehicles = result.Select(ts => new Vehicle
            {
                Vehicle_identification_number = ts.Vehicle_identification_number,
                Name = ts.Name,
                Location = ts.Location,
                Status = ts.Status,
                Transported_volume = ts.Transported_volume,
                Load_capacity = ts.Load_capacity,
                Fuel_consumption = ts.Fuel_consumption,
                Required_category = ts.Required_category
            }).ToList();

            return vehicles;
        }

        public static List<DriverForTrDTO> GetDriverForOrder(string Location, string Required_category)
        {
            HttpClient Client = new HttpClient();

            var request = new GetDriverForOrderRequest()
            {
                location = Location,
                requareCategory = Required_category
            };

            var result = Client.PostAsJsonAsync("http://localhost:5093/api/Drivers/GetDriversForOrder", request)
                .Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<DriverForTrDTO>>().Result;

            var vehicles = result.Select(d => new DriverForTrDTO
            {
                Driver_license_number = d.Driver_license_number,
                Fullname = d.Fullname,
                CountOfTransportation = d.CountOfTransportation,
                Expirience = d.Expirience
            }).ToList();

            return vehicles;
        }

        public static void CreateTransportation(CreateTrnspRequest createNewTransportationRequest, ref string message)
        {
            HttpClient Client = new HttpClient(); // 

            var response = Client.PostAsJsonAsync("http://localhost:5093/api/Transportations/CreateTransportation", createNewTransportationRequest)
                .Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<BasicResponse>().Result;
            if (response.Error != null)
            {
                message = response.Error;
            }
            return;
        }

        #endregion

        #region Диспетчеры в окне Администратора
        public static List<OperatorsList> GetAllOperators()
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync("http://localhost:5093/api/User/GetAllOperators");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<OperatorsList>>().Result;

            return result;
        }
        #endregion

        #endregion


        #region Диспетчер

        public static int? storageNum = 3;
        public static int max_volume = 30_000;
        public static int maxWeight = 30_000;
        public static int min_value = 200;

        public static List<ProductOperator> GetAllProductsByStorageNumber()
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync($"http://localhost:5093/api/Product/GetProductsByStorageOperator?number={storageNum}");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<ProductsByStorageDTO>>().Result;

            var products = result.Select(p => new ProductOperator()
            {
                Сatalogue_number = p.Сatalogue_number,
                Name = p.Name,
                Type = p.Type,
                Cost = p.Cost,
                Count = p.Count
            }).ToList();

            return products;

        }

        public static bool SaveChangesAboutCountInDB(string сatalogue_number, int count)
        {
            return true;
        }

        internal static List<ProductOrder> GetAllProductsForOrder()
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync("http://localhost:5093/api/Product/GetAllProductsForOrder");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<ProductsForOrder>>().Result;

            var products = result.Select(p => new ProductOrder()
            {
                Сatalogue_number = p.Сatalogue_number,
                Name = p.Name,
                Type = p.Type,
                Cost = p.Cost,
                Volume = p.Volume,
                Weight = p.Weight
            }).ToList();

            return products;
        }

        internal static List<ProductOrder> GetProductsListByName(string searchName)
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync($"http://localhost:5093/api/Product/GetAllProductsForOrderByName?name={searchName}");

            var result = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<ProductsForOrder>>().Result;

            var products = result.Select(p => new ProductOrder()
            {
                Сatalogue_number = p.Сatalogue_number,
                Name = p.Name,
                Type = p.Type,
                Cost = p.Cost,
                Volume = p.Volume,
                Weight = p.Weight
            }).ToList();

            return products;
        }

        public static bool CreateNewOrder(List<ProductOrder> orderProducts, int total_cost, int total_mass, int total_volume, ref string message)
        {
            HttpClient Client = new HttpClient();


            var request = new CreateOrderRequest()
            {
                num_Receiving_storage = (int)storageNum,
                total_volume = total_volume,
                total_mass = total_mass,
                total_cost = total_cost,
            };
            var list = new List<ProductListForRequest>();
            foreach (var p in orderProducts)
            {
                var element = new ProductListForRequest()
                {
                    сatalogue_number = p.Сatalogue_number,
                    count = p.Count
                };
                list.Add(element);
            }
            request.productList = list;

            var response = Client.PostAsJsonAsync("http://localhost:5093/api/Order/CreateOrder", request)
                .Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<BasicResponse>().Result;

            message = response.Error;
            return response.IsSuccess;
        }

        public static List<Orders> GetAllOrdersByStoragNumber()
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync($"http://localhost:5093/api/Order/GetAllOrdersByStorageNumber?number={storageNum}");

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

        internal static List<Transportation> GetGetTransportations()
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync($"http://localhost:5093/api/Transportations/GetGetTransportation?storageNumber={storageNum}");

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

        internal static List<Transportation> GetSendTransportations()
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync($"http://localhost:5093/api/Transportations/GetSendTransportation?storageNumber={storageNum}");

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

        internal static OperatorDetailTransportaion GetDetailTransportationInfoForOperator(int number)
        {
            HttpClient Client = new HttpClient();

            var response = Client.GetAsync($"http://localhost:5093/api/Transportations/GetDetailTransportationInfoForOperator?number={number}");

            var transportation = response.Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<OperatorDetailTransportaion>().Result;

            //Orders detailInfoOrder = new Orders()
            //{
            //    Number = order.Number,
            //    Status = order.Status,
            //    Num_Receiving_storage = order.Num_Receiving_storage,
            //    Total_cost = order.Total_cost,
            //    Total_mass = order.Total_mass,
            //    Total_volume = order.Total_volume,
            //    DateOfCreate = order.DateOfCreate,
            //    DateOfComplete = order.DateOfComplete,
            //    Addres = order.Addres,
            //    transportationNum = order.TransportationNumber,
            //    DriverLicense = order.Driver_license_number,
            //    Requare_Products = order.productsList.Select(p => new Product
            //    {
            //        Сatalogue_number = p.Сatalogue_number,
            //        Name = p.Name,
            //        Count = p.Count
            //    }).ToList()
            //};


            return transportation;
        }




        #endregion
    }
}
