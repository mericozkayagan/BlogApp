using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.CategoryCommands.Queries.GetCategoryDetails
{
    public class GetCategoryDetailsQueryValidator : AbstractValidator<GetCategoryDetailsQuery>
    {
        public GetCategoryDetailsQueryValidator()
        {
            RuleFor(x => x.CategoryId).GreaterThan(0);
        }
    }
}
