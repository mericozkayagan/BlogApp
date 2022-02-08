using AutoMapper;
using BlogApp.DbOperations;
using BlogApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.UserCommands.Commands.CreateUser
{
    public class CreateUserCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public CreateUserCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CreateUserModel Model { get; set; }

        public void Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == Model.Email);
            if (user is not null)
            {
                throw new InvalidOperationException("Bu e-posta daha önce kullanılmış");
            }
            user = _mapper.Map<User>(Model);
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }

    public class CreateUserModel
    {
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? UserStatus { get; set; } = true;
    }
}
