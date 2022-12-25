using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.Aplication.BO;
using TransportCompany.Aplication.Interfaces;
using TransportCompany.Aplication.Requests.CreateTransportation;
using TransportCompany.Aplication.Responses;
using TransportCompany.DAL.Interfaces;
using TransportCompany.DAL.Repository;
using TransportCompany.Domain.Entities;

namespace TransportCompany.Aplication.Services
{
    public class TransportationService : ITransportationService
    {
        private readonly ITransportationRepository transportationRepository;

        public TransportationService(ITransportationRepository transportationRepository)
        {
            this.transportationRepository = transportationRepository;
        }

        public async Task<BasicResponse> CreateTransportation(RequestToCreateTransportation request)
        {
            BasicResponse basicResponse = new BasicResponse();
            basicResponse.IsSuccess = false;
            try
            {
                Transportation transportation = new Transportation()
                {
                    RequestNumber = request.RequestNumber,
                    Num_Sending_storage = request.NumSendingStorage,
                    Total_length = request.Total_length,
                    Car_load = request.Car_load,
                    Total_shipping_cost = request.Total_shipping_cost,
                    DriverID = request.DriverID,
                    VehicleID = request.VehicleID,

                    Status = "Ожидает подтверждение Оператора склада-отправителя",
                    Date_dispatch = DateTime.Now.AddDays(2),
                    Delivery_date = CreateDateOfDispatch(request.Total_length)
                };

                await transportationRepository.CreateTransportation(transportation);

                basicResponse.IsSuccess = true;
            }
            catch (Exception)
            {

                basicResponse.Error = "Ошибка при попытке сохранить новую перевозку";
            }
            return basicResponse;

        }

        public async Task<IEnumerable<TransportationsBO>> GetActiveTransportations()
        {
            var transpFromDb = await transportationRepository.GetActiveTransportation();

            if (transpFromDb == null)
            {
                return null;
            }

            var transportations = transpFromDb.Select(t => new TransportationsBO
            {
                Number = t.Number,
                Status = t.Status,
                Date_dispatch = t.Date_dispatch,
                Delivery_date = t.Delivery_date,
                DeliveryAddres = t.Request.RecievingStorage.Location.Addres,
                FullName = t.Driver.FirstName + " " + t.Driver.SecondName[0] + ". " + t.Driver.Patronymic[0] + ".",
                RequestNumber = t.RequestNumber
            });

            return transportations;
        }

        public async Task<IEnumerable<TransportationsBO>> GetAllTransportations()
        {
            var transpFromDb = await transportationRepository.GetAllTransportation();

            if (transpFromDb == null)
            {
                return null;
            }

            var transportations = transpFromDb.Select(t => new TransportationsBO
            {
                Number = t.Number,
                Status = t.Status,
                Date_dispatch = t.Date_dispatch,
                Delivery_date = t.Delivery_date,
                DeliveryAddres = t.Request.RecievingStorage.Location.Addres,
                FullName = t.Driver.FirstName + " " + t.Driver.SecondName[0] + ". " + t.Driver.Patronymic[0] + ".",
                RequestNumber = t.RequestNumber
            });

            return transportations;
        }

        public async Task<DetailTransportationBO> GetDetailInfoAboutTransportation(int number)
        {
            var transFromDB = await transportationRepository.GetDetailInfoAboutTransportation(number);
            if (transFromDB != null)
            {
                var transportation = new DetailTransportationBO()
                {
                    Number = transFromDB.Number,
                    Num_Sending_storage = transFromDB.Num_Sending_storage,
                    Status = transFromDB.Status,
                    Sending_storage_Addres = transFromDB.SendingStorage.Location.Addres,
                    Date_dispatch = transFromDB.Date_dispatch,
                    DeliveryAddres = transFromDB.Request.RecievingStorage.Location.Addres,
                    Total_length = transFromDB.Total_length,
                    Total_shipping_cost = transFromDB.Total_shipping_cost,
                    Vehicle_identification_number = transFromDB.vehicle.Vehicle_identification_number,
                    Name = transFromDB.vehicle.Name,
                    Car_load = transFromDB.Car_load,
                    FullName = transFromDB.Driver.FirstName + " " + transFromDB.Driver.SecondName[0] + ". " + transFromDB.Driver.Patronymic[0] + ".",
                    Driver_license_number = transFromDB.Driver.Driver_license_number,
                    Delivery_date = transFromDB.Delivery_date,
                    RequestNumber = transFromDB.RequestNumber
                };
                return transportation;
            }
            return null;

        }

