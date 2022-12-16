using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GroupWebProject.Models;
using GroupWebProject.Models.Interfaces;

namespace GroupWebProject.Pages
{
    public class Index1Model : PageModel
    {
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
            Payment = new Payment()
            {
                FirstName = "John",
                LastName = "Cokos",
                BillingAddress = "123 Main St",
                BillingState = "WA",
                BillingCity = "Lynnwood",
                BillingZip = "98036",
                Amount = 10.35m,
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
