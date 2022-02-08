using AutoMapper;
using BlogApp.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.UserCommands.Queries.GetUserDetails
{
    public class GetUserDetailsQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public GetUserDetailsQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int UserId { get; set; }

        public UserDetailModel Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.UserId == UserId && x.UserStatus == true);
            if (user is null)
            {
                throw new InvalidOperationException("Kullanıcı bulunamadı");
            }

            UserDetailModel vm = _mapper.Map<UserDetailModel>(user);

            return vm;
        }
    }
    public class UserDetailModel
    {
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