        private IEnumerable<ProductExmpBO> GetProductList(IEnumerable<Requare_product> list)
        {
            IEnumerable<ProductExmpBO> result = null;
            if (list != null)
            {
                result = list.Select(x => new ProductExmpBO
                {
                    Сatalogue_number = x.Сatalogue_number,
                    Name = x.Product.Name,
                    Count = x.Count
                });
            }
            return result;
        }

        public async Task<DetailTransportationForOperatorBO> GetDetailTransportationInfoForOperator(int number)
        {
            var transFromDB = await transportationRepository.GetDetailTransportationInfoForOperator(number);
            if (transFromDB != null)
            {
                var transportation = new DetailTransportationForOperatorBO()
                {
                    Number = transFromDB.Number,
                    Num_Sending_storage = transFromDB.Num_Sending_storage,
                    Status = transFromDB.Status,
                    Date_dispatch = transFromDB.Date_dispatch,

                    Vehicle_identification_number = transFromDB.vehicle.Vehicle_identification_number,
                    Name = transFromDB.vehicle.Name,

                    FullName = transFromDB.Driver.FirstName + " " + transFromDB.Driver.SecondName[0] + ". " + transFromDB.Driver.Patronymic[0] + ".",
                    PhoneNumber = transFromDB.Driver.Phone_number,


                    productsList = GetProductList(transFromDB.Request.Requare_Products)


                };
                return transportation;
            }
            return null;
        }



        public async Task<IEnumerable<TransportationsBO>> GetGetTransportation(int storageNumber)
        {
            var transpFromDb = await transportationRepository.GetGetTransportation(storageNumber);

            if (transpFromDb == null)
            {
                return null;
            }

            var transportations = transpFromDb.Select(t => new TransportationsBO
            {
                Number = t.Number,
                Status = t.Status,
                Date_dispatch = t.Date_dispatch,
                Delivery_date = t.Delivery_date,
                DeliveryAddres = t.Request.RecievingStorage.Location.Addres,
                FullName = t.Driver.FirstName + " " + t.Driver.SecondName[0] + ". " + t.Driver.Patronymic[0] + ".",
                RequestNumber = t.RequestNumber
            });

            return transportations;
        }

        public async Task<IEnumerable<TransportationsBO>> GetSendTransportation(int storageNumber)
        {
            var transpFromDb = await transportationRepository.GetSendTransportation(storageNumber);

            if (transpFromDb == null)
            {
                return null;
            }

            var transportations = transpFromDb.Select(t => new TransportationsBO
            {
                Number = t.Number,
                Status = t.Status,
                Date_dispatch = t.Date_dispatch,
                Delivery_date = t.Delivery_date,
                DeliveryAddres = t.Request.RecievingStorage.Location.Addres,
                FullName = t.Driver.FirstName + " " + t.Driver.SecondName[0] + ". " + t.Driver.Patronymic[0] + ".",
                RequestNumber = t.RequestNumber
            });

            return transportations;
        }

        private DateTime CreateDateOfDispatch(int length)
        {
            int days = length / 300;
            return DateTime.Now.AddDays(days + 2);
        }

        public async Task<BasicResponse> SendProducts(int number)
        {
            BasicResponse basicResponse = new BasicResponse();
            basicResponse.IsSuccess = false;
            try
            {
                await transportationRepository.SendProducts(number);
                basicResponse.IsSuccess = true;
            }
            catch (Exception)
            {

                basicResponse.Error = "Не удалось сохранить информацию о выдаче товаров";
            }
            return basicResponse;
        }

        public async Task<BasicResponse> CompleteTransportation(int number)
        {
            BasicResponse basicResponse = new BasicResponse();
            basicResponse.IsSuccess = false;

            try
            {
                await transportationRepository.CompleteTransportation(number);
                basicResponse.IsSuccess = true;
            }
            catch (Exception)
            {

                basicResponse.Error = "Не удалось завершить перевозку";
            }
            return basicResponse;
        }

        public async Task<BasicResponse> CancelTransportation(int number)
        {
            BasicResponse basicResponse = new BasicResponse();
            basicResponse.IsSuccess = false;
            try
            {
                await transportationRepository.CancelTransportation(number);
                basicResponse.IsSuccess = true;
            }
            catch (Exception)
            {

                basicResponse.Error = "Не удалось отменить перевозку";
            }
            return basicResponse;
        }
    }
}
