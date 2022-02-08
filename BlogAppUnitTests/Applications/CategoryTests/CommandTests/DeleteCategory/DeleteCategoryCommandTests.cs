using AutoMapper;
using BlogApp.Applications.CategoryCommands.Commands.DeleteCategory;
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

namespace BlogAppUnitTests.Applications.CategoryTests.CommandTests.DeleteCategory
{
    public class DeleteCategoryCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly ContextBlog context;
        private readonly IMapper mapper;
        public int CategoryId { get; set; } = 0;

        public DeleteCategoryCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenCategoryIdCannotBeFound_InvalidOperationException_ShouldReturn()
        {
            var category = new Category() { CategoryName = "test1", CategoryStatus = true };
            context.Add(category);
            context.SaveChanges();

            DeleteCategoryCommand command = new DeleteCategoryCommand(context, mapper);
            command.CategoryId = CategoryId;

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kategori bulunamadı");
        }
    }
}
