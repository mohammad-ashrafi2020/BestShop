using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Brands.Edit
{
    public class EditBrandCommandValidator : AbstractValidator<EditBrandCommand>
    {
        public EditBrandCommandValidator()
        {
            RuleFor(r => r.Name).NotEmpty().WithMessage(ValidationMessages.required("نام"));
        }
    }
}