using AutoMapper;
using BlogApp.Applications.UserCommands.Queries.GetUserDetails;
using BlogApp.DbOperations;
using BlogAppUnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogAppUnitTests.Applications.UserTests.QueryTests
{
    public class GetUserDetailsQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly ContextBlog context;
        private readonly IMapper mapper;
        public int UserId { get; set; } = 0;

        public GetUserDetailsQueryTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenUserCannotBeFound_InvalidOperationException_ShouldReturn()
        {
            GetUserDetailsQuery query = new GetUserDetailsQuery(context, mapper);
            query.UserId = UserId;
            FluentActions
                .Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kullanıcı bulunamadı");
        }
    }
}
