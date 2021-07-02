using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.CategoryAttribute.Create
{
    public class CreateCategoryAttributeCommandValidator:AbstractValidator<CreateCategoryAttributeCommand>
    {
        public CreateCategoryAttributeCommandValidator()
        {
            RuleFor(r => r.Key)
                .NotEmpty().WithMessage(ValidationMessages.required("کلید"));
        }
    }
}