using System;
using NUnit.Framework;


[TestFixture]
public class AxeTests
{
    private const string AXE_DURABILITY_RESULT_FAILED_MSG = "Axe Durability doesn't change after attack";

    private const string AXE_BROKEN_MSG = "Axe is broken.";

    private const int ATTACK_POINTS = 10;

    private Dummy dummy;

    [SetUp]
    public void SetDummy()
    {
        this.dummy = new Dummy(ATTACK_POINTS, 10);
    }

    [Test]
    public void AxeShouldLoseDurabilityAfterAttack()
    {
        //Arrange
        Axe axe = new Axe(ATTACK_POINTS, 10);

        //Act
        axe.Attack(this.dummy);

        //Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(9), AXE_DURABILITY_RESULT_FAILED_MSG);
    }
    [Test]

    public void AxeShouldThrowExceptionWhenAttackWithBrokenWeapon()
    {

        Axe axe = new Axe(ATTACK_POINTS, 0);

        Assert.Throws<InvalidOperationException>(() => axe.Attack(this.dummy), AXE_BROKEN_MSG);
    }
}

