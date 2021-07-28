using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private const int attact = 10;
    private const int minDurability = 0;
    private const int maxDurability = 5;
    private const int health = 100;
    private const int experience = 50;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetAxe()
    {
        //Arange
        this.axe = new Axe(attact, maxDurability);
        this.dummy = new Dummy(health, experience);
    }

    [Test]
    public void AxeShouldBeloseDurabilityAfterAttack()
    {
        //Act
        this.axe.Attack(this.dummy);

        //Assert
        Assert.That(this.axe.DurabilityPoints, Is.EqualTo(4));
    }

    [Test]
    public void AxeShouldBeBrokenDurabilityAfterAttack()
    {
        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            // Arange
            this.axe = new Axe(attact, minDurability);
            this.dummy = new Dummy(health, experience);
            this.dummy = new Dummy(health, experience);

            //Act
            this.axe.Attack(this.dummy);
        }, "Axe is broken.");
    }
}