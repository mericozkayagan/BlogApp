using AutoMapper;
using BlogApp.Applications.PostCommands.Queries.GetPostDetails;
using BlogApp.DbOperations;
using BlogAppUnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogAppUnitTests.Applications.PostTests.QueryTests
{
    public class GetPostDetailsQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly ContextBlog context;
        private readonly IMapper mapper;
        public int PostId { get; set; } = 0;

        public GetPostDetailsQueryTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenPostCannotBeFound_InvalidOperationException_ShouldReturn()
        {
            GetPostDetailsQuery query = new GetPostDetailsQuery(context, mapper);
            query.PostId = PostId;
            FluentActions
                .Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Post bulunamadı veya aktif değil");
        }
    }
}
