using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitDriver unitDriver;
        private RaceEntry raceEntry;
        [SetUp]
        public void Setup()
        {
            this.unitDriver = new UnitDriver("Pesho", new UnitCar("Ford", 120, 1800));
            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
           
            Assert.That(raceEntry.Counter, Is.EqualTo(0));
           
        }

        [Test]
        public void AddDriverShouldWorkCorrectly()
        {
           string result= this.raceEntry.AddDriver(this.unitDriver);

            Assert.That(this.raceEntry.Counter, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo($"Driver {this.unitDriver.Name} added in race."));

        }

        [Test]
        public void AddDriverShouldThrowExceptionWhenDriverNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                string result = this.raceEntry.AddDriver(null);
            });
        }

        [Test]
        public void AddDriverShouldThrowExceptionWhenExistingDriverName()
        {
            string result = this.raceEntry.AddDriver(this.unitDriver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                result = this.raceEntry.AddDriver(this.unitDriver);
            });
        }

        [Test]
        public void CalculateHPShouldReturnCorrectResult()
        {
            this.raceEntry.AddDriver(this.unitDriver);
            this.raceEntry.AddDriver(new UnitDriver("Steven", new UnitCar("Ford", 140, 1800)));

            double avgHp = this.raceEntry.CalculateAverageHorsePower();

            Assert.That(avgHp, Is.EqualTo(130));
        }

        [Test]
        public void CalculateHPShouldThrowExceptionWhenNotEnoughDrivers()
        {
           string result= this.raceEntry.AddDriver(this.unitDriver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                double avgHp = this.raceEntry.CalculateAverageHorsePower();
            });
        }
    }
}