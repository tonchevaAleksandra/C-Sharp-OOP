using NUnit.Framework;
using System;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        private Product product;
        [SetUp]
        public void Setup()
        {
            this.product = new Product("Laptop", 2, 4569.00M);
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            StoreManager storeManager = new StoreManager();

            CollectionAssert.IsEmpty(storeManager.Products);
            Assert.That(storeManager.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddProductShouldWorkCorrectly()
        {
            StoreManager storeManager = new StoreManager();
            storeManager.AddProduct(this.product);
            int expectedCount = 1;

            Assert.That(storeManager.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void AddProductShouldThrowExceptionWhenProductIsNull()
        {
            StoreManager storeManager = new StoreManager();

            Assert.Throws<ArgumentNullException>(() =>
            {
                storeManager.AddProduct(null);
            });
        }

        [Test]
        public void AddShouldThrowExceptionWhenInvalidProductsQuantity()
        {
            StoreManager storeManager = new StoreManager();

            Assert.Throws<ArgumentException>(() =>
            {
                storeManager.AddProduct(new Product("Toy Bear",0,20.00M));
            });
        }

        [Test]
        public void BuyProductShouldReturnCorrectPrice()
        {
            StoreManager storeManager = new StoreManager();
            storeManager.AddProduct(this.product);


            decimal price = storeManager.BuyProduct(this.product.Name, 1);

            Assert.That(price, Is.EqualTo(this.product.Price));
            Assert.That(this.product.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void BuyProductShouldThrowExceptionWhenProductIsNull()
        {
            StoreManager storeManager = new StoreManager();
            storeManager.AddProduct(this.product);

            Assert.Throws<ArgumentNullException>(() =>
            {
                decimal price = storeManager.BuyProduct(" ", 1);
            });

        }

        [Test]
        public void BuyProductShouldThrowExceptionWhenNotEnoughQuantity()
        {
            StoreManager storeManager = new StoreManager();
            storeManager.AddProduct(this.product);

            Assert.Throws<ArgumentException>(() =>
            {
                decimal price = storeManager.BuyProduct(this.product.Name, 3);
            });
        }

        [Test]
        public void GetTheMostExpensiveProductShouldWorkCorrectly()
        {
            StoreManager storeManager = new StoreManager();
            storeManager.AddProduct(this.product);
            storeManager.AddProduct(new Product("Toy", 3, 35.00M));
            decimal expectedPrice = this.product.Price;

            var product = storeManager.GetTheMostExpensiveProduct();

            Assert.That(product.Price, Is.EqualTo(expectedPrice));


        }
    }
}