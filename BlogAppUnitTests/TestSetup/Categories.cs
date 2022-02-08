using BlogApp.DbOperations;
using BlogApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppUnitTests.TestSetup
{
    public static class Categories
    {
        public static void AddCategories(this ContextBlog context)
        {
            context.Categories.AddRange(
                new Category
                {
                    CategoryName = "Yazılım",
                    CategoryStatus = true
                },
                new Category
                {
                    CategoryName = "Spor",
                    CategoryStatus = true
                }, new Category
                {
                    CategoryName = "Sanat",
                    CategoryStatus = true
                }
                );
        }
    }
}
