using AutoMapper;
using BlogApp.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.PostCommands.Queries.GetPostDetails
{
    public class GetPostDetailsQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public GetPostDetailsQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int PostId { get; set; }

        public PostDetailModel Handle()
        {
            var post = _context.Posts.SingleOrDefault(x => x.PostId == PostId && x.PostStatus == true);
            if (post is null)
            {
                throw new InvalidOperationException("Post bulunamadı veya aktif değil");
            }

            PostDetailModel vm = _mapper.Map<PostDetailModel>(post);

            return vm;
        }
    }

    public class PostDetailModel
    {
        public string PostTitle { get; set; }
        public string PostContext { get; set; }        
        public int CategoryId { get; set; }        
        public int UserId { get; set; }
        public bool PostStatus { get; set; }
    }
}
