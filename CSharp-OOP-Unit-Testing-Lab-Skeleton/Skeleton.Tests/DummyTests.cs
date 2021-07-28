using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyShouldLoseHealthInAttack()
    {
        //Arange
        Dummy dummy = new Dummy(10, 10);

        //Act
        dummy.TakeAttack(1);

        //Assert
        Assert.That(dummy.Health, Is.EqualTo(9));
    }

    [Test]
    public void DummyShouldBeDeadWhenHealthIsEqualOrLessThanZero()
    {
        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            //Arange
            Dummy dummy = new Dummy(0, 10);

            //Act
            dummy.TakeAttack(30);
        }, "Dummy is dead.");
    }

    [Test]
    public void DummyShouldGiveExperienceIfDead()
    {
        //Arange
        Dummy dummy = new Dummy(0, 10);

        //Act
        int experience = dummy.GiveExperience();

        //Assert
        Assert.That(dummy.GiveExperience, Is.EqualTo(experience));
    }

    [Test]
    public void DummyShouldGiveExperienceIfNotDead()
    {
        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            //Arange
            Dummy dummy = new Dummy(10, 10);

            //Act
            int experience = dummy.GiveExperience();
        }, "Target is not dead.");

        //Arange
        Dummy dummy = new Dummy(10, 10);

        //Act
        Assert.That(() => dummy.GiveExperience(), 
            Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}
