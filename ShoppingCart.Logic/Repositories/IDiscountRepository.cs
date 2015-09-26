using System.Collections.Generic;
using ShoppingCart.Logic.Entities;

namespace ShoppingCart.Logic.Repositories
{
    public interface IDiscountRepository
    {
        List<DiscountItem> GetDisocDiscountsForProductList(List<ProductItem> productItems);
    }
}