using System.Collections.Generic;
using Account.Domain.Entities.Users;
using framework.Domain;

namespace Account.Domain.Entities.Roles
{
    public class Role:BaseSoftDelete
    {
        public string RoleTitle { get; set; }

        #region Relations
        public ICollection<RolePermission> Permissions { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        #endregion
    }
}