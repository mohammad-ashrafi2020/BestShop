using AutoMapper;
using Blog.Application.DTOs.Groups;
using Blog.Domain.Entities;

namespace Blog.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<InsertBlogGroupDto, BlogPostGroup>().ReverseMap();
            CreateMap<EditBlogGroupDto, BlogPostGroup>().ReverseMap();
            CreateMap<BlogGroupDto, BlogPostGroup>().ReverseMap();
            CreateMap<BlogGroupDto, EditBlogGroupDto>().ReverseMap();
        }
    }
}