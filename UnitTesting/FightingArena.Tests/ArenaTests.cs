using System;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior attacker;
        private Warrior deffender;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.attacker = new Warrior("Pesho", 10, 80);
            this.deffender = new Warrior("Peter", 5, 50);
        }

        [Test]
        public void Constructor_Should_Work_Correctly()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void Count_Should_Work_Correctly()
        {
            int expectedCount = 0;

            Assert.That(this.arena.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Enroll_Should_Work_Correctly_When_Enroll_New_Unique_Warrior()
        {
            Warrior warriorToEnroll = new Warrior("Peter", 100, 100);
            int expectedCount = 1;

            this.arena.Enroll(warriorToEnroll);

            Assert.That(this.arena.Count, Is.EqualTo(expectedCount));
            CollectionAssert.Contains(this.arena.Warriors,warriorToEnroll);

        }

        [Test]
        public void Enroll_Should_Throw_Exception_Adding_An_Existing_Warrior()
        {
            Warrior warriorToEnroll = new Warrior("Peter", 100, 100);

            this.arena.Enroll(warriorToEnroll);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warriorToEnroll);
            });
        }

        [Test]
        public void Enroll_Should_Throw_Exception_When_Two_Warriors_Have_Same_Name()
        {
            Warrior warriorToEnroll = new Warrior("Peter", 100, 100);
            Warrior another = new Warrior("Peter", 80, 80);

            this.arena.Enroll(warriorToEnroll);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(another);
            });

            
        }

        [Test]
        public void Fight_Should_Throw_Exception_When_Missing_Attacker()
        {
            this.arena.Enroll(this.deffender);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(this.attacker.Name, this.deffender.Name);
            });
        }
        [Test]
        public void Fight_Should_Throw_Exception_When_Missing_Deffender()
        {
            this.arena.Enroll(this.attacker);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(this.attacker.Name, this.deffender.Name);
            });
        }
        [Test]
        public void Fight_Should_Throw_Exception_When_Missing_The_Two_Warriors()
        {
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(this.attacker.Name, this.deffender.Name);
            });
        }
        [Test]
        public void Fight_Should_Work_With_Corrects_Parameters()
        {
            int expectedAttackerHp = this.attacker.HP - this.deffender.Damage;
            int expectedDeffenderHp = this.deffender.HP - this.attacker.Damage;

            this.arena.Enroll(this.attacker);
            this.arena.Enroll(this.deffender);

            this.arena.Fight(this.attacker.Name, this.deffender.Name);

            Assert.That(this.attacker.HP, Is.EqualTo(expectedAttackerHp));
            Assert.That(this.deffender.HP, Is.EqualTo(expectedDeffenderHp));
        }
    }
}
