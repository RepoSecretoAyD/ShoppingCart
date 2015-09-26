using System.Collections.Generic;
using ShoppingCart.Logic.Entities;

namespace ShoppingCart.Logic.Interfaces_and_Repositories
{
    public interface IProductRepository
    {
        List<ProductItem> LoadProductItemsFromStoredCartItems(List<StoredCartItem> storedCartItems);
    }
}