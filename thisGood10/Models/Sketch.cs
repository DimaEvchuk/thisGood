using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thisGood10.Models
{
    public class Sketch
    {
        //знак int? значит что значение может быть null
        public int Id { get; set; }
        public string sketchPrint { set; get; }
        public string sketchPrintName { set; get; }
        public int categoryId { get; set; }

        public virtual Category category { get; set; }

    }
}
