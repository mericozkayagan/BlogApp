using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.CategoryCommands.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.CategoryId).GreaterThan(0);
            RuleFor(x => x.Model.CategoryName).NotEmpty().MinimumLength(2);
        }
    }
}
