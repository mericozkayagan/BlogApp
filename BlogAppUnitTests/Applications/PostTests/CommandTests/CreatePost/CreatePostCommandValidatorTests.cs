using BlogApp.Applications.PostCommands.Commands.CreatePost;
using BlogAppUnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogAppUnitTests.Applications.PostTests.CommandTests.CreatePost
{
    public class CreatePostCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0,0,"","",null)]
        [InlineData(1,0,"","",null)]
        [InlineData(0,1,"","",null)]
        [InlineData(1,1,"","",null)]
        //
        [InlineData(0, 0, "a", "", null)]
        [InlineData(1, 0, "a", "", null)]
        [InlineData(0, 1, "a", "", null)]
        [InlineData(1, 1, "a", "", null)]
        //
        [InlineData(0, 0, "", "a", null)]
        [InlineData(1, 0, "", "a", null)]
        [InlineData(0, 1, "", "a", null)]
        [InlineData(1, 1, "", "a", null)]
        //
        [InlineData(0, 0, "a", "a", null)]
        [InlineData(1, 0, "a", "a", null)]
        [InlineData(0, 1, "a", "a", null)]
        [InlineData(1, 1, "a", "a", null)]
        //
        [InlineData(0, 0, "aa", "", null)]
        [InlineData(1, 0, "aa", "", null)]
        [InlineData(0, 1, "aa", "", null)]
        [InlineData(1, 1, "aa", "", null)]
        //
        [InlineData(0, 0, "", "aa", null)]
        [InlineData(1, 0, "", "aa", null)]
        [InlineData(0, 1, "", "aa", null)]
        [InlineData(1, 1, "", "aa", null)]
        //
        [InlineData(0, 0, "aa", "a", null)]
        [InlineData(1, 0, "aa", "a", null)]
        [InlineData(0, 1, "aa", "a", null)]
        [InlineData(1, 1, "aa", "a", null)]
        //
        [InlineData(0, 0, "a", "aa", null)]
        [InlineData(1, 0, "a", "aa", null)]
        [InlineData(0, 1, "a", "aa", null)]
        [InlineData(1, 1, "a", "aa", null)]
        //
        [InlineData(0, 0, "aa", "aa", null)]
        [InlineData(1, 0, "aa", "aa", null)]
        [InlineData(0, 1, "aa", "aa", null)]
        [InlineData(1, 1, "aa", "aa", null)]
        //
        [InlineData(0, 0, "", "", true)]
        [InlineData(1, 0, "", "", true)]
        [InlineData(0, 1, "", "", true)]
        [InlineData(1, 1, "", "", true)]
        //
        [InlineData(0, 0, "a", "", true)]
        [InlineData(1, 0, "a", "", true)]
        [InlineData(0, 1, "a", "", true)]
        [InlineData(1, 1, "a", "", true)]
        //
        [InlineData(0, 0, "", "a", true)]
        [InlineData(1, 0, "", "a", true)]
        [InlineData(0, 1, "", "a", true)]
        [InlineData(1, 1, "", "a", true)]
        //
        [InlineData(0, 0, "a", "a", true)]
        [InlineData(1, 0, "a", "a", true)]
        [InlineData(0, 1, "a", "a", true)]
        [InlineData(1, 1, "a", "a", true)]
        //
        [InlineData(0, 0, "aa", "", true)]
        [InlineData(1, 0, "aa", "", true)]
        [InlineData(0, 1, "aa", "", true)]
        [InlineData(1, 1, "aa", "", true)]
        //
        [InlineData(0, 0, "", "aa", true)]
        [InlineData(1, 0, "", "aa", true)]
        [InlineData(0, 1, "", "aa", true)]
        [InlineData(1, 1, "", "aa", true)]
        //
        [InlineData(0, 0, "aa", "a", true)]
        [InlineData(1, 0, "aa", "a", true)]
        [InlineData(0, 1, "aa", "a", true)]
        [InlineData(1, 1, "aa", "a", true)]
        //
        [InlineData(0, 0, "a", "aa", true)]
        [InlineData(1, 0, "a", "aa", true)]
        [InlineData(0, 1, "a", "aa", true)]
        [InlineData(1, 1, "a", "aa", true)]
        //
        [InlineData(0, 0, "aa", "aa", true)]
        [InlineData(1, 0, "aa", "aa", true)]
        [InlineData(0, 1, "aa", "aa", true)]
        //[InlineData(1, 1, "aa", "aa", true)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(int categoryId,int userId,string title,string context, bool? status)
        {
            CreatePostCommand command = new CreatePostCommand(null, null);
            command.Model = new CreatePostModel() { CategoryId = categoryId, UserId = userId, PostTitle = title, PostContext = context, PostStatus = status };

            CreatePostCommandValidator validations = new CreatePostCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
