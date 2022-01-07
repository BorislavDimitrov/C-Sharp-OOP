using FakeAxeAndDummy;
using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    public void ConstructorShouldMakeAxeWithRightValues()
    {
        IWeapon axe = new Axe(50, 20);
        Assert.AreEqual(50, axe.AttackPoints);
        Assert.AreEqual(20, axe.DurabilityPoints);
    }

    [Test]
    public void AttackShouldDecreaseDurabilityPoints()
    {
        IWeapon axe = new Axe(50, 10);
        axe.Attack(new Dummy(550, 40));
        Assert.AreEqual(9, axe.DurabilityPoints);
    }

    [Test]
    public void AttackShouldThrowOperationException()
    {
        IWeapon axe = new Axe(50, 0);
        Assert.Throws<InvalidOperationException>(() => axe.Attack(new Dummy(550, 40)));
        
    }
}