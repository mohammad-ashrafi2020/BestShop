using Account.Domain.Enums;
using framework.Domain;

namespace Account.Domain.Entities.Roles
{
    public class RolePermission:BaseEntity
    {
        public long RoleId { get; set; }
        public Permissions Permission { get; set; }


        #region Relations
        public Role Role { get; set; }
        #endregion
    }
}