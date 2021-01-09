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
        public Task DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public Task SaveProduct(Product product)
        {
            throw new NotImplementedException();
        }

       
    }
}
