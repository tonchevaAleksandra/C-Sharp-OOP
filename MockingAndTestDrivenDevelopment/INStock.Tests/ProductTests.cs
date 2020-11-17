namespace INStock.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ProductTests
    {
        //Arrange

        //Act

        //Assert
        [Test]
        public void LabelCannotBeNull()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arrange & Act
                var product = new Product(null, 10, 5);
            }, "Label cannot be null or empty.");
        }

        [Test]
        public void LabelCannotBeEmpty()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arrange & Act
                var product = new Product(string.Empty, 10, 5);
            }, "Label cannot be null or empty.");
        }

        [Test]
        public void PriceCannotBeLessThenZero()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arrange & Act
                var product = new Product("Test Product Label", -10, 10);
            }, "Price cannot be less then zero.");
        }

        [Test]
        public void QuantityCannotBeLessThanZero()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arrange & Act
                var product = new Product("Test Product Label", 10, -1);
            }, "Quantity cannot be less then zero.");
        }

        [Test]
        public void ProductShouldBeComparedByPriceWhenCorrectOrder()
        {
            var firstProduct = new Product("Test 1", 10, 1);
            var secondProduct = new Product("Test 2", 5, 1);

            var correctOrderResult = secondProduct.CompareTo(firstProduct);
            //if less then 0 firstProduct is before the second
            Assert.That(correctOrderResult < 0, Is.True);
        }
        [Test]
        public void ProductShouldBeComparedByPriceWhenInCorrectOrder()
        {
            var firstProduct = new Product("Test 1", 10, 1);
            var secondProduct = new Product("Test 2", 5, 1);
            var thirdProduct = new Product("Test 3", 5, 1);

            var incorrectOrderResult = firstProduct.CompareTo(secondProduct);

            //if more then 0 secondProduct should be before then first

            Assert.That(incorrectOrderResult > 0, Is.True);


        }
     

        [Test]
        public void ProductShouldBeComparedByPriceWhenEqualOrder()
        {
            var firstProduct = new Product("Test 1", 10, 1);
            var secondProduct = new Product("Test 2", 10, 1);

            var equalOrderResult = firstProduct.CompareTo(secondProduct);

            Assert.That(equalOrderResult == 0, Is.True);
        }
    }
}