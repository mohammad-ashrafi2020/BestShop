using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Application.DTOs.Groups;
using Blog.Domain.Entities;
using Blog.Infrastructure.Context;
using framework;
using framework.Services;
using framework.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.Groups
{
    public class BlogGroupService : BaseService, IBlogGroupService
    {
        private IMapper _mapper;

        public BlogGroupService(BlogContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<BlogGroupDto>> GetGroups()
        {
            var data = await Table<BlogPostGroup>()
                .OrderByDescending(d => d.CreationDate)
                .Select(s => new BlogGroupDto()
                {
                    CreationDate = s.CreationDate,
                    EnglishGroupTitle = s.EnglishGroupTitle,
                    Id = s.Id,
                    MetaDescription = s.MetaDescription,
                    ParentId = s.ParentId,
                    GroupTitle = s.GroupTitle
                }).ToListAsync();
            return data;
        }

        public async Task<List<BlogPostGroup>> GetGroupsForAdmin()
        {
            return await Table<BlogPostGroup>()
                .Include(c=>c.Groups)
                .OrderByDescending(d => d.CreationDate).ToListAsync();
        }

        public async Task<ResultModel<BlogGroupDto>> GetGroupBy(long id)
        {
            var data = await GetById<BlogPostGroup>(id);
            if (data == null)
                return ResultModel<BlogGroupDto>.NotFound("گروه مورد نظر یافت نشد");
            return ResultModel<BlogGroupDto>.Success(_mapper.Map<BlogGroupDto>(data));
        }

        public async Task<ResultModel<BlogGroupDto>> GetGroupBy(string englishTitle)
        {
            var data = await Table<BlogPostGroup>().SingleOrDefaultAsync(g => g.EnglishGroupTitle == englishTitle);
            if (data == null)
                return ResultModel<BlogGroupDto>.NotFound("گروه مورد نظر یافت نشد");
            return ResultModel<BlogGroupDto>.Success(_mapper.Map<BlogGroupDto>(data));
        }

        public async Task<bool> IsEnglishTitleExist(string englishTitle)
        {
            return await Exists<BlogPostGroup>(g => g.EnglishGroupTitle == englishTitle.FixTextForUrl());
        }

        public async Task<ResultModel> InsertGroup(InsertBlogGroupDto model)
        {
            if(model.EnglishGroupTitle.IsUniCode())
                return ResultModel.Error("عنوان انگلیسی نمی تواند شامل کلمات فارسی باشد");
            model.EnglishGroupTitle = model.EnglishGroupTitle.FixTextForUrl();
            if (await IsEnglishTitleExist(model.EnglishGroupTitle))
                return ResultModel.Error("نام انگلیسی گروه تکراری است");

            var group = _mapper.Map<BlogPostGroup>(model);
            Insert(group);
            await Save();
            return ResultModel.Success();
        }

        public async Task<ResultModel> EditGroup(EditBlogGroupDto model)
        {
            if (model.EnglishGroupTitle.IsUniCode())
                return ResultModel.Error("عنوان انگلیسی نمی تواند شامل کلمات فارسی باشد");

            var group = await GetById<BlogPostGroup>(model.Id);
            if (group == null)
                return ResultModel.Error();

            if (group.EnglishGroupTitle != model.EnglishGroupTitle)
                if (await IsEnglishTitleExist(model.EnglishGroupTitle))
                    return ResultModel.Error("نام انگلیسی گروه تکراری است");


            group.EnglishGroupTitle = model.EnglishGroupTitle.FixTextForUrl();
            group.MetaDescription = model.MetaDescription;
            group.GroupTitle = model.GroupTitle;

            Update(group);
            await Save();
            return ResultModel.Success();
        }

        public async Task<ResultModel> DeleteGroup(long groupId)
        {
            var group = await Table<BlogPostGroup>()
                .Include(c => c.Groups)
                .Include(b => b.MainBlogPosts)
                .Include(c => c.SubBlogPosts)
                .SingleOrDefaultAsync(g => g.Id == groupId);
            if (group == null)
                return ResultModel.Error();
            if (group.MainBlogPosts.Any() || group.MainBlogPosts.Any())
                return ResultModel.Error("امکان حدف این گروه وجود ندارد");

            if (group.Groups.Any())
                foreach (var child in group.Groups)
                {
                    Delete(child);
                }

            Delete(group);
            await Save();
            return ResultModel.Success();
        }
    }
}