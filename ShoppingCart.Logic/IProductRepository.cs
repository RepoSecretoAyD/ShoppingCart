using System.Collections.Generic;

namespace ShoppingCart.Logic
{
    public interface IProductRepository
    {
        List<ProductItem> LoadProductItemsByOwner(string userName);
    }
}