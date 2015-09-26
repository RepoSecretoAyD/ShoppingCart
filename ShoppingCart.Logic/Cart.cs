using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Logic.Entities;
using ShoppingCart.Logic.Exceptions;
using ShoppingCart.Logic.Interfaces_and_Repositories;

namespace ShoppingCart.Logic
{
    public class Cart
    {
        private List<ProductItem> _itemList = new List<ProductItem>();
        private List<StoredCartItem> _storedCartItems = new List<StoredCartItem>();
        private List<DiscountItem> _discountItems = new List<DiscountItem>(); 
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IDate _date;
        public List<CartItem> CartItems = new List<CartItem>();
        public string Owner;


        public Cart(ICartRepository cartRepository,IProductRepository productRepository, IDiscountRepository discountRepository, IDate date)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _discountRepository = discountRepository;
            _date = date;
        }

        public void SetCartItems(List<CartItem> cartItems)
        {
            CartItems = cartItems;
        }

        public void LoadCartByUser(string userName)
        {
            Owner = userName;
            _storedCartItems = _cartRepository.LoadCartItemsByUser(userName);
            _itemList = _productRepository.LoadProductItemsFromStoredCartItems(_storedCartItems);
            _discountItems = _discountRepository.GetDisocDiscountsForProductList(_itemList) ?? new List<DiscountItem>();
            CartItems = new List<CartItem>();
            foreach (var storedCartItem in _storedCartItems)
            {
                var productItem = _itemList.FirstOrDefault(x => x.ProductId == storedCartItem.ProductId);
                if (productItem != null)
                {
                    CartItems.Add(new CartItem
                    {
                        Id = storedCartItem.Id,
                        Price = productItem.Price,
                        ProductId = storedCartItem.ProductId,
                        ProductName = productItem.ProductName,
                        Quantity = storedCartItem.Quantity
                    });
                }
            }
        }

        public double GetSubtotal()
        {
            double subtotal = 0;
            foreach (var cartItem in CartItems)
            {
                var productItem = _itemList.FirstOrDefault(x => x.ProductId == cartItem.ProductId);
                var discountItem = _discountItems.FirstOrDefault(x => x.ProductId == cartItem.ProductId);
                if(productItem != null && cartItem.Quantity > productItem.Quantity)
                    throw new InsufficientQuantityException(cartItem.ProductName);
                if (productItem != null && productItem.ExpirationDate < _date.Now)
                    throw new ItemExpiredException(cartItem.ProductName);
                subtotal += (discountItem != null ? 
                    cartItem.Quantity * cartItem.Price - (discountItem.Discount*cartItem.Quantity * cartItem.Price) : 
                    cartItem.Quantity * cartItem.Price);
            }
            return subtotal;
        }
    }
}