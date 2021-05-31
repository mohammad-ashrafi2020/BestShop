using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.Domain.Entities.Roles;
using Account.Domain.Entities.Users;
using Account.Infrastructure.Context;
using framework;
using framework.Services;
using Microsoft.EntityFrameworkCore;

namespace Account.Application.Services.Users.UserRoles
{
    public class UserRoleService : BaseService, IUserRoleService
    {
        public UserRoleService(AccountContext context) : base(context)
        {
        }

        public async Task<ResultModel<List<Role>>> GetUserRoles(long userId)
        {
            var data = await Table<UserRole>()
                .Include(c => c.Role)
                .OrderByDescending(d => d.CreationDate)
                .Where(r => r.UserId == userId)
                .Select(s => s.Role)
                .ToListAsync();

            return ResultModel<List<Role>>.Success(data);
        }

        public async Task<ResultModel> AddUserRole(long roleId, long userId)
        {
            Insert(new UserRole()
            {
                RoleId = roleId,
                UserId = userId
            });
            await Save();
            return ResultModel.Success();
        }

        public async Task<ResultModel> AddUserRole(List<long> roleIds, long userId)
        {
            var userRoles = await GetUserRoles(userId);
            if(userRoles.Data.Any())
                Delete(userRoles.Data);
            foreach (var roleId in roleIds)
            {
                Insert(new UserRole()
                {
                    RoleId = roleId,
                    UserId = userId
                });
            }
            await Save();
            return ResultModel.Success();
        }
    }
}