namespace Shop.Query.DTOs.ProductCategories
{
    public class CategoryAttributeDto
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string Hint { get; set; }
        public string Key { get; set; }
        public int DisplayOrder { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
        public bool ShowInLandingPage { get; set; }
    }
}