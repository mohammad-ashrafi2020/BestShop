using Common.Core.Utilities;

namespace Shop.Application.Utilities
{
    public static class ShopDirectories
    {
        public static string ProductCategories = "wwwroot/images/productCategories";
        public static string Brands(string brandName) => $"wwwroot/images/brands/{brandName.ToSlug()}";

        public static string GetProductCategory(string imageName) => $"{ProductCategories.Replace("wwwroot", "")}/{imageName}";
    }
}