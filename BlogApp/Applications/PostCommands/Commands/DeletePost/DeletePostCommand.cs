using AutoMapper;
using BlogApp.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.PostCommands.Commands.DeletePost
{
    public class DeletePostCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public DeletePostCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int PostId { get; set; }        

        public void Handle()
        {
            var post = _context.Posts.SingleOrDefault(x => x.PostId == PostId);
            if (post is null)
            {
                throw new InvalidOperationException("Post bulunamadı");
            }
            post.PostStatus = false;
            _context.SaveChanges();
        }
    }

   
}
