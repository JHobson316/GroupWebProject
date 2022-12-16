using GroupWebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupWebProject.Models.Interfaces
{
    public interface IPayment
    {
        PaymentResponse ProcessPayment(Payment payment);
    }
}
