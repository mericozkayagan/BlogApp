using AutoMapper;
using BlogApp.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.UserCommands.Commands.DeleteUser
{
    public class DeleteUserCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public DeleteUserCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int UserId { get; set; }
       

        public void Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.UserId == UserId);
            if (user is null)
            {
                throw new InvalidOperationException("Kullanıcı bulunamadı");
            }
            user.UserStatus = false;
            _context.SaveChanges();
        }
    }   
}
