using AutoMapper;
using BlogApp.Applications.CategoryCommands.Commands.CreateCategory;
using BlogApp.Applications.CategoryCommands.Queries.GetCategories;
using BlogApp.Applications.CategoryCommands.Queries.GetCategoryDetails;
using BlogApp.Applications.PostCommands.Commands.CreatePost;
using BlogApp.Applications.PostCommands.Queries.GetPostDetails;
using BlogApp.Applications.PostCommands.Queries.GetPosts;
using BlogApp.Applications.PostCommands.Queries.GetPostsByWriter;
using BlogApp.Applications.UserCommands.Commands.CreateUser;
using BlogApp.Applications.UserCommands.Queries.GetUserDetails;
using BlogApp.Applications.UserCommands.Queries.GetUsers;
using BlogApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCategoryModel, Category>();
            CreateMap<CreatePostModel, Post>();
            CreateMap<CreateUserModel, User>();
            ///
            CreateMap<Category, CategoryDetailModel>();
            CreateMap<Post, PostDetailModel>();
            CreateMap<User, UserDetailModel>();
            ///
            CreateMap<Category, GetCategoriesModel>();
            CreateMap<Post, GetPostsModel>();
            CreateMap<User, GetUsersModel>();
            ///
            CreateMap<Post, GetPostsByUserModel>();
        }
    }
}
