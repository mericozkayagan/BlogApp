using AutoMapper;
using BlogApp.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.CategoryCommands.Queries.GetCategoryDetails
{
    public class GetCategoryDetailsQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public GetCategoryDetailsQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int CategoryId { get; set; }

        public CategoryDetailModel Handle()
        {
            var category = _context.Categories.SingleOrDefault(x => x.CategoryId == CategoryId && x.CategoryStatus == true);
            if (category is null)
            {
                throw new InvalidOperationException("Kategori bulunamadı veya durumu aktif değil");
            }

            CategoryDetailModel vm = _mapper.Map<CategoryDetailModel>(category);

            return vm;
        }
        
    }
    public class CategoryDetailModel
    {
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }
}
