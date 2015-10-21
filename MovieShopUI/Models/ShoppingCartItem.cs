namespace MovieStoreUI.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}