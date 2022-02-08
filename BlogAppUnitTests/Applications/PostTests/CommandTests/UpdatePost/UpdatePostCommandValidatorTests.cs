using BlogApp.Applications.PostCommands.Commands.UpdatePost;
using BlogAppUnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogAppUnitTests.Applications.PostTests.CommandTests.UpdatePost
{
    public class UpdatePostCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0, 0, "", "")]
        [InlineData(1, 0, "", "")]
        [InlineData(0, 1, "", "")]
        [InlineData(1, 1, "", "")]
        //
        [InlineData(0, 0, "a", "")]
        [InlineData(1, 0, "a", "")]
        [InlineData(0, 1, "a", "")]
        [InlineData(1, 1, "a", "")]
        //
        [InlineData(0, 0, "", "a")]
        [InlineData(1, 0, "", "a")]
        [InlineData(0, 1, "", "a")]
        [InlineData(1, 1, "", "a")]
        //
        [InlineData(0, 0, "a", "a")]
        [InlineData(1, 0, "a", "a")]
        [InlineData(0, 1, "a", "a")]
        [InlineData(1, 1, "a", "a")]
        //
        [InlineData(0, 0, "aa", "")]
        [InlineData(1, 0, "aa", "")]
        [InlineData(0, 1, "aa", "")]
        [InlineData(1, 1, "aa", "")]
        //
        [InlineData(0, 0, "", "aa")]
        [InlineData(1, 0, "", "aa")]
        [InlineData(0, 1, "", "aa")]
        [InlineData(1, 1, "", "aa")]
        //
        [InlineData(0, 0, "aa", "a")]
        [InlineData(1, 0, "aa", "a")]
        [InlineData(0, 1, "aa", "a")]
        [InlineData(1, 1, "aa", "a")]
        //
        [InlineData(0, 0, "a", "aa")]
        [InlineData(1, 0, "a", "aa")]
        [InlineData(0, 1, "a", "aa")]
        [InlineData(1, 1, "a", "aa")]
        //
        [InlineData(0, 0, "aa", "aa")]
        [InlineData(1, 0, "aa", "aa")]
        [InlineData(0, 1, "aa", "aa")]
        [InlineData(1, 1, "aa", "aa")]       
        
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(int categoryId, int userId, string title, string context)
        {
            UpdatePostCommand command = new UpdatePostCommand(null, null);
            command.Model = new UpdatePostModel() { CategoryId = categoryId, UserId = userId, PostTitle = title, PostContext = context};
            command.PostId = 0;
            UpdatePostCommandValidator validations = new UpdatePostCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
