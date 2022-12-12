using GroupWebProject.Areas.Identity.Data;
using GroupWebProject.Data;
using GroupWebProject.Models;
using GroupWebProject.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroupWebProject.Controllers
{
    public class CartController : Controller
    {
        private readonly GroupContext _context;

        public CartController(GroupContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel cartVM = new()
            {
                CartItems = cart,
                FullTotal = cart.Sum(x => x.Quantity * x.Price)
            };
            return View(cartVM);
        }
        //[Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> Add(int id)
        {
            Product product = await _context.Products.FindAsync(id); 
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartItem cartItem = cart.Where(c => c.ProductID == id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItem(product));
            }
            else
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);
            TempData["Success"] = "Product Get!";

            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> Decrease(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            CartItem cartItem = cart.Where(c => c.ProductID == id).FirstOrDefault();
            if(cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(x => x.ProductID == id);
            }
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            TempData["Success"] = "Product Removed!";
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Remove(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            cart.RemoveAll(p => p.ProductID == id);

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            TempData["Success"] = "Product Removed!";
            return RedirectToAction("Index");

        }
        public IActionResult Clear(int id)
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index");
        }

    }
}
