using BlogApp.Applications.UserCommands.Commands.UpdateUser;
using BlogAppUnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogAppUnitTests.Applications.UserTests.CommandTests.UpdateUser
{
    public class UpdateUserCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("", "", "", "")]
        [InlineData("a", "", "", "")]
        [InlineData("aa", "", "", "")]
        [InlineData("", "a", "", "")]
        [InlineData("", "aa", "", "")]
        [InlineData("", "", "a", "")]
        [InlineData("", "", "aa", "")]
        [InlineData("", "", "", "a")]
        [InlineData("", "", "", "aa")]        
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string a, string b, string c, string d)
        {
            UpdateUserCommand command = new UpdateUserCommand(null, null);
            command.Model = new UpdateUserModel() { Email = a, Password = b, UserName = c, UserSurname = d };
            command.UserId = 0;
            UpdateUserCommandValidator validations = new UpdateUserCommandValidator();
            var result = validations.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
