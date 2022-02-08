using AutoMapper;
using BlogApp.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.PostCommands.Queries.GetPosts
{
    public class GetPostsQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public GetPostsQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetPostsModel> Handle()
        {
            var postList = _context.Posts.OrderBy(x => x.PostId).ToList();

            List<GetPostsModel> vm = _mapper.Map<List<GetPostsModel>>(postList);

            return vm;

        }
    }

    public class GetPostsModel
    {
        public string PostTitle { get; set; }
        public string PostContext { get; set; }        
        public int CategoryId { get; set; }       
        public int UserId { get; set; }
        public bool PostStatus { get; set; }
    }
}
