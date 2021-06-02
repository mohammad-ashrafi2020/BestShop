using System;
using _DomainUtils.Domain;

namespace Account.Domain.Entities.Users
{
    public class UserAddress:BaseEntity
    {
        public Guid UserId { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Shire { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Phone { get; set; }
        public string NationalCode { get; set; }
        public bool IsDefaultAddress { get; set; }

        public User User { get; set; }
    }
}