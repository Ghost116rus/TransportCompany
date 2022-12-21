namespace TransportCompany.Aplication.BO
{
    public class StoragesListTransportationBO
    {
        public List<StoragesTransportationBO> StoragesTransportations = new List<StoragesTransportationBO>();
    }


    public class StoragesTransportationBO
    {
        public int StorageId { get; set; }

        public string Address { get; set; }

        public int TotalLength { get; set; }
    }
}
