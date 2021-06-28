using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.ProductCategories.ProductCategoryAttribute.Edit
{
    public class EditProductCategoryAttributeCommandValidator : AbstractValidator<EditProductCategoryAttributeCommand>
    {
        public EditProductCategoryAttributeCommandValidator()
        {
            RuleFor(r => r.Key)
                .NotEmpty().WithMessage(ValidationMessages.required("کلید"));
        }
    }
}