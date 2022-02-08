using AutoMapper;
using BlogApp.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.UserCommands.Commands.UpdateUser
{
    public class UpdateUserCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public UpdateUserCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int UserId { get; set; }
        public UpdateUserModel Model { get; set; }

        public void Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.UserId == UserId);
            if (user is null)
            {
                throw new InvalidOperationException("Kullanıcı bulunamadı");
            }

            user.UserName = Model.UserName != default ? Model.UserName : user.UserName;
            user.UserSurname = Model.UserSurname != default ? Model.UserSurname : user.UserSurname;
            user.Email = Model.Email != default ? Model.Email : user.Email;
            user.Password = Model.Password != default ? Model.Password : user.Password;

            _context.SaveChanges();

        }
    }

    public class UpdateUserModel
    {
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
