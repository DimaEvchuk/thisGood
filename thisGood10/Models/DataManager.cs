using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thisGood10.Models.Repositories.Interfaces;

namespace thisGood10.Models
{
    public class DataManager
    {
        public IProductRepository productRepository;
        public IPersonRepository personRepository;
        public ICategoryRepository categoryRepository;
        public ISketchRepository sketchRepository;



        public DataManager(
              IProductRepository _productRepository,
              IPersonRepository _personRepository,
              ICategoryRepository _categoryRepository,
              ISketchRepository _sketchRepository)
        {
            productRepository = _productRepository;
            personRepository = _personRepository;
            categoryRepository = _categoryRepository;
            sketchRepository = _sketchRepository;
          
        }
    }
}
