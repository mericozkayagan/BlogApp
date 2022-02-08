using BlogApp.Applications.CategoryCommands.Commands.UpdateCategory;
using BlogAppUnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogAppUnitTests.Applications.CategoryTests.CommandTests.UpdateCategory
{
    public class UpdateCategoryCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("")]
        [InlineData("a")]       
        
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string name)
        {
            UpdateCategoryCommand command = new UpdateCategoryCommand(null, null);
            command.Model = new UpdateCategoryModel() { CategoryName = name };
            command.CategoryId = 0;

            UpdateCategoryCommandValidator validations = new UpdateCategoryCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
