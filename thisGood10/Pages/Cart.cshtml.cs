using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using thisGood10.TagHelpers;
using thisGood10.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace thisGood10.Pages
{
 public class CartModel : PageModel
    {
        private DataManager dataManager;
        public CartModel(DataManager data)
        {
            dataManager = data;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public async Task<IActionResult> OnPost(long Id, string returnUrl)
        {
            IEnumerable<Sketch> sketches = await dataManager.sketchRepository.AllSketches();

            Sketch sketch = sketches.FirstOrDefault(p => p.Id == Id);
            // ?? значит если не выполняется перевое условие тогда выполняется второе
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.AddItem(sketch, 1);
            HttpContext.Session.SetJson("cart", Cart);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}