using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thisGood10.Models.Repositories.Interfaces;

namespace thisGood10.Models.Repositories.EntityFrameworks
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private AppDbContext context;

        public EFCategoryRepository(AppDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Category> AllCategories()
        {
            return context.Categories;
        }

        public void SaveCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
