using FakeAxeAndDummy;
using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void ConstructorShouldMake()
    {
        Mock<IWeapon> weapon = new Mock<IWeapon>();
        Hero hero = new Hero("Shadow", weapon.Object);
        Assert.AreEqual("Shadow", hero.Name);
        Assert.AreEqual(0, hero.Experience);
        Assert.AreEqual(weapon.Object, hero.Weapon);
    }

    [Test]
    public void AfterAttackHeroShouldRecieveExp()
    {
        Mock<IWeapon> weapon = new Mock<IWeapon>();
        weapon.Setup(x => x.AttackPoints)
            .Returns(50);
        Mock<IDummy> dummy = new Mock<IDummy>();
        dummy.Setup(x => x.IsDead())
            .Returns(true);
        dummy.Setup(x => x.GiveExperience())
            .Returns(50);
        Hero hero = new Hero("sto", weapon.Object);
        hero.Attack(dummy.Object);
        Assert.AreEqual(50, hero.Experience);
    }

    [Test]
    public void AfterAttackHeroShouldNotRecieveExp()
    {
        Mock<IWeapon> weapon = new Mock<IWeapon>();
        weapon.Setup(x => x.AttackPoints)
            .Returns(50);
        Mock<IDummy> dummy = new Mock<IDummy>();
        dummy.Setup(x => x.IsDead())
            .Returns(false);
        Hero hero = new Hero("sto", weapon.Object);
        hero.Attack(dummy.Object);
        Assert.AreEqual(0, hero.Experience);
    }
}