using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.ProductCategories.ProductCategory.Create
{
    public class CreateProductCategoryCommandValidator: AbstractValidator<CreateProductCategoryCommand>
    {
        public CreateProductCategoryCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotEmpty().WithMessage(ValidationMessages.required("عنوان گروه"));

            RuleFor(r => r.Slug)
                .NotEmpty().WithMessage(ValidationMessages.required("Slug"));
        }
    }
}