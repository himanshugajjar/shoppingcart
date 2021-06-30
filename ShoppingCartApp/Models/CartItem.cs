namespace ShoppingCartApp.Models
{
    public class CartItem : Item
    {
        public CartItem()
        {
            Total = 0;
        }

        public int Quantity { get; set; }

        public double Total { get; set; }
    }
}
