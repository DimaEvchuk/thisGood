using Microsoft.EntityFrameworkCore;
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

       
        //
        public async Task<IEnumerable<Category>> AllCategories()
        {
            return await context.Categories.ToListAsync();           
        }

        public Task SaveCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
