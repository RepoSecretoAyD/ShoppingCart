using System.Collections.Generic;
using ShoppingCart.Logic.Entities;

namespace ShoppingCart.Logic.Interfaces_and_Repositories
{
    public interface ICartRepository
    {
        List<StoredCartItem> LoadCartItemsByUser(string userName);
    }
}