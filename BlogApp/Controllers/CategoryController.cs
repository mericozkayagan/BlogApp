using AutoMapper;
using BlogApp.Applications.CategoryCommands.Commands.CreateCategory;
using BlogApp.Applications.CategoryCommands.Commands.DeleteCategory;
using BlogApp.Applications.CategoryCommands.Commands.UpdateCategory;
using BlogApp.Applications.CategoryCommands.Queries.GetCategories;
using BlogApp.Applications.CategoryCommands.Queries.GetCategoryDetails;
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
    public class CategoryController : Controller
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;        

        public CategoryController(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            GetCategoriesQuery query = new GetCategoriesQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("id")]
        public IActionResult GetCategoryDetail(int id)
        {
            CategoryDetailModel result;

            GetCategoryDetailsQuery query = new GetCategoryDetailsQuery(_context, _mapper);
            query.CategoryId = id;

            GetCategoryDetailsQueryValidator validations = new GetCategoryDetailsQueryValidator();

            validations.ValidateAndThrow(query);

            result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateCategoryModel model)
        {
            CreateCategoryCommand command = new CreateCategoryCommand(_context, _mapper);
            command.Model = model;

            CreateCategoryCommandValidator validations = new CreateCategoryCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCategory([FromBody] UpdateCategoryModel model, int id)
        {
            UpdateCategoryCommand command = new UpdateCategoryCommand(_context, _mapper);
            command.Model = model;
            command.CategoryId = id;

            UpdateCategoryCommandValidator validations = new UpdateCategoryCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteCategory(int id)
        {
            DeleteCategoryCommand command = new DeleteCategoryCommand(_context, _mapper);
            command.CategoryId = id;

            DeleteCategoryCommandValidator validations = new DeleteCategoryCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

    }
}
