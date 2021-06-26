namespace Shop.Domain.ValueObjects
{
    public class MetaValue
    {
        public MetaValue(string title, string description, string keyWords)
        {
            Title = title;
            Description = description;
            KeyWords = keyWords;
        }

        public string Description { get; private set; }
        public string KeyWords { get; private set; }
        public string Title { get; private set; }
    }
}