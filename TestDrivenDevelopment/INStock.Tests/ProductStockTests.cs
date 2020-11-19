namespace INStock.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ProductStockTests
    {
        private const string ProductLabel = "Test";
        private ProductStock productStock;
        private Product product;
        private Product anotherProduct;

        [SetUp]
        public void SetUpProduct()
        {
            this.productStock = new ProductStock();
            this.product = new Product(ProductLabel, 10, 1);
            this.anotherProduct = new Product("Test1", 5, 10);
        }

        [Test]
        public void AddProductShouldSaveTheProduct()
        {

            this.productStock.Add(this.product);

            var productInStock = this.productStock.FindByLabel(ProductLabel);

            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(ProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(this.product.Price));
            Assert.That(productInStock.Quantity, Is.EqualTo(this.product.Quantity));
        }

        [Test]
        public void AddProductShouldThrowExceptionWhenProductIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.productStock.Add(null);
            }, "Product cannot be null.");
        }

        [Test]
        public void AddProductWithDuplicateLabelShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.productStock.Add(this.product);
                this.productStock.Add(this.product);
            }, $"A product with '{ProductLabel}' label already exist!");
        }

        [Test]
        public void AddingTwoProductsShouldSaveThem()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            var firstProductInStock = this.productStock.FindByLabel(ProductLabel);
            var secondProductInStock = this.productStock.FindByLabel(this.anotherProduct.Label);

            Assert.That(firstProductInStock, Is.Not.Null);
            Assert.That(firstProductInStock.Label, Is.EqualTo(ProductLabel));
            Assert.That(firstProductInStock.Price, Is.EqualTo(this.product.Price));
            Assert.That(firstProductInStock.Quantity, Is.EqualTo(this.product.Quantity));

            Assert.That(secondProductInStock, Is.Not.Null);
            Assert.That(secondProductInStock.Label, Is.EqualTo(this.anotherProduct.Label));
            Assert.That(secondProductInStock.Price, Is.EqualTo(this.anotherProduct.Price));
            Assert.That(secondProductInStock.Quantity, Is.EqualTo(this.anotherProduct.Quantity));
        }

        [Test]
        public void RemoveShouldReturnTrueIfExistingProductIsRemoved()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            var result = this.productStock.Remove(this.anotherProduct);

            Assert.That(result, Is.True);
            Assert.That(this.productStock.Count, Is.EqualTo(1));
            Assert.That(this.productStock[0].Label, Is.EqualTo(this.product.Label));
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenProductIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var result = this.productStock.Remove(null);
            }, "The product cannot be null!");
        }
        [Test]
        public void RemoveShouldThrowExceptionIfNoProductsInStock()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var result = this.productStock.Remove(this.anotherProduct);
            }, "There is no products in stock.");
        }

        [Test]
        public void RemoveShouldReturnFalseWhenNoMatchesFound()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            var result = this.productStock.Remove(new Product("No Match", 20, 20));

            Assert.That(result, Is.False);
        }
        [Test]
        public void ContainsShouldReturnTrueIfTheProductExist()
        {
            this.productStock.Add(this.product);

            var result = this.productStock.Contains(this.product);

            Assert.That(result, Is.True);
        }

        [Test]
        public void ContainsShouldReturnFalseIsTheProductDantExist()
        {
            var result = this.productStock.Contains(this.product);

            Assert.That(result, Is.False);
        }

        [Test]
        public void ContainsShouldThrowExceptionIfProductIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.productStock.Contains(null);
            }, "Product cannot be null!");
        }

        [Test]
        public void CountShouldReturnCorrectProductCount()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            var result = this.productStock.Count;

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void FindShouldReturnProductByIndex()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            var productInStock = this.productStock.Find(1);

            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(this.anotherProduct.Label));
            Assert.That(productInStock.Price, Is.EqualTo(this.anotherProduct.Price));
            Assert.That(productInStock.Quantity, Is.EqualTo(this.anotherProduct.Quantity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-2)]
        public void FindShouldThrowExceptionWhenIndexOutOfRangeOrNegative(int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                this.productStock.Find(index);
            }, "Product index does not exist.");
        }


        [Test]
        public void FindByLabelShouldReturnProductByLabel()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            var productInStock = this.productStock.FindByLabel(anotherProduct.Label);

            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(this.anotherProduct.Label));
            Assert.That(productInStock.Price, Is.EqualTo(this.anotherProduct.Price));
            Assert.That(productInStock.Quantity, Is.EqualTo(this.anotherProduct.Quantity));
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void FindByLabelShouldThrowExceptionIfValueNullEmptyOrEmpty(string label)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.productStock.FindByLabel(label);
            }, "The label cannot be null, empty or whitespace.");
        }

        [Test]
        public void FindByLabelShouldThrowExceptionIfLabelDontExist()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.productStock.FindByLabel("Invalid label");
            }, "Product with such label does not exist.");
        }
        [Test]
        public void FindAllInPriceRangeShouldReturnEmptyCollectionWhenNoProductMatch()
        {
            this.AddMultipleProductsToProductStock();

            var resultCollection = this.productStock.FindAllInRange(100, 200);

            Assert.That(resultCollection, Is.Empty);

        }

        [Test]
        public void FindAllInPriceRangeShouldReturnCorrectResultInCorrectOrder()
        {
            this.AddMultipleProductsToProductStock();
            var resultCollection = this.productStock.FindAllInRange(1, 11).ToList();

            Assert.That(resultCollection.Count(), Is.EqualTo(3));

            Assert.That(resultCollection[0].Price, Is.EqualTo(10));
            Assert.That(resultCollection[1].Price, Is.EqualTo(5));
            Assert.That(resultCollection[2].Price, Is.EqualTo(3));
        }
        [Test]
        public void FindByPriceShouldReturnAllProductsMatchedThePrice()
        {
            this.AddMultipleProductsToProductStock();
            // this.productStock.Add(new Product("3", 15, 20));
            //this.productStock.Add(new Product("6", 15, 3));
            var resultCollection = this.productStock.FindAllByPrice(15).ToList();

            Assert.That(resultCollection.Count(), Is.EqualTo(2));

            Assert.That(resultCollection[0].Label, Is.EqualTo("3"));
            Assert.That(resultCollection[1].Label, Is.EqualTo("6"));
        }

        [Test]
        public void FindByPriceShouldReturnEmptyCollectionWhenMatchesNotFound()
        {
            this.AddMultipleProductsToProductStock();

            var resultCollection = this.productStock.FindAllByPrice(2.20).ToList();

            Assert.That(resultCollection, Is.Empty);
        }

        [Test]
        public void FindMostExpensiveProductShouldReturnCorrect()
        {
            this.AddMultipleProductsToProductStock();

            var productInStock = this.productStock.FindMostExpensiveProduct();
            // "7", 50, 7)
            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo("7"));
            Assert.That(productInStock.Price, Is.EqualTo(50));
            Assert.That(productInStock.Quantity, Is.EqualTo(7));
        }

        [Test]
        public void FindMostExpensiveProductShouldThrowExceptionWhenProductStockEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var productInStock = this.productStock.FindMostExpensiveProduct();
            }, "The productStock is empty.");
        }

        [Test]
        public void FindAllByQuantityShouldReturnCorrectResultWhenProductMatch()
        {
            this.AddMultipleProductsToProductStock();
            //this.productStock.Add(new Product("5", 25, 7));
            //this.productStock.Add(new Product("7", 50, 7));
            var resultCollection = this.productStock.FindAllByQuantity(7).ToList();

            Assert.That(resultCollection.Count(), Is.EqualTo(2));

            Assert.That(resultCollection[0].Label, Is.EqualTo("5"));
            Assert.That(resultCollection[0].Price, Is.EqualTo(25));
            Assert.That(resultCollection[1].Label, Is.EqualTo("7"));
            Assert.That(resultCollection[1].Price, Is.EqualTo(50));

        }

        [Test]
        public void FindAllByQuantityShouldReturnEmptyCollectionWhenNoMatches()
        {
            this.AddMultipleProductsToProductStock();

            var resultCollection = this.productStock.FindAllByQuantity(2).ToList();

            Assert.That(resultCollection, Is.Empty);
        }

        [Test]
        public void GetEnumeratorShouldReturnAllProductsInStock()
        {
            this.AddMultipleProductsToProductStock();

            var resultCollection = this.productStock.ToList();

            Assert.That(resultCollection[0].Label, Is.EqualTo("4"));
            Assert.That(resultCollection[1].Label, Is.EqualTo("2"));
            Assert.That(resultCollection[2].Label, Is.EqualTo("1"));
            Assert.That(resultCollection[3].Label, Is.EqualTo("3"));
            Assert.That(resultCollection[4].Label, Is.EqualTo("6"));
            Assert.That(resultCollection[5].Label, Is.EqualTo("5"));
            Assert.That(resultCollection[6].Label, Is.EqualTo("7"));
        }

        [Test]
        public void GetIndexShouldReturnCorrectProduct()
        {

            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            var productInStock = this.productStock[1];

            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(this.anotherProduct.Label));
            Assert.That(productInStock.Price, Is.EqualTo(this.anotherProduct.Price));
            Assert.That(productInStock.Quantity, Is.EqualTo(this.anotherProduct.Quantity));
        }

        [Test]
        [TestCase(-2)]
        [TestCase(6)]
        public void GetIndexShouldThrowExceptionIfOutOfRange(int index)
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var productInStock = this.productStock[index];
            }, "Index is out of range.");
            
        }

      

        [Test]
        public void SetIndexShouldChangeProduct()
        {
            this.AddMultipleProductsToProductStock();

            this.productStock[3] = new Product("Change Product", 50, 3);

            var productInStock = this.productStock.Find(3);


            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo("Change Product"));
            Assert.That(productInStock.Price, Is.EqualTo(50));
            Assert.That(productInStock.Quantity, Is.EqualTo(3));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(10)]
        public void SetShouldThrowExceptionIfIndexOutOfRange(int index)
        {
            this.AddMultipleProductsToProductStock();
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                this.productStock[index] = null;
            }, "Index is out of range.");
            
        }
        /// <summary>
        /// Add some products to use them in the tests
        /// </summary>
        private void AddMultipleProductsToProductStock()
        {
            this.productStock.Add(new Product("4", 3, 18));
            this.productStock.Add(new Product("2", 5, 60));
            this.productStock.Add(new Product("1", 10, 5));
            this.productStock.Add(new Product("3", 15, 20));
            this.productStock.Add(new Product("6", 15, 3));
            this.productStock.Add(new Product("5", 25, 7));
            this.productStock.Add(new Product("7", 50, 7));
        }

    }
}
