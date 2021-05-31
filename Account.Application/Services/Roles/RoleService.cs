using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.Application.Services.Users.UserRoles;
using Account.Domain.Entities.Roles;
using Account.Infrastructure.Context;
using framework;
using framework.Services;
using Microsoft.EntityFrameworkCore;

namespace Account.Application.Services.Roles
{
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(AccountContext context) : base(context)
        {
        }

        public async Task<ResultModel> InsertRole(string roleTitle)
        {
            var role = new Role()
            {
                RoleTitle = roleTitle,
                IsDelete = false
            };
            Insert(role);
            await Save();
            return ResultModel.Success();
        }

        public async Task<ResultModel> DeleteRole(long roleId, long deletedBy)
        {
            var role = await GetRoleBy(roleId);
            if (role.Status != ResultModelStatus.Success)
                return ResultModel.Error();

            role.Data.IsDelete = true;
            role.Data.DeletedAt = DateTime.Now;
            role.Data.DeletedBy = deletedBy;
            Update(role.Data);
            await Save();
            return ResultModel.Success();
        }

        public async Task<ResultModel> EditRole(long roleId, string newRoleTitle)
        {
            var role = await GetRoleBy(roleId);
            if (role.Status != ResultModelStatus.Success)
                return ResultModel.Error();

            role.Data.RoleTitle = newRoleTitle;
            Update(role.Data);
            await Save();
            return ResultModel.Success();
        }

        public async Task<ResultModel<Role>> GetRoleBy(long id)
        {
            var role = await GetById<Role>(id, "Permissions");
            if (role == null)
                return ResultModel<Role>.NotFound();
            return ResultModel<Role>.Success(role);
        }

        public async Task<ResultModel<Role>> GetRoleBy(string title)
        {
            var role = await Table<Role>().FirstOrDefaultAsync(r => r.RoleTitle == title);
            if (role == null)
                return ResultModel<Role>.NotFound();
            return ResultModel<Role>.Success(role);
        }

        public async Task<ResultModel<List<Role>>> GetRoles()
        {
            var roles = await Table<Role>()
                .Where(r => r.IsDelete == false)
                .OrderByDescending(d => d.CreationDate).ToListAsync();

            return ResultModel<List<Role>>.Success(roles);
        }
    }
}