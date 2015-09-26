namespace ShoppingCart.Logic.Entities
{
    public class StoredCartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Owner { get; set; }
    }
}