namespace Shop.Query.DTOs.ProductCategories
{
    public class CategoryAttributeDto : BaseDto<long>
    {
        public long? ParentId { get; set; }
        public string Hint { get; set; }
        public string Key { get; set; }
        public int DisplayOrder { get; set; }
        public int CategoryId { get; set; }
        public bool ShowInLandingPage { get; set; }
    }
}