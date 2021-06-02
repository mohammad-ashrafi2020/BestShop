using System;
using System.Collections.Generic;
using _DomainUtils.Domain;
using Account.Domain.Enums;

namespace Account.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string NationalCode { get; set; }
        public string ImageName { get; set; }
        public Guid ActivationToken { get; set; }
        public string Password { get; set; }
        public string ActivationCode { get; set; }
        public Gender Gender { get; set; }
        public bool IsActive { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? LastSendCodeDate { get; set; }


        #region Relations
        public ICollection<UserNotification> Notifications { get; set; }
        public ICollection<UserCard> UserCards { get; set; }
        public ICollection<UserAddress> UserAddresses { get; set; }
        public ICollection<UserWallet> Wallets { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        #endregion

    }
}