using System;

using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private Car initialCar;

        [SetUp]
        public void Setup()
        {
            this.initialCar = new Car("Ford", "Fiesta", 6.0, 50.00);
        }

        [Test]
        public void ConstructorShouldSetFuelAmount()
        {
            double expectedFuelAmount = 0;
         
            Assert.That(this.initialCar.FuelAmount, Is.EqualTo(expectedFuelAmount));
          
        }

        [Test]
        public void MakeShouldBeSetCorrectly()
        {
            string expectedMake = "Ford";
            Assert.That(this.initialCar.Make, Is.EqualTo(expectedMake));
        }

        [TestCase("")]
        [TestCase(null)]
        public void MakeShouldThrowExcWhenValueNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Car(make, "Fiesta", 5.00, 45.00);

            }, "Make cannot be null or empty!");

        }

        [Test]
        public void ModelShouldSetCorrectly()
        {
            string expectedModel = "Fiesta";

            Assert.That(this.initialCar.Model, Is.EqualTo(expectedModel));
        }

        [TestCase("")]
        [TestCase(null)]
        public void ModelShouldThrowExcWhenValueNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car2 = new Car("BMW", model, 10.8, 55);

            }, "Model cannot be null or empty!");
        }

        [Test]
        public void FuelConsumptionShouldSetCorrectly()
        {
            double expectedFuelConsumption = 6.0;

            Assert.That(this.initialCar.FuelConsumption, Is.EqualTo(expectedFuelConsumption));
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void FuelConsumptionShouldThrowExcWhenValueZeroOrNegative(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
                {
                    new Car("Ford", "Fiesta", fuelConsumption, 50.00);
                }, "Fuel consumption cannot be zero or negative!");

        }

        [Test]
       public void FuelCapacityShouldSetCorrectly()
        {
            double expectedCapacity = 50.00;

            Assert.That(this.initialCar.FuelCapacity, Is.EqualTo(expectedCapacity));
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void FuelCapacityShouldThrowExcWhenValueZeroOrNegative(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Car("Audi", "Q7", 17.0, fuelCapacity);
            }, "Fuel capacity cannot be zero or negative!");

        }

        [Test]
        public void RefuelShouldWorkCorrectly()
        {
            double expectedFuelAmount = 50;

            this.initialCar.Refuel(50);

            Assert.That(this.initialCar.FuelAmount, Is.EqualTo(expectedFuelAmount));
        }

        [Test]
        public void RefuelShouldWorkEvenWithFuelAmountBiggerThenCapacity()
        {
            double expectedFuelAmount = 50;

            this.initialCar.Refuel(60);

            Assert.That(this.initialCar.FuelAmount, Is.EqualTo(expectedFuelAmount));
        }

        [TestCase(0)]
        [TestCase(-20)]
        public void RefuelShouldThrowExceptionWhenValueIsZeroOrNegative(double fuel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.initialCar.Refuel(fuel);
            }, "Fuel amount cannot be zero or negative!");
     
        }

        [Test]
        public void DriveShouldWorkCorrectly()
        {
            var expectedFuel = 4.00;

            this.initialCar.Refuel(10);
            this.initialCar.Drive(100);

            Assert.That(this.initialCar.FuelAmount, Is.EqualTo(expectedFuel));

        }

        [Test]
        public void DriveShouldThrowExceptionWhenFuelIsNotEnoughForDistance()
        {
            this.initialCar.Refuel(10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.initialCar.Drive(300);
            }, "You don't have enough fuel to drive!");
        }
    }
}