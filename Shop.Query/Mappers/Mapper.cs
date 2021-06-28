using Shop.Domain.Brands;
using Shop.Domain.Categories;
using Shop.Domain.Categories.CategoryAttributes;
using Shop.Query.DTOs.Brands;
using Shop.Query.DTOs.ProductCategories;

namespace Shop.Query.Mappers
{
    public static class Mapper
    {
        public static CategoryDto MapCategory(Category category)
        {
            return new CategoryDto()
            {
                MetaValue = category.MetaValue,
                ImageName = category.ImageName,
                ParentId = category.ParentId,
                Slug = category.Slug,
                CategoryTitle = category.CategoryTitle,
                ShowInMenu = category.ShowInMenu,
                Id = category.Id,
                IsActive = !category.IsDelete
            };
        }
        public static CategoryAttributeDto MapCategoryAttribute(CategoryAttribute model)
        {
            return new CategoryAttributeDto()
            {
                CategoryId = model.CategoryId,
                DisplayOrder = model.DisplayOrder,
                Hint = model.Hint,
                Id = model.Id,
                IsActive = !model.IsDelete,
                Key = model.Key,
                ParentId = model.ParentId,
                ShowInLandingPage = model.ShowInLandingPage
            };
        }
        public static BrandDto MapBrand(Brand model)
        {
            return new BrandDto()
            {
                Id = model.Id,
                IsActive = !model.IsDelete,
                ImageName = model.MainImage,
                LogoName = model.Logo,
                Name = model.Name
            };
        }
    }
}