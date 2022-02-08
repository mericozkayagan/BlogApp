using BlogApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.DbOperations
{
    public interface IContext
    {
       DbSet<Category> Categories { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<User> Users { get; set; }

        int SaveChanges();
        
    }
}
