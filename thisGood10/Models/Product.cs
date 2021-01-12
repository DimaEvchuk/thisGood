using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thisGood10.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public int CountProduct { get; set; }
        public double SalePrice { get; set; }
        public double BuyPrice { get; set; }
        public string Provider { get; set; }
        public int CategoryId { set; get; }

        public virtual Category category { get; set; }
        public virtual Person person { get; set; }


    }
}
