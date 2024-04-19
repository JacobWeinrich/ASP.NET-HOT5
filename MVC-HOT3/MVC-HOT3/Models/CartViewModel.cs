namespace MVC_HOT3.Models
{
    public class CartViewModel
    {
        public List<ShoppingCartItem> CartItems { get; set; }
        public decimal? CartTotal { get; set; }
        public int? TotalQuantity { get; set; }

    }
}
