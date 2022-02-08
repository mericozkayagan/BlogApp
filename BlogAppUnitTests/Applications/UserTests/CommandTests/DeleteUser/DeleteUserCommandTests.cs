using AutoMapper;
using BlogApp.Applications.UserCommands.Commands.DeleteUser;
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

namespace BlogAppUnitTests.Applications.UserTests.CommandTests.DeleteUser
{
    public class DeleteUserCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly ContextBlog context;
        private readonly IMapper mapper;
        public int UserId { get; set; } = 0;

        public DeleteUserCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenUserIdCannotBeFound_InvalidOperationException_ShouldReturn()
        {
            var user = new User() {Email="asd123@gmail.com",Password="1",UserName="asd",UserSurname="asd",UserStatus=true };
            context.Add(user);
            context.SaveChanges();

            DeleteUserCommand command = new DeleteUserCommand(context, mapper);
            command.UserId = UserId;

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kullanıcı bulunamadı");
        }
    }
}
