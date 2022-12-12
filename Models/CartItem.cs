namespace GroupWebProject.Models;

public class CartItem
{
    public long ProductID { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public Decimal Price { get; set; }
    public decimal Total { get { return Quantity * Price; } }
    public string image { get; set; }
    public CartItem()
    {

    }
    public CartItem(Product product)
    {
        ProductID = product.ID;
        ProductName = product.Name;
        Price = product.Price;
        Quantity = 1;
        image = product.image;
    }
}
