using AutoMapper;
using BlogApp.Applications.UserCommands.Commands.CreateUser;
using BlogApp.DbOperations;
using BlogApp.Entities;
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
   public class CreateUserCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly ContextBlog context;
        private readonly IMapper mapper;

        public CreateUserCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenAlreadyExistUserIsGiven_InvalidOperationException_ShouldReturn()
        {
            var user = new User() { Email = "deneme123@gmail.com", Password = "123", UserName = "denemead123", UserSurname = "denemesoyad123", UserStatus = true };
            context.Add(user);
            context.SaveChanges();

            CreateUserCommand command = new CreateUserCommand(context, mapper);
            command.Model = new CreateUserModel() { Email = "deneme123@gmail.com" };

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu e-posta daha önce kullanılmış");
        }

        [Fact]
        public void WhenAllValidInputsAreGiven_User_ShouldBeCreated()
        {
            CreateUserCommand command = new CreateUserCommand(context, mapper);
            CreateUserModel model = new CreateUserModel() { Email = "deneme11@gmail.com", Password = "123", UserName = "denemead2", UserSurname = "denemesoyad2", UserStatus = true };
            command.Model = model;

            FluentActions
                .Invoking(() => command.Handle()).Invoke();
            var user = context.Users.SingleOrDefault(x => x.Email == model.Email);
            user.Should().NotBeNull();
            user.Password.Should().Be(model.Password);
            user.UserName.Should().Be(model.UserName);
            user.UserSurname.Should().Be(model.UserSurname);
            user.UserStatus.Should().BeTrue();
        }
    }
}
