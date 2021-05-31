using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Application.DTOs.Groups;
using Blog.Domain.Entities;
using framework;

namespace Blog.Application.Services.Groups
{
    public interface IBlogGroupService
    {
        Task<List<BlogGroupDto>> GetGroups();
        Task<List<BlogPostGroup>> GetGroupsForAdmin();
        Task<ResultModel<BlogGroupDto>> GetGroupBy(long id);
        Task<ResultModel<BlogGroupDto>> GetGroupBy(string englishTitle);
        Task<bool> IsEnglishTitleExist(string englishTitle);
        Task<ResultModel> InsertGroup(InsertBlogGroupDto model);
        Task<ResultModel> EditGroup(EditBlogGroupDto model);
        Task<ResultModel> DeleteGroup(long groupId);
    }
}