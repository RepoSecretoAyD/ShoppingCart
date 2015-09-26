using System.Collections.Generic;
using ShoppingCart.Logic.Entities;

namespace ShoppingCart.Logic.Repositories
{
    public interface ICartRepository
    {
        List<StoredCartItem> LoadCartItemsByUser(string userName);
    }
}