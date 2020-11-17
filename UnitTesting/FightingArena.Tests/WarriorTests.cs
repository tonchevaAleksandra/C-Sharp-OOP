using System;

using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;
        

        [SetUp]
        public void Setup()
        {     
        }

        [Test]
        public void Constructor_Should_Work_Correctly()
        {
            string expectedName = "George";
            int expectedDamage = 20;
            int expectedHP = 100;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP);
           
            Assert.That(warrior.Name, Is.EqualTo(expectedName));
            Assert.That(warrior.Damage, Is.EqualTo(expectedDamage));
            Assert.That(warrior.HP, Is.EqualTo(expectedHP));
        }

        [Test]   
        public void Name_Should_Throw_Exc_When_Value_WhiteSpace()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior(" ", 40, 40);
            });
        }

        [Test]
        public void Name_Should_Throw_Exc_When_Value_Null()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior(null, 40, 40);
            });
        }

        [Test]
        public void Name_Should_Throw_Exc_When_Empty_Value()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior(string.Empty, 40, 40);
            });
        }

        [Test]
     
        public void Damage_Should_Throw_Exception_If_Damage_Zero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior("Peter", 0, 20);
            });
        }

        [Test]
        public void Damage_Should_Throw_Exception_If_Damage_Negative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior("Peter", -20, 20);
            });
        }

        [Test]
        public void HP_Should_Throw_Exception_If_Negative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior("Peter", 20, -1);
            });
        }

        [Test]
        [TestCase(30)]
        [TestCase(20)]
        public void Attack_Should_Throw_Exception_When_Hp_Lower_Then_31(int hp)
        {
            Warrior myWarrior = new Warrior("Stiv", 20, hp);
            Warrior enemy = new Warrior("Peter", 20, 40);
           
            Assert.Throws<InvalidOperationException>(() =>
            {
                myWarrior.Attack(enemy);
            });
          
        }

        [Test]
        [TestCase(30)]
        [TestCase(20)]
        public void Attack_Should_Throw_Exception_If_Enemy_HP_Lower_31(int hp)
        {
            Warrior myWarrior = new Warrior("Stiv", 20, 40);
            Warrior enemy = new Warrior("Peter", 20, hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                myWarrior.Attack(enemy);
            });
        }

        [Test]
        public void Attack_Should_Throw_Exception_Hp_Lower_Then_Enemys_Damage()
        {
            Warrior myWarrior = new Warrior("Stiv", 100, 90);
            Warrior enemy = new Warrior("Peter", 100, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                myWarrior.Attack(enemy);
            });
        }

        [Test]
        public void Attack_Should_Decrease_Hp()
        {
            Warrior myWarrior = new Warrior("Stiv", 60, 100);
            Warrior enemy = new Warrior("Peter", 50, 100);
            int expectedHp = myWarrior.HP-enemy.Damage;
            int expectedEnemyHp = enemy.HP-myWarrior.Damage;

            myWarrior.Attack(enemy);

            Assert.That(myWarrior.HP, Is.EqualTo(expectedHp));
            Assert.That(enemy.HP, Is.EqualTo(expectedEnemyHp));
        }
        
        [Test]
        public void Attack_Should_Set_Enemys_Hp_Zero_When_Damage_Bigger_Then_Enemys_Hp()
        {
            Warrior myWarrior = new Warrior("Stiv", 100, 100);
            Warrior enemy = new Warrior("Peter", 40, 90);
            int expectedWarriorHp = myWarrior.HP - enemy.Damage;
            int expectedEnemyHp = 0;

            myWarrior.Attack(enemy);

            Assert.That(myWarrior.HP, Is.EqualTo(expectedWarriorHp));
            Assert.That(enemy.HP, Is.EqualTo(expectedEnemyHp));
        }
    }
}