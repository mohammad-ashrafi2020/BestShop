using _DomainUtils.Domain;

namespace Account.Domain.Entities.Users
{
    public class UserCard:BaseEntity
    {
        public long UserId { get; set; }
        public string CardNumber { get; set; }
        public string AccountNumber { get; set; }
        public string OwnerName { get; set; }
        public string ShabaNumber { get; set; }
        public string BankName { get; set; }
        public bool IsActive { get; set; }

        public User User { get; set; }
    }
}