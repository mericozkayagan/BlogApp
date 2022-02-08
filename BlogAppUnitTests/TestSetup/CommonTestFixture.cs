using AutoMapper;
using BlogApp.Common;
using BlogApp.DbOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppUnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public ContextBlog context { get; set; }
        public IMapper mapper { get; set; }
        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<ContextBlog>().UseInMemoryDatabase(databaseName: "BlogAppTestDb").Options;
            context = new ContextBlog(options);

            context.Database.EnsureCreated();
            context.AddUsers();
            context.AddPosts();
            context.AddCategories();
            context.SaveChanges();

            mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }
    }
}
