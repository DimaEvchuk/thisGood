using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thisGood10.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }

        public virtual ICollection<Sketch> _Sketches { get; set; } 
    }
}
