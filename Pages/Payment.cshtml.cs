using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GroupWebProject.Models;
using GroupWebProject.Models.Interfaces;
using GroupWebProject.Models.ViewModels;
using GroupWebProject.Areas.Identity.Data;

namespace GroupWebProject.Pages
{
    public class Index1Model : PageModel
    {
        public readonly CartViewModel _cartViewModel;


        [BindProperty]
        public Payment Payment { get; set; }
        [BindProperty]
        public PaymentResponse PaymentResponse { get; set; }

        public IPayment PaymentService { get; }
        public Index1Model(IPayment service)
        {
            PaymentService = service;
        }
        
        public void OnGet()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel cartVM = new()
            {
                CartItems = cart,
                FullTotal = cart.Sum(x => x.Quantity * x.Price)
            };

            Payment = new Payment()
            {
                FirstName = "John",
                LastName = "Cokos",
                BillingAddress = "123 Main St",
                BillingState = "WA",
                BillingCity = "Lynnwood",
                BillingZip = "98034",
                Amount = cartVM.FullTotal,
                CardNumber = "4111111111111111",
                Expiration = "1022",
                Cvv = "555",
            };
        }

        public void OnPost()
        {
            PaymentResponse = PaymentService.ProcessPayment(Payment);
        }
    }
}
