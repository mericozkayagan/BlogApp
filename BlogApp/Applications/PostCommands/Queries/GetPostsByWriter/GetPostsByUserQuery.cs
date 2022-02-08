using AutoMapper;
using BlogApp.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.PostCommands.Queries.GetPostsByWriter
{
    public class GetPostsByUserQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public int UserId { get; set; }
        public GetPostsByUserQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetPostsByUserModel> Handle()
        {
            var postList = _context.Posts.GroupBy(x => x.UserId == UserId).ToList();
            if (postList is null)
            {
                throw new InvalidOperationException("Kullanıcıya ait post bulunamadı");
            }
            List<GetPostsByUserModel> vm = _mapper.Map<List<GetPostsByUserModel>>(postList);

            return vm;

        }
    }

    public class GetPostsByUserModel
    {
        public string PostTitle { get; set; }
        public string PostContext { get; set; }
        public int CategoryId { get; set; }       
        public int UserId { get; set; }
    }
}
