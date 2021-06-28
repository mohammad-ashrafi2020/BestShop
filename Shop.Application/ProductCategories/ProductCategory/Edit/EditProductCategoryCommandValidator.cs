using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.ProductCategories.ProductCategory.Edit
{
    public class EditProductCategoryCommandValidator:AbstractValidator<EditProductCategoryCommand>
    {
        public EditProductCategoryCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotEmpty().WithMessage(ValidationMessages.required("عنوان گروه"));

            RuleFor(r => r.Slug)
                .NotEmpty().WithMessage(ValidationMessages.required("Slug"));
        }
    }
}