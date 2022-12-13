namespace GroupWebProject.Models.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal FullTotal { get; set; }
    }
}
