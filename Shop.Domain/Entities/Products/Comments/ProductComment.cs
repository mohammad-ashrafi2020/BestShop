using System.ComponentModel.DataAnnotations.Schema;
using _DomainUtils.Domain;
using Shop.Domain.Entities.Orders;

namespace Shop.Domain.Entities.Products.Comments
{
    public class ProductComment:BaseEntity
    {
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public long DetailId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsActive { get; set; }
        public bool IsRecommended { get; set; }
        public string Advantages { get; set; }
        public string Disadvantages { get; set; }

        #region Relations

        public Product Product { get; set; }
        [ForeignKey("DetailId")]
        public OrderDetail OrderDetail { get; set; }

        #endregion
    }
}