namespace Computers.Tests
{
    using NUnit.Framework;
    using System;

    public class ComputerTests
    {
        private Part part;
        private Computer computer;
        [SetUp]
        public void Setup()
        {
            this.part = new Part("Part", 20M);
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            this.computer = new Computer("Asus");
            Assert.IsEmpty(this.computer.Parts);
            Assert.That(this.computer.Name, Is.EqualTo("Asus"));
        }

        [Test]
        public void NameNullShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computer = new Computer(null);
            });
        }
        [Test]
        public void NameWhiteSpaceShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computer = new Computer("  ");
            });
        }

        [Test]
        public void TotalPriceShouldReturnCorrectPrice()
        {
            this.computer = new Computer("Assus");
            this.computer.AddPart(this.part);
            this.computer.AddPart(new Part("mouse", 30M));
            var total=this.computer.TotalPrice;

            Assert.That(total, Is.EqualTo(50M));
            
        }

        [Test]
        public void AddPartShoulThrowExceptionWhenPartNull()
        {
            this.computer = new Computer("Assus");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.computer.AddPart(null);
            });
        }

        [Test]
        public void AddShoulIncreaseCount()
        {
            this.computer = new Computer("Assus");
            this.computer.AddPart(this.part);
            Assert.That(this.computer.Parts.Count, Is.EqualTo(1));
            var addedPart = this.computer.GetPart(this.part.Name);
            Assert.That(addedPart.Name, Is.EqualTo(this.part.Name));
            Assert.That(addedPart.Price, Is.EqualTo(this.part.Price));
        }

        [Test]
        public void RemoveShouldReturnTrue()
        {
            this.computer = new Computer("Assus");
            this.computer.AddPart(this.part);

            var result = this.computer.RemovePart(this.part);

            Assert.IsTrue(result);
        }
        [Test]
        public void RemoveShouldRenurnFalse()
        {
            this.computer = new Computer("Assus");
            this.computer.AddPart(this.part);

            var result = this.computer.RemovePart(new Part("P",20M));

            Assert.IsFalse(result);
        }

        [Test]
        public void GetPartShouldWorkCorrectly()
        {
            this.computer = new Computer("Assus");
            this.computer.AddPart(this.part);
            var getedPart = this.computer.GetPart(this.part.Name);

            Assert.That(getedPart.Name, Is.EqualTo(this.part.Name));
            Assert.That(getedPart.Price, Is.EqualTo(this.part.Price));
        }

        [Test]
        public void GetPartShouldReturnNull()
        {
            this.computer = new Computer("Assus");
            this.computer.AddPart(this.part);
            var getedPart = this.computer.GetPart("P");

            Assert.IsNull(getedPart);
            
        }
    }
}