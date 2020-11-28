using NUnit.Framework;
using System;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private Computer computer;
        [SetUp]
        public void Setup()
        {
            this.computer = new Computer("Lenovo", "IdeaPad", 1750.00M);
        }

        [Test]
        public void ConstructorShouldInitializeEmptyCollection()
        {
            ComputerManager computerManager = new ComputerManager();
            int expectedCount = 0;
            CollectionAssert.IsEmpty(computerManager.Computers);
            Assert.That(computerManager.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void AddComputerShouldWorkCorrectly()
        {
            ComputerManager computerManager = new ComputerManager();
            int expectedCount = 1;

            computerManager.AddComputer(this.computer);

            Assert.That(computerManager.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void AddComputerShouldThrowExceptionWhenNullValue()
        {
            ComputerManager computerManager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.AddComputer(null);
            });
        }

        [Test]
        public void AddComputerShouldThrowExceptionWhenAddingExistingComputer()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.AddComputer(this.computer);
            });

        }

        [Test]
        public void GetComputerShouldWorkCorrectly()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            var comp = computerManager.GetComputer(this.computer.Manufacturer, this.computer.Model);

            Assert.That(comp.Manufacturer, Is.EqualTo(this.computer.Manufacturer));
            Assert.That(comp.Model, Is.EqualTo(this.computer.Model));
        }

        [Test]
        public void GetComputerShouldThrowExceptionWhenComputerNotFound()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentException>(() =>
            {
                var comp = computerManager.GetComputer(this.computer.Manufacturer, "NotePad");
            });
        }

        [Test]
        public void GetComputerShouldThrowExceptionWhenManufacturerNull()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var comp = computerManager.GetComputer(null, "NotePad");
            });

        }

        [Test]
        public void GetComputerShouldThrowExceptionWhenModelIsNull()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var comp = computerManager.GetComputer(this.computer.Manufacturer, null);
            });
        }

        [Test]
        public void GetComputersByManufacturerShouldWorkCorrectly()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);
            computerManager.AddComputer(new Computer("Lenovo", "NotePad", 1500.00M));

            var collection = computerManager.GetComputersByManufacturer("Lenovo").ToList();
            int expectedCount = 2;

            Assert.That(collection.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void GetComputersByManufacturerShouldThrowExceptionWhenManufacturerIsNull()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var collection = computerManager.GetComputersByManufacturer(null);
            });
        }

        [Test]
        public void GetComputersByManufacturerShouldReturnEmptyCollectionWhenNoMatchesFound()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            var collection = computerManager.GetComputersByManufacturer("Asus").ToList();

            CollectionAssert.IsEmpty(collection);
        }

        [Test]
        public void RemoveShouldWorkCorrectly()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);
            computerManager.AddComputer(new Computer("Lenovo", "NotePad", 1500.00M));
            int expectedCount = 1;

            var computer = computerManager.RemoveComputer(this.computer.Manufacturer, this.computer.Model);

            Assert.That(computerManager.Count, Is.EqualTo(expectedCount));
            Assert.That(computer.Manufacturer, Is.EqualTo(this.computer.Manufacturer));
            Assert.That(computer.Model, Is.EqualTo(this.computer.Model));

        }

        [Test]
        public void RemoveShouldThrowExceptionWhenManufacturerNull()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var computer = computerManager.RemoveComputer(null, "Model");
            });
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenNullModel()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var computer = computerManager.RemoveComputer(this.computer.Manufacturer, null);
            });
        }
    }
}