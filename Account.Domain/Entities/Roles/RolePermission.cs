using _DomainUtils.Domain;
using Account.Domain.Enums;

namespace Account.Domain.Entities.Roles
{
    public class RolePermission:BaseEntity
    {
        public int RoleId { get; set; }
        public Permissions Permission { get; set; }


        #region Relations
        public Role Role { get; set; }
        #endregion
    }
}