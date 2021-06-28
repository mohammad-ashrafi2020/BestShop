namespace Shop.Query.DTOs
{
    public class BaseDto<TKey>
    {
        public bool IsActive { get; set; }
        public TKey Id { get; set; }
    }
}