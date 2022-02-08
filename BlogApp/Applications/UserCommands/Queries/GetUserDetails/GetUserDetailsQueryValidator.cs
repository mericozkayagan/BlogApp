using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.UserCommands.Queries.GetUserDetails
{
    public class GetUserDetailsQueryValidator : AbstractValidator<GetUserDetailsQuery>
    {
        public GetUserDetailsQueryValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}
