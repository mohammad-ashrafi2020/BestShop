namespace Shop.Query.DTOs.Brands
{
    public class BrandDto : BaseDto<int>
    {
        public string Name { get; set; }
        public string LogoName { get; set; }
        public string ImageName { get; set; }
    }
}