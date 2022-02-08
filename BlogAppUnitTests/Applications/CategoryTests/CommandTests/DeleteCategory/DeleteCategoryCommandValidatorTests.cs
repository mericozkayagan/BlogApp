using BlogApp.Applications.CategoryCommands.Commands.DeleteCategory;
using BlogAppUnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogAppUnitTests.Applications.CategoryTests.CommandTests.DeleteCategory
{
    public class DeleteCategoryCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputIsGiven_Validator_ShouldReturn()
        {
            DeleteCategoryCommand command = new DeleteCategoryCommand(null, null);
            command.CategoryId = 0;

            DeleteCategoryCommandValidator validations = new DeleteCategoryCommandValidator();
            var result = validations.Validate(command);
            result.Errors.Count.Should().Be(1);
        }
    }
}
