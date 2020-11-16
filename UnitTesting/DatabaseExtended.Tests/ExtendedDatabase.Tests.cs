using System;

using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {

        private  Person person;
        private readonly Person[] persons = new Person[] 
        {  
            new Person(1,"Ivan"),
            new Person(2,"Stamat")
        };

        private ExtendedDatabase extendedDatabase;

        [SetUp]
        public void Setup()
        {
          this.person = new Person(1, "Ivan");
            Person[] personsData = new Person[]
            {
                new Person(1,"Ivan1"),
                new Person(2,"Ivan2"),
                new Person(3,"Ivan3"),
                new Person(4,"Ivan4"),
                new Person(5,"Ivan5"),
                new Person(6,"Ivan6"),
                new Person(7,"Ivan7"),
                new Person(8,"Ivan8"),
                new Person(9,"Ivan9"),
                new Person(10,"Ivan10"),
                new Person(11,"Ivan11"),
                new Person(12,"Ivan12"),
                new Person(13,"Ivan13"),
                new Person(14,"Ivan14"),
                new Person(15,"Ivan15"),

            };

            this.extendedDatabase = new ExtendedDatabase(personsData);
        }

        [Test]
        public void ConstructorOfPersonShouldWorkCorrectly()
        {
            long expectedID = (long)1;
            string expectedUserName = "Ivan";

            long actualID = this.person.Id;
            string actualUSer = this.person.UserName;

            Assert.That(actualUSer, Is.EqualTo(expectedUserName));
            Assert.That(actualID, Is.EqualTo(expectedID));
            
        }

        [Test]
        public void ConstructorOfDatabaseShouldWorkCorrectly()
        {
            int expectedCount = 2;

            this.extendedDatabase = new ExtendedDatabase(persons);
            int actualCount = this.extendedDatabase.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));

        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenBiggerCollection()
        {
            Person[] data = new Person[17];

            Assert.Throws<ArgumentException>(() =>
            {
                this.extendedDatabase = new ExtendedDatabase(data);
            }, "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void AddShouldThrowExceptionWhenFullCapacity()
        {
            this.extendedDatabase.Add(new Person(16, "Ivan16"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.Add(new Person(17, "Ivan17"));
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void AddShouldThrowExceptionWhenUserNameExists()
        {
            Person personToAdd = new Person(222, "Ivan1");
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.Add(personToAdd);
            }, "There is already user with this username!");
        }

        [Test]
        public void AddShouldThrowExceptionWhenIDExists()
        {
            Person personToAdd1 = new Person(2, "Peter");
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.Add(personToAdd1);
            }, "There is already user with this Id!");
        }

        [Test]
        public void RemoveShouldDecreaseCount()
        {
            int expectedCount = 14;
            this.extendedDatabase.Remove();

            int actualCount = this.extendedDatabase.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenCountZero()
        {
            ExtendedDatabase data = new ExtendedDatabase(this.persons);
            data.Remove();
            data.Remove();
            Assert.Throws<InvalidOperationException>(() =>
           {
               data.Remove();
           });
        }

        [Test]
        public void FindByNameShouldWorkCorrectly()
        {
            Person expectedPerson = new Person(1, "Ivan1");
            string searchedName = "Ivan1";

            Assert.That(this.extendedDatabase.FindByUsername(searchedName).UserName, Is.EqualTo(expectedPerson.UserName));
        }

        [Test]
        public void FindByUserNameShouldThrowExcWhenNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.extendedDatabase.FindByUsername("");
            }, "Username parameter is null!");
        }

        [Test]
        public void FindByNameShouldThrowExcWhenNameDontExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.FindByUsername("Aleksandra");
            }, "No user is present by this username!");
        }

        [Test]
        public void FindByIDShouldWorkCorrectly()
        {
            Person expectedPerson = new Person(1, "Ivan1");
            long searchedID = (long)1;

            Assert.That(this.extendedDatabase.FindById(searchedID).Id, Is.EqualTo(expectedPerson.Id));
        }

        [Test]
        public void FindByIDShouldThrowExcWhenIDBelowZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.extendedDatabase.FindById(-10);
            }, "Id should be a positive number!");
        }

        [Test]
        public void FindByIDShouldThrowExcWhenUnExistingID()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.FindById(100);
            }, "No user is present by this ID!");
        }

    }
}