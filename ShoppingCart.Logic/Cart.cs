using System.Collections.Generic;

namespace ShoppingCart.Logic
{
    public class Cart
    {
        private List<CartItem> _itemList=new List<CartItem>();
        private ICartRepository _cartRepository;
        private IProductRepository _productRepository;


        public Cart(ICartRepository cartRepository,IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public void SetItems(List<CartItem> itemList)
        {
            _itemList = itemList;
        }

        public void LoadCartByUser(string userName)
        {
           List<ProductItem> productItems=  _cartRepository.LoadCartItemsByUser(userName);
        }

        public double GetSubtotal()
        {
            LoadCartByUser("ccastro");
            double subtotal = 0;
            foreach (var cartItem in _itemList)
            {
                subtotal += cartItem.Price*cartItem.Quantity;
            }
            return subtotal;
        }
    }
}