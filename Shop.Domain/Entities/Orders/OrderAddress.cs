using framework.Domain;

namespace Shop.Domain.Entities.Orders
{
    public class OrderAddress:BaseEntity
    {
        public long OrderId { get; set; }
        public string Shire { get; set; }
        public string City { get; set; }
        public string Village { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }
        public string PostalCode { get; set; }
        public string Plaque { get; set; }


        #region Relations
        public Order Order { get; set; }
        #endregion
    }
}