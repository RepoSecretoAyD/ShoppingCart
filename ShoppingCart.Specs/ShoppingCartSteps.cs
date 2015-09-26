using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingCart.Logic;
using ShoppingCart.Logic.Entities;
using ShoppingCart.Logic.Repositories;
using TechTalk.SpecFlow;

namespace ShoppingCart.Specs
{
    [Binding]
    public class ShoppingCartSteps
    {
        private readonly Mock<ICartRepository> _cartRepositoryMock=new Mock<ICartRepository>();
        private readonly Mock<IProductRepository> _productRepositoryMock = new Mock<IProductRepository>();
        private readonly Mock<IDiscountRepository> _discountRepositoryMock = new Mock<IDiscountRepository>();
        private readonly Cart _cart ;
        private double _subtotal;

        public ShoppingCartSteps()
        {
            _cart = new Cart(_cartRepositoryMock.Object,_productRepositoryMock.Object, _discountRepositoryMock.Object);
        }

        [Given(@"the cart has the following items")]
        public void GivenTheCartHasTheFollowingItems(Table table)
        {
            var itemList=new List<CartItem>();
    
            foreach (var row in table.Rows)
            {
                var item = new CartItem
                {
                    ProductId = int.Parse(row["ProductId"]),
                    ProductName = row["ProductName"],
                    Price = double.Parse(row["Price"]),
                    Quantity = int.Parse(row["Quantity"])
                };
                itemList.Add(item);
            }
            _cart.SetCartItems(itemList);
        }

        [Given(@"the cart stored for user is")]
        public void GivenTheCartStoredForUserIs(Table table)
        {
            var itemList = new List<StoredCartItem>();
            foreach (var row in table.Rows)
            {
                var item = new StoredCartItem
                {
                    ProductId = int.Parse(row["ProductId"]),
                    Quantity = int.Parse(row["Quantity"]),
                    Owner = row["Owner"]
                };
                itemList.Add(item);
            }
            _cartRepositoryMock.Setup(cr => cr.LoadCartItemsByUser("ccastro")).Returns(itemList);
        }

        [Given(@"the products table is the following")]
        public void GivenTheProductsTableIsTheFollowing(Table table)
        {
            var itemList = new List<ProductItem>();
            foreach (var row in table.Rows)
            {
                var item = new ProductItem
                {
                    ProductId = int.Parse(row["ProductId"]),
                    ProductName = row["ProductName"],
                    Price = double.Parse(row["Price"]),
                    Quantity = int.Parse(row["Quantity"])
                };
                itemList.Add(item);
            }
            _productRepositoryMock.Setup(pr => pr.LoadProductItemsFromStoredCartItems(It.IsAny<List<StoredCartItem>>()))
                .Returns(itemList);
        }

        [Given(@"the user logged is '(.*)'")]
        public void GivenTheUserLoggedIs(string p0)
        {
            _cart.LoadCartByUser(p0);
        }
        /////////////////////
        [When(@"the subtotal is calculated")]
        public void WhenTheSubtotalIsCalculated()
        {
            _subtotal = _cart.GetSubtotal();
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(double p0)
        {
            Assert.AreEqual(p0, _subtotal);
        }

        [Then(@"the user is presented with an error message")]
        public void ThenTheUserIsPresentedWithAnErrorMessage()
        {
            throw new Exception("Quantity exceeds the ammount of products in existance!");
        }
    }
}
