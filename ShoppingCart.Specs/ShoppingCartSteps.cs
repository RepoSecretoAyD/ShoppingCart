using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingCart.Logic;
using ShoppingCart.Logic.Entities;
using ShoppingCart.Logic.Interfaces_and_Repositories;
using ShoppingCart.Logic.Exceptions;
using TechTalk.SpecFlow;

namespace ShoppingCart.Specs
{
    [Binding]
    public class ShoppingCartSteps
    {
        private readonly Mock<ICartRepository> _cartRepositoryMock=new Mock<ICartRepository>();
        private readonly Mock<IProductRepository> _productRepositoryMock = new Mock<IProductRepository>();
        private readonly Mock<IDiscountRepository> _discountRepositoryMock = new Mock<IDiscountRepository>();
        private readonly Mock<IDate> _dateMock = new Mock<IDate>();
        private readonly Cart _cart ;
        private double _subtotal;

        public ShoppingCartSteps()
        {
            _cart = new Cart(_cartRepositoryMock.Object,_productRepositoryMock.Object, _discountRepositoryMock.Object, _dateMock.Object);
            _dateMock.Setup(dm => dm.Now).Returns(new DateTime(2015, 1, 1));
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
                    Quantity = int.Parse(row["Quantity"]),
                    ExpirationDate = DateTime.Now
                };
                itemList.Add(item);
            }
            _productRepositoryMock.Setup(pr => pr.LoadProductItemsFromStoredCartItems(It.IsAny<List<StoredCartItem>>()))
                .Returns(itemList);
        }

        [Given(@"the products table with Date is the following")]
        public void GivenTheProductsTableWithDateIsTheFollowing(Table table)
        {
            var itemList = new List<ProductItem>();
            foreach (var row in table.Rows)
            {
                var item = new ProductItem
                {
                    ProductId = int.Parse(row["ProductId"]),
                    ProductName = row["ProductName"],
                    Price = double.Parse(row["Price"]),
                    Quantity = int.Parse(row["Quantity"]),
                    ExpirationDate = new DateTime(1970,1,1).AddMilliseconds(long.Parse(row["Date"]))
                };
                itemList.Add(item);
            }
            _productRepositoryMock.Setup(pr => pr.LoadProductItemsFromStoredCartItems(It.IsAny<List<StoredCartItem>>()))
                .Returns(itemList);
        }

        [Given(@"the discounts table is the following")]
        public void GivenTheDiscountsTableIsTheFollowing(Table table)
        {
            var discountList = new List<DiscountItem>();
            foreach (var tableRow in table.Rows)
            {
                var item = new DiscountItem
                {
                    ProductId = int.Parse(tableRow["ProductId"]),
                    Discount = double.Parse(tableRow["Discount"])
                };
                discountList.Add(item);
            }
            _discountRepositoryMock.Setup(pr => pr.GetDisocDiscountsForProductList(It.IsAny<List<ProductItem>>()))
                .Returns(discountList);
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
            try
            {
                _subtotal = _cart.GetSubtotal();
            }
            catch (ItemExpiredException e)
            {
                ScenarioContext.Current.Add("ItemExpired", e);
            }
            catch (InsufficientQuantityException e)
            {
                ScenarioContext.Current.Add("InsufficientQuantity", e);
            }
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(double p0)
        {
            Assert.AreEqual(p0, _subtotal);
        }

        [Then(@"the user is presented with an error message about quantity")]
        public void ThenTheUserIsPresentedWithAnErrorMessageAboutQuantity()
        {
            var exception = ScenarioContext.Current["InsufficientQuantity"];
            Assert.IsNotNull(exception);
        }

        [Then(@"the user is presented with an error message about expiration")]
        public void ThenTheUserIsPresentedWithAnErrorMessageAboutExpiration()
        {
            var exception = ScenarioContext.Current["ItemExpired"];
            Assert.IsNotNull(exception);
        }
    }
}
