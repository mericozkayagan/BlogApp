using BlogApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DbOperations.ContextBlog(serviceProvider.GetRequiredService<DbContextOptions<ContextBlog>>()))
            {
                if (context.Posts.Any())
                {
                    return;
                }
                context.Posts.AddRange(
                    new Post
                    {
                        CategoryId = 1,
                        PostContext = "Bu bir deneme yazısıdır.",
                        PostTitle = "Deneme Başlığı",
                        UserId = 1

                    }, new Post
                    {
                        CategoryId = 2,
                        PostContext = "Bu bir test2 yazısıdır.",
                        PostTitle = "Test2 Başlığı",
                        UserId = 2

                    });
                context.Categories.AddRange(
                    new Category
                    {
                        CategoryName = "Teknoloji",
                        CategoryStatus=true,
                    },
                    new Category
                    {
                        CategoryName = "Spor",
                        CategoryStatus = true,
                    },
                    new Category
                    {
                        CategoryName = "Sanat",
                        CategoryStatus = true,
                    }
                    );
                context.Users.AddRange(
                    new User
                    {
                        UserName = "meriç",
                        UserSurname = "özkayagan",
                        Email = "meriç123@gmail.com",
                        Password = "123"
                    },
                    new User
                    {
                        UserName = "derin",
                        UserSurname = "özkaya",
                        Email = "derin@gmail.com",
                        Password = "1234"
                    }
                    );
            }
        }
    }
}
