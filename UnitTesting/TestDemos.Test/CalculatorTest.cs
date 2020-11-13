using System;
using Xunit;

namespace TestDemos.Test
{
    public class CalculatorTest
    {
        [Fact]
        public void SumShouldReturnCorrectResultWithTwoNumbers()
        {
            var calculator = new Calculator();
            var result = calculator.CalculateSum(1, 2);
           
            Assert.Equal(3, result);
           
        }

        [Fact]
        public void SumShouldReturnCorrectResultWithManyNumbers()
        {
            var calculator = new Calculator();
            var result = calculator.CalculateSum(1, 2, 3, 4, 5, 6);

            Assert.Equal(21, result);
        }

        [Fact]
        public void SumShouldReturnCorrectResultWithNoNumbers()
        {
            var calculator = new Calculator();
            var result = calculator.CalculateSum();

            Assert.Equal(0, result);
        }

        [Fact]
        public void ProductShouldReturnCorrectResultWithTwoNumbers()
        {
            var calculator = new Calculator();
            var result = calculator.Product(2,3);
            Assert.Equal(6, result);
        }
        [Fact]
        public void ProductShouldThrowExceptionWithNullNumbers()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var calculator = new Calculator();
                var result = calculator.Product(null);
            });
         
        }
    }
}
