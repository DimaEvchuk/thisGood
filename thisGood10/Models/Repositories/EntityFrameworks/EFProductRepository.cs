using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thisGood10.Models.Repositories.Interfaces;


namespace thisGood10.Models.Repositories.EntityFrameworks
{
    public class EFProductRepository : IProductRepository
    {
        private AppDbContext context;

        public EFProductRepository(AppDbContext ctx)
        {
            context = ctx;
        }
        public Task DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await context.Products.ToListAsync();
        }

        public Task<Product> GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task SaveProduct(Product product)
        {
          if (product.Id == default)
                context.Entry(product).State = EntityState.Added;
            else
                context.Entry(product).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

       
    }
}
