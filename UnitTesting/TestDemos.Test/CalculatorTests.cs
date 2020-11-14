using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TestDemos;

namespace TestNUnit.Tests
{
    [TestFixture]
   public class CalculatorTests
    {
        [Test]
        public void SumShouldReturnCorrectResultWithTwoNumbers()
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            var result = calculator.CalculateSum(1, 2);
            //Assert
            Assert.That(result, Is.EqualTo(3));

        }
    }
}
