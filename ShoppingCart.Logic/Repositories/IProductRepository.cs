using System.Collections.Generic;
using ShoppingCart.Logic.Entities;

namespace ShoppingCart.Logic.Repositories
{
    public interface IProductRepository
    {
        List<ProductItem> LoadProductItemsFromStoredCartItems(List<StoredCartItem> storedCartItems);
    }
}