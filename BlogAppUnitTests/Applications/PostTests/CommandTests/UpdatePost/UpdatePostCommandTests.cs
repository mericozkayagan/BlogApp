using AutoMapper;
using BlogApp.Applications.PostCommands.Commands.UpdatePost;
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

namespace BlogAppUnitTests.Applications.PostTests.CommandTests.UpdatePost
{
    public class UpdatePostCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly ContextBlog context;
        private readonly IMapper mapper;
        public int PostId { get; set; } = 0;

        public UpdatePostCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenPostIdCannotBeFound_InvalidOperationException_ShouldReturn()
        {
            var post = new Post() { CategoryId=1,UserId=1,PostStatus=true,PostContext="asdasd",PostTitle="asdas" };
            context.Add(post);
            context.SaveChanges();

            UpdatePostCommand command = new UpdatePostCommand(context, mapper);
            command.PostId = PostId;

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Post bulunamadı");

        }
    }
}
