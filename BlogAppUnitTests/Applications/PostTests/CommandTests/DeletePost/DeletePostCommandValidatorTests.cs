using BlogApp.Applications.PostCommands.Commands.DeletePost;
using BlogAppUnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogAppUnitTests.Applications.PostTests.CommandTests.DeletePost
{
   public class DeletePostCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputIsGiven_Validator_ShouldReturn()
        {
            DeletePostCommand command = new DeletePostCommand(null, null);
            command.PostId = 0;

            DeletePostCommandValidator validations = new DeletePostCommandValidator();
            var result = validations.Validate(command);
            result.Errors.Count.Should().Be(1);
        }
    }
}
