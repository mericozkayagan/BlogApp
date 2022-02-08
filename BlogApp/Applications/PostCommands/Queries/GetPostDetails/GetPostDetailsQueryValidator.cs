using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.PostCommands.Queries.GetPostDetails
{
    public class GetPostDetailsQueryValidator : AbstractValidator<GetPostDetailsQuery>
    {
        public GetPostDetailsQueryValidator()
        {
            RuleFor(x => x.PostId).GreaterThan(0);
        }
    }
}
