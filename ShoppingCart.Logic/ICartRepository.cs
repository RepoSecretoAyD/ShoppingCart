using System.Collections.Generic;

namespace ShoppingCart.Logic
{
    public interface ICartRepository
    {
        List<ProductItem> LoadCartItemsByUser(string userName);
    }
}