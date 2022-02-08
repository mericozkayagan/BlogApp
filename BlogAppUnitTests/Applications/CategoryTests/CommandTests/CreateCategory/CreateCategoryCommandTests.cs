using AutoMapper;
using BlogApp.Applications.CategoryCommands.Commands.CreateCategory;
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

namespace BlogAppUnitTests.Applications.CategoryTests.CommandTests.CreateCategory
{
    public class CreateCategoryCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly ContextBlog context;
        private readonly IMapper mapper;

        public CreateCategoryCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenAlreadyExistedCategoryIsGiven_InvalidOperationException_ShouldReturn()
        {
            var category = new Category() { CategoryName = "test", CategoryStatus = true };
            context.Add(category);
            context.SaveChanges();
            CreateCategoryCommand command = new CreateCategoryCommand(context,mapper);
            command.Model = new CreateCategoryModel() { CategoryName = "test", CategoryStatus = true };

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kategori zaten mevcut");
        }

        [Fact]
        public void WhenAllInputsAreValid_Category_ShouldBeCreated()
        {
            CreateCategoryCommand command = new CreateCategoryCommand(context, mapper);
            CreateCategoryModel model = new CreateCategoryModel() { CategoryName = "test5", CategoryStatus = true };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var category = context.Categories.SingleOrDefault(x => x.CategoryName == model.CategoryName);
            category.CategoryName.Should().NotBeNull();
            category.CategoryStatus.Should().BeTrue();

        }
    }
}
