using System;
using _DomainUtils.Domain;
using Account.Domain.Entities.Roles;

namespace Account.Domain.Entities.Users
{
    public class UserRole:BaseEntity
    {
        public Guid UserId { get; set; }
        public int RoleId { get; set; }

        #region Relations
        public User User { get; set; }
        public Role Role { get; set; }
        #endregion
    }
}