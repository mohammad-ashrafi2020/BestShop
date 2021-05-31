using Account.Domain.Entities.Roles;
using framework.Domain;

namespace Account.Domain.Entities.Users
{
    public class UserRole:BaseEntity
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }

        #region Relations
        public User User { get; set; }
        public Role Role { get; set; }
        #endregion
    }
}