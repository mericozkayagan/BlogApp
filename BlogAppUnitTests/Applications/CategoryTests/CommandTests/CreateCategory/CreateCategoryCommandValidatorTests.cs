using BlogApp.Applications.CategoryCommands.Commands.CreateCategory;
using BlogAppUnitTests.TestSetup;
using FluentAssertions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogAppUnitTests.Applications.CategoryTests.CommandTests.CreateCategory
{
    public class CreateCategoryCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("",null)]
        [InlineData("a",null)]
        [InlineData("aa",null)]
        [InlineData("",true)]
        [InlineData("a",true)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string name, bool? status)
        {
            CreateCategoryCommand command = new CreateCategoryCommand(null, null);
            command.Model = new CreateCategoryModel() { CategoryName = name, CategoryStatus = status };

            CreateCategoryCommandValidator validations = new CreateCategoryCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
