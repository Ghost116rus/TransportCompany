using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.Aplication.BO;
using TransportCompany.Aplication.Interfaces;
using TransportCompany.Aplication.Requests.Orders;
using TransportCompany.Aplication.Responses;
using TransportCompany.DAL.Interfaces;
using TransportCompany.Domain.Entities;

namespace TransportCompany.Aplication.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITransportationRepository _transportationRepository;

        public OrderService(IOrderRepository orderRepository, ITransportationRepository transportationRepository)
        {
            _orderRepository = orderRepository;
            _transportationRepository = transportationRepository;
        }


        public async Task<RequestBO> GetOrderByNumber(int number)
        {
            var orderFromDB = await _orderRepository.GetOrderByNumber(number);

            if (orderFromDB == null)
            {
                return null;
            }
            var order = new RequestBO()
            {
                Number = orderFromDB.Number,
                Status = orderFromDB.Status,
                Num_Receiving_storage = orderFromDB.Num_Receiving_storage,
                Addres = orderFromDB.RecievingStorage.Location.Addres,
                Total_cost = orderFromDB.Total_cost,
                Total_mass = orderFromDB.Total_mass,
                Total_volume = orderFromDB.Total_volume,
                DateOfCreate = orderFromDB.DateOfCreate,
                DateOfComplete = orderFromDB.DateOfComplete,
                productsList = orderFromDB.Requare_Products.Select(x => new ProductExmpBO
                {
                    Сatalogue_number = x.Сatalogue_number,
                    Name = x.Product.Name,
                    Count = x.Count
                })
            };
            if (orderFromDB.transportation != null)
            {
                order.TransportationNumber = orderFromDB.transportation.Number;
                var transportation = await _transportationRepository.GetDriverByTransportationId(order.TransportationNumber);
                order.Driver_license_number = transportation.Driver.Driver_license_number;
            }
            else
            {
                order.TransportationNumber = -1;
            }
            return order;
        }

        public async Task<IEnumerable<RequestBO>> GetAllOrders()
        {
            var ordersFromDB = await _orderRepository.GetAllOrder();

            if (ordersFromDB == null)
            {
                return null;
            }

            var orders = ordersFromDB.Select(order => new RequestBO
            {
                Number = order.Number,
                Status = order.Status,
                Num_Receiving_storage = order.Num_Receiving_storage,
                Addres = order.RecievingStorage.Location.Addres,
                Total_cost = order.Total_cost,
                Total_mass = order.Total_mass,
                Total_volume = order.Total_volume,
                DateOfCreate = order.DateOfCreate,
                DateOfComplete = order.DateOfComplete
            });
            return orders;
        }

        public async Task<IEnumerable<RequestBO>> GetAllPandingOrder()
        {
            var ordersFromDB = await _orderRepository.GetPandingOrder();
            var orders = ordersFromDB.Select(order => new RequestBO
            {
                Number = order.Number,
                Status = order.Status,
                Num_Receiving_storage = order.Num_Receiving_storage,
                Addres = order.RecievingStorage.Location.Addres,
                Total_cost = order.Total_cost,
                Total_mass = order.Total_mass,
                Total_volume = order.Total_volume,
                DateOfCreate = order.DateOfCreate,
                DateOfComplete = order.DateOfComplete
            });
            return orders;
        }

        public async Task<BasicResponse> CreateOrder(NewOrder newOrder)
        {
            int newOrderId = -1;
            BasicResponse response = new BasicResponse();

            try
            {
                var order = new Request()
                {
                    Status = "Сформирована",
                    Num_Receiving_storage = newOrder.Num_Receiving_storage,
                    Total_volume = newOrder.Total_volume,
                    Total_cost = newOrder.Total_cost,
                    Total_mass = newOrder.Total_mass,
                    DateOfCreate = DateTime.Now
                };
                newOrderId = await _orderRepository.CreateOrder(order);
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Error  = "Ошибка на этапе создания заявки";
                return response;
            }

            try
            {
                var productList = newOrder.productList.Select(list => new Requare_product
                {
                    Сatalogue_number = list.Сatalogue_number,
                    Count = list.Count,
                    RequestID = newOrderId
                });
                foreach (var product in productList)
                {
                    await _orderRepository.CreateOrderList(product);
                }
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Error = "Ошибка на этапе записи списка товаров";
                return response;
            }
            response.IsSuccess = true;
            return response;
        }
    }
}
