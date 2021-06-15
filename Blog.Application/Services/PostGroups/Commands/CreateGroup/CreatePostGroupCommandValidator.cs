using FluentValidation;

namespace Blog.Application.Services.PostGroups.Commands.CreateGroup
{
    public class CreatePostGroupCommandValidator : AbstractValidator<CreatePostGroupCommand>
    {
        public CreatePostGroupCommandValidator()
        {
            RuleFor(r => r.EnglishGroupTitle)
                .NotEmpty().WithMessage(framework.ValidationMessages.required("عنوان انگلیسی"));

            RuleFor(r => r.GroupTitle)
                .NotEmpty().WithMessage(framework.ValidationMessages.required("عنوان گروه"));

            RuleFor(r => r.MetaDescription)
                .NotEmpty().WithMessage("Meta Description is Required");
        }
    }
}