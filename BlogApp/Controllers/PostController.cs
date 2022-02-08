using AutoMapper;
using BlogApp.Applications.PostCommands.Commands.CreatePost;
using BlogApp.Applications.PostCommands.Commands.DeletePost;
using BlogApp.Applications.PostCommands.Commands.UpdatePost;
using BlogApp.Applications.PostCommands.Queries.GetPostDetails;
using BlogApp.Applications.PostCommands.Queries.GetPosts;
using BlogApp.Applications.PostCommands.Queries.GetPostsByWriter;
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
    public class PostController : Controller
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;        

        public PostController(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPosts()
        {
            GetPostsQuery query = new GetPostsQuery(_context, _mapper);

            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("id")]
        public IActionResult GetPostDetails(int id)
        {
            PostDetailModel result;

            GetPostDetailsQuery query = new GetPostDetailsQuery(_context, _mapper);
            query.PostId = id;

            GetPostDetailsQueryValidator validations = new GetPostDetailsQueryValidator();
            validations.ValidateAndThrow(query);

            result = query.Handle();

            return Ok(result);
        }

        [HttpGet("id")]
        public IActionResult GetPostsByUser(int id)
        {           

            GetPostsByUserQuery query = new GetPostsByUserQuery(_context, _mapper);
            query.UserId = id;

            GetPostsByUserQueryValidator validations = new GetPostsByUserQueryValidator();
            validations.ValidateAndThrow(query);

            var result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreatePost([FromBody] CreatePostModel model)
        {
            CreatePostCommand command = new CreatePostCommand(_context, _mapper);
            command.Model = model;

            CreatePostCommandValidator validations = new CreatePostCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdatePost([FromBody] UpdatePostModel model, int id)
        {
            UpdatePostCommand command = new UpdatePostCommand(_context, _mapper);
            command.Model = model;
            command.PostId = id;

            UpdatePostCommandValidator validations = new UpdatePostCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeletePost(int id)
        {
            DeletePostCommand command = new DeletePostCommand(_context, _mapper);
            command.PostId = id;

            DeletePostCommandValidator validations = new DeletePostCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}
