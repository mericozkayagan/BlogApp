using AutoMapper;
using BlogApp.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.UserCommands.Queries.GetUsers
{
    public class GetUsersQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public GetUsersQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetUsersModel> Handle()
        {
            var userList = _context.Users.OrderBy(x => x.UserId).ToList();

            List<GetUsersModel> vm = _mapper.Map<List<GetUsersModel>>(userList);
            return vm;
        }
    }

    public class GetUsersModel
    {
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
