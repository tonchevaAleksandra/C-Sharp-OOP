using NUnit.Framework;


[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroShouldGainExperienceIfTargetDies()
    {
        //Arrange
        var weapon = new FakeWeapon();
        var hero = new Hero("TestHero", weapon);
        var target = new FakeTarget();

        //Act
        hero.Attack(target);

        //Assert
        Assert.That(hero.Experience, Is.EqualTo(FakeTarget.DefaultExperience));
    }
}

