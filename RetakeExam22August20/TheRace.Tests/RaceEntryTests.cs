using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitDriver driver;
        private UnitCar car;
        [SetUp]
        public void Setup()
        {
            this.car = new UnitCar("Mustang", 350, 3000.00);
            this.driver = new UnitDriver("Goshko", this.car);
        }

        [Test]
        public void ConstructorShouldInitialixeEmptyCollection()
        {
            RaceEntry race = new RaceEntry();
            int expectedCount = 0;
            Assert.That(race.Counter, Is.EqualTo(expectedCount));
        }
        [Test]
        public void AddDriverShouldIncreaseCountWhenSuccessfully()
        {
            RaceEntry race = new RaceEntry();
            race.AddDriver(this.driver);
            int expectedCount = 1;

            Assert.That(race.Counter, Is.EqualTo(expectedCount));
        }

        [Test]
        public void AddDriverShouldThrowExxceptionWithDriverNull()
        {
            RaceEntry race = new RaceEntry();
            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(null);
            });
        }

        [Test]
        public void AddDriverShouldThrowExceptionWhenAddingExistingDriver()
        {
            RaceEntry race = new RaceEntry();
            race.AddDriver(this.driver);
            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(this.driver);
            });
        }

        [Test]
        public void CalculateAverageHorsePowerShouldWorkCorrectly()
        {
            RaceEntry race = new RaceEntry();
            UnitCar car = new UnitCar("Range", 320, 3500.00);
            UnitDriver driver1 = new UnitDriver("Aleksandra", car);
            race.AddDriver(this.driver);
            race.AddDriver(driver1);
            double expectedAvrgPwr = (this.car.HorsePower + car.HorsePower) / 2;

            Assert.That(race.CalculateAverageHorsePower, Is.EqualTo(expectedAvrgPwr));

        }

        [Test]
        public void CalculateAverageHorsePowerShouldThrowExceptionWhenCounterLessThenMinimun()
        {
            RaceEntry race = new RaceEntry();
            race.AddDriver(this.driver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                double result = race.CalculateAverageHorsePower();
            });
        }


    }
}