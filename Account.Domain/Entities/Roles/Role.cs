using System;
using System.Collections.Generic;
using Account.Domain.Entities.Users;

namespace Account.Domain.Entities.Roles
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleTitle { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDelete { get; set; }

        #region Relations
        public ICollection<RolePermission> Permissions { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        #endregion
    }
}