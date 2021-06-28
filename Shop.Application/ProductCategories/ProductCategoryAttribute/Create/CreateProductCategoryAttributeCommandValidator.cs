using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.ProductCategories.ProductCategoryAttribute.Create
{
    public class CreateProductCategoryAttributeCommandValidator:AbstractValidator<CreateProductCategoryAttributeCommand>
    {
        public CreateProductCategoryAttributeCommandValidator()
        {
            RuleFor(r => r.Key)
                .NotEmpty().WithMessage(ValidationMessages.required("کلید"));
        }
    }
}