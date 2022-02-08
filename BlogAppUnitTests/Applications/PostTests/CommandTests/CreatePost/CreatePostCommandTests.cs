using AutoMapper;
using BlogApp.Applications.PostCommands.Commands.CreatePost;
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

namespace BlogAppUnitTests.Applications.PostTests.CommandTests.CreatePost
{
   public class CreatePostCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly ContextBlog context;
        private readonly IMapper mapper;

        public CreatePostCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenAlreadyExistedPostTitleIsGiven_InvalidOperationException_ShouldReturn()
        {
            var post = new Post() { PostTitle = "deneme1", PostContext = "deneme1", CategoryId = 1, UserId = 1, PostStatus = true };
            context.Add(post);
            context.SaveChanges();

            CreatePostCommand command = new CreatePostCommand(context, mapper);
            command.Model = new CreatePostModel() { PostTitle = "deneme1" };

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Post zaten mevcut");
        }

        [Fact]
        public void WhenAllInputsAreValid_Post_ShouldBeCreated()
        {
            CreatePostCommand command = new CreatePostCommand(context, mapper);
            CreatePostModel model = new CreatePostModel() { PostTitle = "deneme2", PostContext = "deneme1", CategoryId = 1, UserId = 1, PostStatus = true };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var post = context.Posts.SingleOrDefault(x => x.PostTitle == model.PostTitle);
            post.Should().NotBeNull();
            post.PostContext.Should().Be(model.PostContext);
            post.CategoryId.Should().Be(model.CategoryId);
            post.UserId.Should().Be(model.UserId);
            post.PostStatus.Should().BeTrue();
        }
    }
}
