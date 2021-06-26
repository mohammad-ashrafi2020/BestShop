using Common.Application.Validation;
using Common.Core;
using FluentValidation;

namespace Blog.Application.Services.PostGroups.Commands.CreateGroup
{
    public class CreatePostGroupCommandValidator : AbstractValidator<CreatePostGroupCommand>
    {
        public CreatePostGroupCommandValidator()
        {
            RuleFor(r => r.EnglishGroupTitle)
                .NotEmpty().WithMessage(ValidationMessages.required("عنوان انگلیسی"));

            RuleFor(r => r.GroupTitle)
                .NotEmpty().WithMessage(ValidationMessages.required("عنوان گروه"));

            RuleFor(r => r.MetaDescription)
                .NotEmpty().WithMessage("Meta Description is Required");
        }
    }
}