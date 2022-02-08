using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.UserCommands.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
            RuleFor(x => x.Model.Email).MinimumLength(2).NotEmpty();
            RuleFor(x => x.Model.UserName).MinimumLength(2).NotEmpty();
            RuleFor(x => x.Model.UserSurname).MinimumLength(2).NotEmpty();
            RuleFor(x => x.Model.Password).MinimumLength(2).NotEmpty();
        }
    }
}
