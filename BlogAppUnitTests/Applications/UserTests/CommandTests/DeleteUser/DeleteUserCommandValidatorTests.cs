using BlogApp.Applications.UserCommands.Commands.DeleteUser;
using BlogAppUnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogAppUnitTests.Applications.UserTests.CommandTests.DeleteUser
{
    public class DeleteUserCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputIsGiven_Validator_ShouldReturn()
        {
            DeleteUserCommand command = new DeleteUserCommand(null, null);
            command.UserId = 0;

            DeleteUserCommandValidator validations = new DeleteUserCommandValidator();
            var result = validations.Validate(command);
            result.Errors.Count.Should().Be(1);
        }
    }
}
