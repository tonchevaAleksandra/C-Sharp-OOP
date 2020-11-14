using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const string HEALTH_DECREASING_FAILED_MES = "Dummy didn't decrease his health corectly after take attack!";

        private const string DEAD_DUMMY_EXC_MSG = "Dummy is dead.";

        private const string DEAD_DUMMY_GIVE_XP_MSG = "Dead dummies give experience.";

        private const string ALIVE_DUMMY_DONT_GIVE_XP_MSG = "Target is not dead.";
        private const int EXPERIENCE = 200;
        private const int DEAD_DUMMY_HEALTH = 0;
        private const int ALIVE_DUMMY_HEALTH = 100;
        private const int TAKE_ATTACK_POINTS = 30;

        private Dummy aliveDummy;
        private Dummy deadDummy;

        [SetUp]
        public void SetDummies()
        {
            this.aliveDummy = new Dummy(ALIVE_DUMMY_HEALTH, EXPERIENCE);
            this.deadDummy = new Dummy(DEAD_DUMMY_HEALTH, EXPERIENCE);
        }


        [Test]
        public void DummyShouldLoseHealthWhenTakeAttack()
        {

            this.aliveDummy.TakeAttack(TAKE_ATTACK_POINTS);

            Assert.That(this.aliveDummy.Health, Is.EqualTo(70), HEALTH_DECREASING_FAILED_MES);
        }
        [Test]
        public void DummyShouldThrowExceptionWhenIsDeadAnsBeenAttacked()
        {

            Assert.That(() =>

                this.deadDummy.TakeAttack(TAKE_ATTACK_POINTS),
                Throws.InvalidOperationException.With.Message
                .EqualTo(DEAD_DUMMY_EXC_MSG));
        }

        [Test]
        public void DeadDummyShouldGiveXP()
        {

            var experience = this.deadDummy.GiveExperience();
            Assert.That(experience, Is.EqualTo(200), DEAD_DUMMY_GIVE_XP_MSG);
        }

        [Test]
        public void AliveDummyShouldntGiveXP()
        {

            Assert.That(() =>
                this.aliveDummy.GiveExperience(),
                Throws.InvalidOperationException.With.Message.EqualTo(ALIVE_DUMMY_DONT_GIVE_XP_MSG));


        }

    }
}
