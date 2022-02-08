using AutoMapper;
using BlogApp.Applications.UserCommands.Commands.UpdateUser;
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

namespace BlogAppUnitTests.Applications.UserTests.CommandTests.UpdateUser
{
    public class UpdateUserCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly ContextBlog context;
        private readonly IMapper mapper;
        public int UserId { get; set; } = 0;

        public UpdateUserCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenUserIdCannotBeFound_InvalidOperationException_ShouldReturn()
        {
            var user = new User() { UserName="dsa",UserSurname="dsa",Email="das@gmail.com",Password="321",UserStatus=true};
            context.Add(user);
            context.SaveChanges();

            UpdateUserCommand command = new UpdateUserCommand(context, mapper);
            command.UserId = UserId;

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kullanıcı bulunamadı");

        }
    }
}
