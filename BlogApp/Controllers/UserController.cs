using AutoMapper;
using BlogApp.Applications.UserCommands.Commands.CreateUser;
using BlogApp.Applications.UserCommands.Commands.DeleteUser;
using BlogApp.Applications.UserCommands.Commands.UpdateUser;
using BlogApp.Applications.UserCommands.Queries.GetUserDetails;
using BlogApp.Applications.UserCommands.Queries.GetUsers;
using BlogApp.DbOperations;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class UserController : Controller
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public UserController(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            GetUsersQuery query = new(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("id")]
        public IActionResult GetUserDetails(int id)
        {
            UserDetailModel result;

            GetUserDetailsQuery query = new GetUserDetailsQuery(_context, _mapper);
            query.UserId = id;
            GetUserDetailsQueryValidator validations = new GetUserDetailsQueryValidator();
            validations.ValidateAndThrow(query);
            result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserModel model)
        {
            CreateUserCommand command = new CreateUserCommand(_context, _mapper);
            command.Model = model;

            CreateUserCommandValidator validations = new CreateUserCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateUser([FromBody] UpdateUserModel model, int id)
        {
            UpdateUserCommand command = new UpdateUserCommand(_context, _mapper);
            command.Model = model;
            command.UserId = id;

            UpdateUserCommandValidator validations = new UpdateUserCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteUser(int id)
        {
            DeleteUserCommand command = new DeleteUserCommand(_context,_mapper);
            command.UserId = id;

            DeleteUserCommandValidator validations = new DeleteUserCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

    }
}
