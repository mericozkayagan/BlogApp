using AutoMapper;
using BlogApp.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.CategoryCommands.Commands.DeleteCategory
{
    public class DeleteCategoryCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;        
        public int CategoryId { get; set; }

        public DeleteCategoryCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var category = _context.Categories.SingleOrDefault(x => x.CategoryId == CategoryId);
            if (category is null)
            {
                throw new InvalidOperationException("Kategori bulunamadı");
            }

            category.CategoryStatus = false;

            _context.SaveChanges();
            
        }
    }

    
}
