using DependancyInjectionPractice.Fakes;
using NUnit.Framework;

namespace DependancyInjectionPractice
{
    [TestFixture]
   public  class DragonTests
    {
        [Test]
        public void DragonShouldIntroduceItsName()
        {
            const string name = "Drago";
            var introducer = new FakeIntroducer();
            var dragon = new Dragon(name, introducer);

            dragon.Introduce();
            Assert.That(introducer.Message, Is.EqualTo($"My name is {name}! I am an ancient..."));
        }
    }
}
