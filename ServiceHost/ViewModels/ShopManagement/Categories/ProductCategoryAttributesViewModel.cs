using System.ComponentModel.DataAnnotations;

namespace AdminPanel.ViewModels.ShopManagement.Categories
{
    public class AddProductCategoryAttributeViewModel
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public string Key { get; set; }

        [Display(Name = "توضیحات مربوط به عنوان")]
        [DataType(DataType.MultilineText)]
        public string Hint { get; set; }

        [Display(Name = "ترتیب نمایش")]
        public int DisplayOrder { get; set; }
        public int CategoryId { get; set; }
        public long? ParentId { get; set; }

        [Display(Name = "نمایش در صفحه محصول")]
        public bool ShowInLandingPage { get; set; }


    }

    public class EditProductCategoryAttributeViewModel : AddProductCategoryAttributeViewModel
    {
        public long Id { get; set; }
    }
}