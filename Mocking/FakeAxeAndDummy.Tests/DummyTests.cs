using FakeAxeAndDummy;
using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    public void ConstructorShouldMakeDummyWithRightValues()
    {
        IDummy dummy = new Dummy(45, 10);
        Assert.AreEqual(45, dummy.Health);
    }

    [Test]
    public void TakeAttackShouldReduceHealth()
    {
        IDummy dummy = new Dummy(45, 10);
        dummy.TakeAttack(15);
        Assert.AreEqual(30, dummy.Health);
    }

    [Test]
    public void TakeAttackShouldThrowOperationException()
    {
        IDummy dummy = new Dummy(0, 10);
        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(10));
    }

    [Test]
    public void GiveExperienceShouldReturnRightValue()
    {
        IDummy dummy = new Dummy(0, 10);
        Assert.AreEqual(10, dummy.GiveExperience());
    }

    [Test]
    public void GiveExperienceShouldThrowOperationException()
    {
        IDummy dummy = new Dummy(45, 10);
        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }

    [Test]
    public void IsDeadShouldReturnFalse()
    {
        IDummy dummy = new Dummy(45, 10);
        Assert.IsFalse(dummy.IsDead());
    }

    [Test]
    public void IsDeadShouldReturnTrue()
    {
        IDummy dummy = new Dummy(0, 10);
        Assert.IsTrue(dummy.IsDead());
    }
}
