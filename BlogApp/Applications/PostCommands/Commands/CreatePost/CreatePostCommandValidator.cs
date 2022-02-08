using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.PostCommands.Commands.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(x => x.Model.CategoryId).GreaterThan(0);
            RuleFor(x => x.Model.UserId).GreaterThan(0);
            RuleFor(x => x.Model.PostTitle).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.PostContext).NotEmpty().MinimumLength(10);
            RuleFor(x => x.Model.PostStatus).NotEmpty();
        }
    }
}
