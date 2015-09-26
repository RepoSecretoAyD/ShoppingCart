using System;

namespace ShoppingCart.Logic.Entities
{
    public class ProductItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}