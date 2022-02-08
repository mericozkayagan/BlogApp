using BlogApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.DbOperations
{
    public class ContextBlog:DbContext,IContext
    {
        public ContextBlog(DbContextOptions<ContextBlog> options) : base(options)
        { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }        
        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
