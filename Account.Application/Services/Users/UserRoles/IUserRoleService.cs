using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Domain.Entities.Roles;
using framework;

namespace Account.Application.Services.Users.UserRoles
{
    public interface IUserRoleService
    {
        Task<ResultModel<List<Role>>> GetUserRoles(long userId);
        Task<ResultModel> AddUserRole(long roleId, long userId);
        Task<ResultModel> AddUserRole(List<long> roleIds, long userId);
    }
}