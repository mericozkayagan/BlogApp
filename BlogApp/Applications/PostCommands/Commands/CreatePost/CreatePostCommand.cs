using AutoMapper;
using BlogApp.DbOperations;
using BlogApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.PostCommands.Commands.CreatePost
{
    public class CreatePostCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public CreatePostModel Model { get; set; }

        public CreatePostCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var post = _context.Posts.SingleOrDefault(x => x.PostTitle == Model.PostTitle);
            if (post is not null)
            {
                throw new InvalidOperationException("Post zaten mevcut");
            }
            post = _mapper.Map<Post>(Model);
            _context.Posts.Add(post);
            _context.SaveChanges();
        }
        
    }
    public class CreatePostModel
    {
        public string PostTitle { get; set; }
        public string PostContext { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public bool? PostStatus { get; set; } = true;

    }
}
