using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Domain.Entities.Roles;
using framework;

namespace Account.Application.Services.Roles
{
    public interface IRoleService
    {
        Task<ResultModel> InsertRole(string roleTitle);
        Task<ResultModel> DeleteRole(long roleId, long deletedBy);
        Task<ResultModel> EditRole(long roleId, string newRoleTitle);
        Task<ResultModel<Role>> GetRoleBy(long id);
        Task<ResultModel<Role>> GetRoleBy(string title);
        Task<ResultModel<List<Role>>> GetRoles();
    }
}