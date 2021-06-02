using AutoMapper;
using Blog.Application.DTOs.Groups;
using Blog.Application.ViewModels;
using Blog.Application.ViewModels.PostGroups;
using Blog.Domain.Entities;
using Blog.Domain.Entities.BlogPostGroupAggregate;

namespace Blog.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<InsertBlogGroupViewModel, BlogPostGroup>().ReverseMap();
            CreateMap<EditBlogGroupViewModel, BlogPostGroup>().ReverseMap();
            CreateMap<BlogGroupDto, BlogPostGroup>().ReverseMap();
            CreateMap<BlogGroupDto, EditBlogGroupViewModel>().ReverseMap();
        }
    }
}