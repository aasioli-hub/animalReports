using Microsoft.EntityFrameworkCore;
using Prototipo.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DatabaseContext _context;



        public CategoryService(DatabaseContext context)
        {
            _context = context;
        }

        public string GetName()
        {
            var a = _context.Categories.Single(x => x.Id == 1);

            return a.Name;
        }
    }
}
