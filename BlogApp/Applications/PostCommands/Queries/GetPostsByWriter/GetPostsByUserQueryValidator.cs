using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.PostCommands.Queries.GetPostsByWriter
{
    public class GetPostsByUserQueryValidator : AbstractValidator<GetPostsByUserQuery>
    {
        public GetPostsByUserQueryValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}
