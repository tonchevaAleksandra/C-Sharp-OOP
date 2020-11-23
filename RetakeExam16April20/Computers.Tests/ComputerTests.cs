namespace Computers.Tests
{
    using NUnit.Framework;
    using System;

    public class ComputerTests
    {
        
        [SetUp]
        public void Setup()
        {
          
        }

        [Test]
        public void ConstructorShouldSetCorrectNameProperty()
        {
            Computer computer = new Computer("a");
            Assert.That(computer.Name, Is.EqualTo("a"));
        }

        [Test]
        public void ConstructorShouldInitializeEmptyCollection()
        {
            Computer computer = new Computer("a");
            Assert.IsEmpty(computer.Parts);
        }

        [Test]
        public void ConstructorShouldThrowExceptionIfNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Computer computer = new Computer(null);

            });
           
        }

        [Test]
        public void ConstructorShouldThrowExceptionIfNameIsWhiteSpace()
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                Computer computer = new Computer(" ");

            });
        }

        [Test]
        public void AddShouldIncreaseCountOfPartsProperty()
        {
            Part part1 = new Part("a", 20.00M);
            Part part2 = new Part("b", 30.00M);
            Computer computer = new Computer("a");
            computer.AddPart(part1);
            computer.AddPart(part2);
            int expectedCount = 2;
            decimal expectedTotalPrice = part1.Price + part2.Price;
            Assert.That(computer.Parts.Count, Is.EqualTo(expectedCount));
            Assert.That(computer.TotalPrice, Is.EqualTo(expectedTotalPrice));
        }

        [Test]
        public void AddShouldThrowExceptionIfPartIsNull()
        {
            Computer computer = new Computer("a");
            Assert.Throws<InvalidOperationException>(() =>
            {
                computer.AddPart(null);
            });
            
        }

        [Test]
        public void RemovePartShouldWorkCorrectly()
        {
            Part part1 = new Part("a", 20.00M);
            Part part2 = new Part("b", 30.00M);
            Computer computer = new Computer("a");
            computer.AddPart(part1);
            computer.AddPart(part2);
            int expectedCount = 1;

            bool result = computer.RemovePart(part1);

            Assert.That(result, Is.True);
            Assert.That(computer.Parts.Count, Is.EqualTo(expectedCount));

        }

        [Test]
        public void RemoveShouldReturnFalseIfThePartIsNotExisting()
        {
            Computer computer = new Computer("a");
            bool result = computer.RemovePart(new Part("b",20.00M));

            Assert.That(result, Is.False);
        }

        [Test]
        public void GetPartShouldReturnPartIfCorrectName()
        {
            Part part1 = new Part("a", 20.00M);
            Part part2 = new Part("b", 30.00M);
            Computer computer = new Computer("a");
            computer.AddPart(part1);
            computer.AddPart(part2);

            Part result = computer.GetPart(part1.Name);

            Assert.That(result.Name, Is.EqualTo(part1.Name));
            Assert.That(result.Price, Is.EqualTo(part1.Price));
        }

        [Test]
        public void GetPartShouldReturnNullIfThePartDoesntExist()
        {
            Part part1 = new Part("a", 20.00M);
            Part part2 = new Part("b", 30.00M);
            Computer computer = new Computer("a");
            computer.AddPart(part1);
            computer.AddPart(part2);

            Part result = computer.GetPart("c");
            Assert.That(result, Is.Null);
        }
    }
}