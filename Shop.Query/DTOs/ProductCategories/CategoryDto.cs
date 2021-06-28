using Shop.Domain.ValueObjects;

namespace Shop.Query.DTOs.ProductCategories
{
    public class CategoryDto : BaseDto<int>
    {
        public string CategoryTitle { get; set; }
        public string Slug { get; set; }
        public MetaValue MetaValue { get; set; }
        public string ImageName { get; set; }
        public int? ParentId { get; set; }
        public bool ShowInMenu { get; set; }
    }
}