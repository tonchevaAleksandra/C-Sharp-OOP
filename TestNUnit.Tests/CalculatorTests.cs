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
            var calculator = new Calculator();
            var result = calculator.CalculateSum(1, 2);

            Assert.That(result, Is.EqualTo(3));

        }
    }
}
