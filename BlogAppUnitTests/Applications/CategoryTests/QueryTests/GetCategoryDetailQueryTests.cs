using AutoMapper;
using BlogApp.Applications.CategoryCommands.Queries.GetCategoryDetails;
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

namespace BlogAppUnitTests.Applications.CategoryTests.QueryTests
{
    public class GetCategoryDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly ContextBlog context;
        private readonly IMapper mapper;
        public int CategoryId { get; set; } = 0;

        public GetCategoryDetailQueryTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenCategoryCannotBeFound_InvalidOperationException_ShouldReturn()
        {
            GetCategoryDetailsQuery query = new GetCategoryDetailsQuery(context, mapper);
            query.CategoryId = CategoryId;
            FluentActions
                .Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kategori bulunamadı veya durumu aktif değil");
        }
    }
}
