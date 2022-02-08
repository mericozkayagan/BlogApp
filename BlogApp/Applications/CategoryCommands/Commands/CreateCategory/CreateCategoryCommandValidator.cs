using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.CategoryCommands.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Model.CategoryName).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.CategoryStatus).NotEmpty();
        }
    }
}
