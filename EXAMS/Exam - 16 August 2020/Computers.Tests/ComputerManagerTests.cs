using NUnit.Framework;
using System;

namespace Computers.Tests
{
    public class Tests
    {
        private Computer computer;
        private ComputerManager computerManager;
        [SetUp]
        public void Setup()
        {
            this.computer = new Computer("Lenovo", "IdeaPad", 1500.00M);
            Assert.That(this.computer.Manufacturer, Is.EqualTo("Lenovo"));

          
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            this.computerManager = new ComputerManager();
            Assert.That(computerManager.Count, Is.EqualTo(0));
            Assert.IsEmpty(this.computerManager.Computers);
        }

        [Test]
        public void AddShouldWorkCorrectly()
        {
            this.computerManager = new ComputerManager();
            this.computerManager.AddComputer(this.computer);

            var computer = this.computerManager.GetComputer(this.computer.Manufacturer, this.computer.Model);

            Assert.That(computer.Manufacturer, Is.EqualTo(this.computer.Manufacturer));
            Assert.That(computer.Model, Is.EqualTo(this.computer.Model));
            Assert.That(computer.Price, Is.EqualTo(this.computer.Price));
            Assert.That(this.computerManager.Count, Is.EqualTo(1));
            Assert.That(this.computerManager.Computers, Has.Member(this.computer));
        }

        [Test]
        public void AddShouldThrowExceptionWhenComputerIsNull()
        {
            this.computerManager = new ComputerManager();
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computerManager.AddComputer(null);
            });
        }

        [Test]
        public void AddShouldThrowExceptionWhenExistingComputer()
        {
            this.computerManager = new ComputerManager();
            this.computerManager.AddComputer(this.computer);
            Assert.Throws<ArgumentException>(() =>
            {
                this.computerManager.AddComputer(new Computer("Lenovo","IdeaPad",1300M));
            });
        }

        [Test]
        public void GetComputerShouldThrowExceptionWhenManufacturerIsNull()
        {
            this.computerManager = new ComputerManager();
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computerManager.GetComputer(null, "IdeaPad");
            });
        }

        [Test]
        public void GetComputerShouldThrowExceptionWhenModelIsNull()
        {
            this.computerManager = new ComputerManager();
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computerManager.GetComputer("Lenovo", null);
            });
        }

        [Test]
        public void GetComputerShouldThrowExceptionWhenNoExistingComputer()
        {
            this.computerManager = new ComputerManager();
            Assert.Throws<ArgumentException>(() =>
            {
                this.computerManager.GetComputer("Lenovo", "IdeaPad");
            });
        }

        [Test]
        public void GetComputerShouldWorkCorrectly()
        {
            this.computerManager = new ComputerManager();
            this.computerManager.AddComputer(this.computer);

            Computer receivedComputer = this.computerManager.GetComputer("Lenovo", "IdeaPad");

            Assert.That(receivedComputer.Manufacturer, Is.EqualTo(this.computer.Manufacturer));
            Assert.That(receivedComputer.Model, Is.EqualTo(this.computer.Model));
            Assert.That(receivedComputer.Price, Is.EqualTo(this.computer.Price));
        }

        [Test]
        public void RemoveComputerShouldWorkCorrectly()
        {
            this.computerManager = new ComputerManager();
            this.computerManager.AddComputer(this.computer);

            Computer removedComputer = this.computerManager.RemoveComputer("Lenovo", "IdeaPad");

            Assert.That(removedComputer.Manufacturer, Is.EqualTo(this.computer.Manufacturer));
            Assert.That(removedComputer.Model, Is.EqualTo(this.computer.Model));
            Assert.That(this.computerManager.Count, Is.EqualTo(0));

        }
        [Test]
        public void RemoveShouldThrowExceptionWhenManufacturerIsNull()
        {
            this.computerManager = new ComputerManager();
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computerManager.RemoveComputer(null, "Some");
            });
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenModelIsNull()
        {
            this.computerManager = new ComputerManager();
            this.computerManager.AddComputer(this.computer);
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computerManager.RemoveComputer("Lenovo", null);
            });
        }

        [Test]
        public void GetComputerByManufacturerShouldThrowException()
        {
            this.computerManager = new ComputerManager();
            Assert.Throws<ArgumentNullException>(() =>
            {
                var removedComps = this.computerManager.GetComputersByManufacturer(null);
            });
        }
        [Test]
        public void GetComputerBymanufacturerShouldReturnEmptyCollection()
        {
            this.computerManager = new ComputerManager();
            this.computerManager.AddComputer(this.computer);
            this.computerManager.AddComputer(new Computer("Lenovo", "ThinkPad", 1400M));

            var resultCollection = this.computerManager.GetComputersByManufacturer("Asus");

            Assert.That(resultCollection.Count, Is.EqualTo(0));
        }
        [Test]
        public void GetComputerByManufacturerShouldReturnCollection()
        {
            this.computerManager = new ComputerManager();
            this.computerManager.AddComputer(this.computer);
            this.computerManager.AddComputer(new Computer("Lenovo", "ThinkPad", 1400M));

            var resultCollection = this.computerManager.GetComputersByManufacturer(this.computer.Manufacturer);

            Assert.That(resultCollection.Count, Is.EqualTo(2));
        }
        
    }
}