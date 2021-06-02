using System;
using _DomainUtils.Domain;
using Account.Domain.Enums;

namespace Account.Domain.Entities.Users
{
    public class UserWallet:BaseEntity
    {
        public Guid UserId { get; set; }
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