using FluentValidation;

namespace Blog.Application.Services.PostGroups.Commands.EditGroup
{
    public class EditPostGroupCommandValidator:AbstractValidator<EditPostGroupCommand>
    {
        public EditPostGroupCommandValidator()
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