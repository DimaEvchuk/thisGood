using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thisGood10.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public void AddItem(Sketch sketch, int quantity)
        {
            CartLine line = Lines
            .Where(p => p.Sketch.Id == sketch.Id)
            .FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Sketch = sketch,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Sketch sketch) =>
                    Lines.RemoveAll(l => l.Sketch.Id == sketch.Id); 
        public void Clear() => Lines.Clear();
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Sketch Sketch { get; set; }
        public int Quantity { get; set; }
    }
}
/*
*/