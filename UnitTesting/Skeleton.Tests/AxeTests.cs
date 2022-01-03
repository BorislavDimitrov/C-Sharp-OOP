using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeShouldLoseDurabilityAfterEachAttack()
        {
            Axe axe = new Axe(10, 10);
            axe.Attack(new Dummy(20, 5));
            Assert.AreEqual(9, axe.DurabilityPoints, "Axe doesnt lose durability");
        }

        [Test]
        public void BrokenAxeMustThrowExceptionWhenAttacking()
        {
            Axe axe = new Axe(10, 0);
            Assert.That(() => { axe.Attack(new Dummy(20, 5)); }
            , Throws.InvalidOperationException, "Axe with 0 durrability cannot attack" );
                                     
        }
    }
}