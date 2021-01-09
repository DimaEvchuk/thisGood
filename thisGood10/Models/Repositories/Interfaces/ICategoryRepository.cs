using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thisGood10.Models.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
       
        Task<IEnumerable<Category>> AllCategories();
        Task SaveCategory(Category category);
    }
}
