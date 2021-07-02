using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.CategoryAttribute.Edit
{
    public class EditCategoryAttributeCommandValidator : AbstractValidator<EditCategoryAttributeCommand>
    {
        public EditCategoryAttributeCommandValidator()
        {
            RuleFor(r => r.Key)
                .NotEmpty().WithMessage(ValidationMessages.required("کلید"));
        }
    }
}