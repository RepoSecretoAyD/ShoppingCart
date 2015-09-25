using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingCart.Logic;
using TechTalk.SpecFlow;

namespace ShoppingCart.Specs
{
    [Binding]
    public class ShoppingCartSteps
    {
        private Mock<ICartRepository> _cartRepositoryMock=new Mock<ICartRepository>();
        private Mock<IProductRepository> _productRepositoryMock = new Mock<IProductRepository>();
        private Cart _cart ;
        private double _subtotal;

        public ShoppingCartSteps()
        {
            _cart = new Cart(_cartRepositoryMock.Object,_productRepositoryMock.Object);
        }

        [Given(@"the cart has the following items")]
        public void GivenTheCartHasTheFollowingItems(Table table)
        {
            List<CartItem> itemList=new List<CartItem>();
    
            foreach (var row in table.Rows)
            {
                var item = new CartItem();
                item.ProductId = int.Parse(row["ProductId"]);
                item.ProductName = row["ProductName"];
                item.Price = double.Parse(row["Price"]);
                item.Quantity = int.Parse(row["Quantity"]);
                itemList.Add(item);
            }
            _cart.SetItems(itemList);
        }
        
        [When(@"the subtotal is calculated")]
        public void WhenTheSubtotalIsCalculated()
        {
           _subtotal =  _cart.GetSubtotal();
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(double p0)
        {
            Assert.AreEqual(p0,_subtotal);
        }

        [Given(@"the cart stored for user is")]
        public void GivenTheCartStoredForUserIs(Table table)
        {
            _cartRepositoryMock.Setup(cr => cr.LoadCartItemsByUser("ccastro")).Throws(new Exception("Wong user"));

            var itemList = new List<ProductItem>();
            foreach (var row in table.Rows)
            {
                var item = new ProductItem();
                item.ProductId = int.Parse(row["ProductId"]);
                item.Quantity = int.Parse(row["Quantity"]);
                item.Owner = row["Owner"];
                itemList.Add(item);
            }
            _cart.SetProductItems(itemList);
        }

        [Given(@"the user logged is '(.*)'")]
        public void GivenTheUserLoggedIs(string p0)
        {
        }

        [Given(@"the products table is the following")]
        public void GivenTheProductsTableIsTheFollowing(Table table)
        {
            var itemList = new List<CartItem>();
            foreach (var row in table.Rows)
            {
                var item = new CartItem();
                item.ProductId = int.Parse(row["ProductId"]);
                item.ProductName = row["ProductName"];
                item.Price = double.Parse(row["Price"]);
                if (!string.IsNullOrEmpty(row["Quantity"]))
                    item.Quantity = int.Parse(row["Quantity"]);
                else
                {
                    item.Quantity = -1;
                }
                itemList.Add(item);
            }
            _cart.SetItems(itemList);
        }
     
        /////////////////////
        [Then(@"the user is presented with an error message")]
        public void ThenTheUserIsPresentedWithAnErrorMessage()
        {
            throw new Exception("Quantity exceeds the ammount of products in existance!");
        }

    }
}
