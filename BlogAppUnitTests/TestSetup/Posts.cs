using BlogApp.DbOperations;
using BlogApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppUnitTests.TestSetup
{
    public static class Posts
    {
        public static void AddPosts(this ContextBlog context)
        {
            context.Posts.AddRange(
                new Post
                {
                    CategoryId = 1,
                    PostTitle = "deneme1 başlığı",
                    PostContext = "deneme1 yazısı",
                    UserId = 1,
                    PostStatus = true
                },
                new Post
                {
                    CategoryId = 2,
                    PostTitle = "deneme2 başlığı",
                    PostContext = "deneme2 yazısı",
                    UserId = 1,
                    PostStatus = true
                },
                new Post
                {
                    CategoryId = 1,
                    PostTitle = "deneme3 başlığı",
                    PostContext = "deneme3 yazısı",
                    UserId = 2,
                    PostStatus = true
                }
                );
        }
    }
}
