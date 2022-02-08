using BlogApp.DbOperations;
using BlogApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppUnitTests.TestSetup
{
    public static class Users
    {
        public static void AddUsers(this ContextBlog context)
        {
            context.Users.AddRange(
                new User
                {
                    UserName = "denemead1",
                    UserSurname = "denemesoyad1",
                    Email = "deneme1@gmail.com",
                    Password = "123",
                    UserStatus = true
                },
                new User
                {
                    UserName = "denemead2",
                    UserSurname = "deneme2",
                    Email = "deneme2@gmail.com",
                    Password = "1234",
                    UserStatus = true
                },
                new User
                {
                    UserName = "denemead3",
                    UserSurname = "denemesoyad3",
                    Email = "deneme3@gmail.com",
                    Password = "12345",
                    UserStatus = true
                }
                );
        }
    }
}
