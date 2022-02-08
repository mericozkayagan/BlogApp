using AutoMapper;
using BlogApp.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.PostCommands.Commands.UpdatePost
{
    public class UpdatePostCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public int PostId { get; set; }
        public UpdatePostModel Model { get; set; }

        public UpdatePostCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var post = _context.Posts.SingleOrDefault(x => x.PostId == PostId);
            if (post is null)
            {
                throw new InvalidOperationException("Post bulunamadı");
            }

            post.PostTitle = Model.PostTitle != default ? Model.PostTitle : post.PostTitle;
            post.PostContext = Model.PostContext != default ? Model.PostContext : post.PostContext;
            post.CategoryId = Model.CategoryId != default ? Model.CategoryId : post.CategoryId;
            post.UserId = Model.UserId != default ? Model.UserId : post.UserId;

            _context.SaveChanges();
        }
    }
    public class UpdatePostModel
    {
        public string PostTitle { get; set; }
        public string PostContext { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
