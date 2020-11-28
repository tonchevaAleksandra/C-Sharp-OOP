namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        [SetUp]
        public void SetUp()
        {
            this.robot = new Robot("Robo", 100);
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            int expectedCapacity = 5;
            RobotManager robotManager = new RobotManager(expectedCapacity);

            Assert.That(robotManager.Capacity, Is.EqualTo(expectedCapacity));
            Assert.That(robotManager.Count, Is.EqualTo(0));
        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenNegativeCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager robotManager = new RobotManager(-2);
            });
        }

        [Test]
        public void AddShouldWorkCorrectly()
        {
            RobotManager robotManager = new RobotManager(2);
            int expectedCount = 1;
            robotManager.Add(this.robot);

            Assert.That(robotManager.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void AddShouldThrowExceptionWhenExistingRobot()
        {
            RobotManager robotManager = new RobotManager(2);
            robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(this.robot);
            });
        }

        [Test]
        public void AddShouldThrowExceptionWhenFullCapacity()
        {
            RobotManager robotManager = new RobotManager(1);
            robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(new Robot("Rubi", 50));
            });
        }

        [Test]
        public void RemoveShouldWorkCorrectly()
        {
            RobotManager robotManager = new RobotManager(1);
            robotManager.Add(this.robot);
            int expectedCount = 0;

            robotManager.Remove(this.robot.Name);

            Assert.That(robotManager.Count, Is.EqualTo(expectedCount));

        }

        [Test]
        public void RemoveShouldThrowExceptionWhenRobotsNotFound()
        {
            RobotManager robotManager = new RobotManager(1);
            robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove("Simo");
            });
        }

        [Test]
        public void WorkShouldDecreaseRobotsBattery()
        {
            RobotManager robotManager = new RobotManager(1);
            robotManager.Add(this.robot);
            string job = "Work, MotherFucher!";
            int batteryUsage = 99;
            int expectedBatteryLevel = 1;

            robotManager.Work(this.robot.Name, job, batteryUsage);

            Assert.That(this.robot.Battery, Is.EqualTo(expectedBatteryLevel));
        }

        [Test]
        public void WorkShouldThrowExceptionWhenRobotsNotFound()
        {
            RobotManager robotManager = new RobotManager(1);
            robotManager.Add(this.robot);
            string job = "Work, MotherFucher!";
            int batteryUsage = 99;

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Simkata", job, batteryUsage);
            });
        }

        [Test]
        public void WorkShouldThrowExceptionWhenBatteryInsufficient()
        {
            RobotManager robotManager = new RobotManager(1);
            robotManager.Add(this.robot);
            string job = "Work, MotherFucher!";
            int batteryUsage = 120;

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work(this.robot.Name, job, batteryUsage);
            });
        }

        [Test]
        public void ChargeShouldSetRobotsBatteryToMaximum()
        {
            RobotManager robotManager = new RobotManager(1);
            robotManager.Add(this.robot);
            string job = "Work, MotherFucher!";
            int batteryUsage = 99;
            robotManager.Work(this.robot.Name, job, batteryUsage);

            robotManager.Charge(this.robot.Name);

            Assert.That(this.robot.Battery, Is.EqualTo(this.robot.MaximumBattery));

        }

        [Test]
        public void ChargeShouldThrowExceptionWhenRobotsNotFound()
        {
            RobotManager robotManager = new RobotManager(1);
            robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge("Simkata");
            });
        }

    }
}

