using Account.Domain.Enums;
using framework.Domain;

namespace Account.Domain.Entities.Users
{
    public class UserWallet:BaseEntity
    {
        public long UserId { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public WalletType Type { get; set; }
        public bool IsFinally { get; set; }
        public long? BankTrackingCode { get; set; }

        #region Relations

        public User User { get; set; }

        #endregion
    }
}