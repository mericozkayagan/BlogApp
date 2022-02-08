using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.UserCommands.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Model.Email).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.Password).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.UserName).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.UserSurname).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.UserStatus).NotEmpty();
        }
    }
}
