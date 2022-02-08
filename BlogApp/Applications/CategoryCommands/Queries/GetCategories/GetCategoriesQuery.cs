using AutoMapper;
using BlogApp.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Applications.CategoryCommands.Queries.GetCategories
{
    public class GetCategoriesQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetCategoriesModel> Handle()
        {
            var categoryList = _context.Categories.OrderBy(x => x.CategoryId).ToList();
            List<GetCategoriesModel> vm = _mapper.Map<List<GetCategoriesModel>>(categoryList);
            return vm;
        }
    }

    public class GetCategoriesModel
    {
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }
}
