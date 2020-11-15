using Moq;
using NUnit.Framework;


[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroShouldGainExperienceIfTargetDies()
    {
        const int experience = 200;
        //Arrange
        /* var weapon = new Mock<IWeapon>();*/// this is usefull for object that we have to override his logic like fake, we have to setup this fake object

        var fakeWeapon = Mock.Of<IWeapon>(); //-this is instance of fake object that do nothing

       var fakeTarget = new Mock<ITarget>();
        fakeTarget
            .Setup(t => t.IsDead())
            .Returns(true);
        fakeTarget
            .Setup(t => t.GiveExperience())
            .Returns(experience);
       
        var hero = new Hero("TestHero", fakeWeapon);
        var target = new FakeTarget();

        //Act
        hero.Attack(fakeTarget.Object);

        //Assert
        Assert.That(hero.Experience, Is.EqualTo(experience));
    }
}

