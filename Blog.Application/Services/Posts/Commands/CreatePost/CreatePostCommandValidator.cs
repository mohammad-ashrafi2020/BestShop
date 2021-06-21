using Common.Application.Validation;
using Common.Core;
using FluentValidation;

namespace Blog.Application.Services.Posts.Commands.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotEmpty().WithMessage(ValidationMessages.required("عنوان مقاله"));
            RuleFor(r => r.Description)
                .NotEmpty().WithMessage(ValidationMessages.required("متن مقاله"));

            RuleFor(r => r.Slug)
                .NotEmpty().WithMessage(ValidationMessages.required("نام انگلیسی"));

            RuleFor(r => r.ImageAlt)
                .NotEmpty();

            RuleFor(r => r.Tags)
                .NotEmpty().WithMessage(ValidationMessages.required("کلمات کلیدی"));
        }
    }
      
}
