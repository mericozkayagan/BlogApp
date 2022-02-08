using BlogApp.Applications.UserCommands.Commands.CreateUser;
using BlogAppUnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogAppUnitTests.Applications.UserTests.CommandTests.CreateUser
{
    public class CreateUserCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("","","","",null)]
        [InlineData("a","","","",null)]
        [InlineData("aa","","","",null)]
        [InlineData("","a","","",null)]
        [InlineData("","aa","","",null)]
        [InlineData("","","a","",null)]
        [InlineData("","","aa","",null)]
        [InlineData("","","","a",null)]
        [InlineData("","","","aa",null)]
        [InlineData("","","","",true)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string a, string b, string c, string d, bool? status)
        {
            CreateUserCommand command = new CreateUserCommand(null, null);
            command.Model = new CreateUserModel() { Email = a, Password = b, UserName = c, UserStatus = status, UserSurname = d };
            CreateUserCommandValidator validations = new CreateUserCommandValidator();
            var result = validations.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

    }
}
