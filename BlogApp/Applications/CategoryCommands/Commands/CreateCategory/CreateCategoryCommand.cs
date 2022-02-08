using AutoMapper;
using BlogApp.DbOperations;
using BlogApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.CategoryCommands.Commands.CreateCategory
{
    public class CreateCategoryCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public CreateCategoryModel Model { get; set; }

        public CreateCategoryCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var category = _context.Categories.SingleOrDefault(x => x.CategoryName == Model.CategoryName);
            if (category is not null)
            {
                throw new InvalidOperationException("Kategori zaten mevcut");
            }
            category = _mapper.Map<Category>(Model);
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
    public class CreateCategoryModel
    {
        public string CategoryName { get; set; }
        public bool? CategoryStatus { get; set; } = true;
    }
}
