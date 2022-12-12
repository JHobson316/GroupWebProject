using GroupWebProject.Models.Viewmodels;
using GroupWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;

namespace GroupWebProject.Areas.Identity.Data.Components
{
    public class SmallCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") != null ? HttpContext.Session.GetJson<List<CartItem>>("Cart") : new List<CartItem>();
            SmallCartViewModel smallCartVM;

            if(cart != null || cart.Count == 0) 
            {
                smallCartVM = null;
            }
            else
            {
                smallCartVM = new()
                {
                    NumberOfitems = cart.Sum(x => x.Quantity),
                    TotalAmount = cart.Sum(x => x.Quantity*x.Price)
                };
            }
            return View(smallCartVM);
        }
    }
}
