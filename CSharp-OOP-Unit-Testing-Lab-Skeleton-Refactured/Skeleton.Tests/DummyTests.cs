using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    private const int maxHealth = 10;
    private const int minHealth = 0;
    private const int experience = 10;
    private const int minTakeAttact = 1;
    private const int maxTakeAttact = 10;
    private Dummy aliveDummy;
    private Dummy deadDummy;

    [SetUp]
    public void SetDummy()
    {
        //Arange
        this.aliveDummy = new Dummy(maxHealth, experience);
        this.deadDummy = new Dummy(minHealth, experience);
    }

    [Test]
    public void DummyShouldLoseHealthInAttack()
    {
        //Act
        this.aliveDummy.TakeAttack(minTakeAttact);

        //Assert
        Assert.That(this.aliveDummy.Health, Is.EqualTo(9));
    }

    [Test]
    public void DummyShouldBeDeadWhenHealthIsEqualOrLessThanZero()
    {
        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            //Act
            this.deadDummy.TakeAttack(maxTakeAttact);
        }, "Dummy is dead.");
    }

    [Test]
    public void DummyShouldGiveExperienceIfDead()
    {
        //Act
        int experience = this.deadDummy.GiveExperience();

        //Assert
        Assert.That(this.deadDummy.GiveExperience, Is.EqualTo(experience));
    }

    [Test]
    public void DummyShouldGiveExperienceIfNotDead()
    {
        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            //Act
            int experience = this.aliveDummy.GiveExperience();
        }, "Target is not dead.");

        //Act
        Assert.That(() => this.aliveDummy.GiveExperience(), 
            Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}
