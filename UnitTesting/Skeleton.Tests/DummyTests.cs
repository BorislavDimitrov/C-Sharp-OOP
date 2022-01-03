using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyShouldLoseHealthWhenBeingAttacked()
        {
            Dummy dummy = new Dummy(50, 10);
            Axe axe = new Axe(21, 10);
            axe.Attack(dummy);
            Assert.AreEqual(29, dummy.Health, "Dummy doesnt lose health after attack!");
        }

        [Test]
        public void DummyWithZeroOrLessHealthShouldThrowOperationExceptionWhenAttacked()
        {
            Dummy dummy = new Dummy(0, 8);
            Axe axe = new Axe(10, 10);
            Assert.That(() => { axe.Attack(dummy); }, 
                Throws.InvalidOperationException , "Cannot attack dummy with zero or less health");
        }

        [Test]
        public void DeadDummyShouldGiveExp()
        {
            Dummy dummy = new Dummy(0, 5);
            int exp = dummy.GiveExperience();
            Assert.AreEqual(5, exp , "Dead dummy doesnt give expected exp");
        }

        [Test]
        public void AliveDummyShouldNotGiveExp()
        {
            Dummy dummy = new Dummy(55, 24);
            int exp = 0;
            Assert.That(() => { exp = dummy.GiveExperience(); },
                Throws.InvalidOperationException, "Alive dummy gives exp");
        }
    }
}