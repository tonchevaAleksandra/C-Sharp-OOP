namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;
        [SetUp]
        public void SetUp()
        {
            this.robot = new Robot("Robo", 100);
        }

        [Test]
        public void ConstructorShouldInitializeCollection()
        {
            this.robotManager = new RobotManager(20);

            Assert.That(this.robotManager.Count, Is.EqualTo(0));
            Assert.That(this.robotManager.Capacity, Is.EqualTo(20));
        }

        [Test]
        public void CapacityShouldThrowExceptionWhenNegativeCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.robotManager = new RobotManager(-20);
            });
         
        }

        [Test]
        public void AddRobotWithExistingNameShouldThrowException()
        {
            this.robotManager = new RobotManager(20);
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Add(new Robot("Robo", 20));
            });
            
        }

        [Test]
        public void AddShouldThrowExceptionWhenReachesCapacity()
        {
            this.robotManager = new RobotManager(1);
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Add(new Robot("SomeRobo", 20));
            });

        }

        [Test]
        public void AddShouldIncreaseCount()
        {
            this.robotManager = new RobotManager(2);
            this.robotManager.Add(this.robot);
            this.robotManager.Add(new Robot("SomeRobo", 20));

            Assert.That(this.robotManager.Count, Is.EqualTo(2));
        }

        [Test]
        public void RemoveShouldWorkCorrectly()
        {
            this.robotManager = new RobotManager(2);
            this.robotManager.Add(this.robot);
            this.robotManager.Add(new Robot("SomeRobo", 20));

            this.robotManager.Remove("SomeRobo");

            Assert.That(this.robotManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveShouldThrowExceptionWithNonexistingRobotName()
        {
            this.robotManager = new RobotManager(2);
            this.robotManager.Add(this.robot);
            this.robotManager.Add(new Robot("SomeRobo", 20));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Remove("Rob");
            });
        }

        [Test]
        public void WorkShouldThrowExceptionWithNonexistingRobotName()
        {
            this.robotManager = new RobotManager(2);
            this.robotManager.Add(this.robot);
            this.robotManager.Add(new Robot("SomeRobo", 20));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Work("Rob", "clean", 20);
            });
        }

        [Test]
        public void WorkShouldThrowExceptionWhenNotEnoughBattery()
        {
            this.robotManager = new RobotManager(2);
            this.robotManager.Add(this.robot);
            this.robotManager.Add(new Robot("SomeRobo", 20));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Work("SomeRobo", "clean", 30);
            });
        }

        [Test]
        public void WorkShouldDecreaseBattery()
        {
            this.robotManager = new RobotManager(2);
            this.robotManager.Add(this.robot);
            this.robotManager.Add(new Robot("SomeRobo", 20));

            this.robotManager.Work("Robo", "clean", 10);

            Assert.That(this.robot.Battery, Is.EqualTo(90));
        }

        [Test]
        public void ChargeShouldThrowExceptionWhenNonexistingRobotName()
        {
            this.robotManager = new RobotManager(2);
            this.robotManager.Add(this.robot);
            this.robotManager.Add(new Robot("SomeRobo", 20));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Charge("Rob");
            });
        }

        [Test]
        public void ChargeShouldSetRoboBatteryToMax()
        {
            this.robotManager = new RobotManager(2);
            this.robotManager.Add(this.robot);
            this.robotManager.Add(new Robot("SomeRobo", 20));

            this.robotManager.Work("Robo", "clean", 10);

            this.robotManager.Charge("Robo");

            Assert.That(this.robot.Battery, Is.EqualTo(this.robot.MaximumBattery));

        }


    }
}
