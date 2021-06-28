using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Brands.Create
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(r => r.Name).NotEmpty().WithMessage(ValidationMessages.required("نام"));
        }
    }
}