using Moq;
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
            //Arrange
            var fakeIntroducer = new Mock<IIntroducable>();
            var introducedMessage = string.Empty;
            fakeIntroducer.Setup(i => i.Introduce(It.IsAny<string>()))
              .Callback((string message) => introducedMessage = message);//Callback=> when is void=>else use Returns

            var dragon = new Dragon(name, fakeIntroducer.Object);

            dragon.Introduce();
            Assert.That(introducedMessage, Is.EqualTo($"My name is {name}! I am an ancient..."));
        }
    }
}
