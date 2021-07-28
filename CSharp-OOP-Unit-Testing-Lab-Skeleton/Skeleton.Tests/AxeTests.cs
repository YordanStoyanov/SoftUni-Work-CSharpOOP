using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    public void AxeShouldBeloseDurabilityAfterAttack()
    {
        // Arange
        Axe axe = new Axe(10, 5);
        Dummy target = new Dummy(100, 50);

        //Act
        axe.Attack(target);

        //Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(4));
    }

    [Test]
    public void AxeShouldBeBrokenDurabilityAfterAttack()
    {
        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            // Arange
            Axe axe = new Axe(10, 0);
            Dummy target = new Dummy(100, 50);

            //Act
            axe.Attack(target);
        }, "Axe is broken.");

        //Arange 
        Axe axe = new Axe(1, 1);
        Dummy dummy = new Dummy(10, 10);

        //Act
        axe.Attack(dummy);

        //Assert
        Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}