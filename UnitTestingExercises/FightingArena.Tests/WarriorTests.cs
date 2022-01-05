using NUnit.Framework;
using System;

namespace FightingArena.Tests
{
    public class WarriorTests
    {
        [Test]
        [TestCase("Ivan4o", 50, 10)]
        [TestCase("Stoqn", 1, 0)]
        public void ConstructorShouldMakeAWarrior(string name, int damage, int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);
            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void NameShouldThrowArgumentExceptionDueToInvalidValue(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 50, 100));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void DamageShouldThrowArgumentExceptionDueToInvaliValue(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Stoqn", damage, 100));
        }

        [Test]
        [TestCase(-10)]
        [TestCase(-43)]
        public void HpShouldThrowArgumentExceptionDueToInvalidValue(int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Borislav", 34, hp));
        }

        [Test]
        [TestCase("Ivan4o", 60, 100, "DarkShadow", 50, 100)]
        [TestCase("Stoqn", 54, 100, "Shadows", 23, 120)]
        public void AfterAttackTheAttackedWarriorShouldReturnRightValue
            (string firstWarriorName, int firstWarriorDamage, int firstWarriorHp
            ,string secondWarriorName, int secondWarriorDamage, int secondWarriorHp)
        {
            Warrior warrior1 = new Warrior(firstWarriorName, firstWarriorDamage, firstWarriorHp);
            Warrior warrior2 = new Warrior(secondWarriorName, secondWarriorDamage, secondWarriorHp);
            warrior1.Attack(warrior2);
            int hpLeft = secondWarriorHp - firstWarriorDamage;
            Assert.AreEqual(hpLeft, warrior2.HP);
        }

        [Test]
        [TestCase("Ivan4o", 111, 100, "DarkShadow", 50, 100)]
        [TestCase("Stoqn", 145, 100, "Shadows", 23, 120)]
        public void AfterAttackIfAttackerDamageIsMoreThanDefenderShouldReturnZeroHp
            (string firstWarriorName, int firstWarriorDamage, int firstWarriorHp
            , string secondWarriorName, int secondWarriorDamage, int secondWarriorHp)
        {
            Warrior warrior1 = new Warrior(firstWarriorName, firstWarriorDamage, firstWarriorHp);
            Warrior warrior2 = new Warrior(secondWarriorName, secondWarriorDamage, secondWarriorHp);
            warrior1.Attack(warrior2);
            Assert.AreEqual(0, warrior2.HP);
        }

        [Test]
        [TestCase("Ivan4o", 60, 29, "Shadow", 50, 40)]
        [TestCase("Stoqn", 54, 22, "Doodle", 12, 40)]
        public void AttackShouldThrowOperationExceptionDueToLessThan30HpOfAttacker
            (string firstWarriorName, int firstWarriorDamage, int firstWarriorHp
            , string secondWarriorName, int secondWarriorDamage, int secondWarriorHp)
        {
            Warrior warrior1 = new Warrior(firstWarriorName, firstWarriorDamage, firstWarriorHp);
            Warrior warrior2 = new Warrior(secondWarriorName, secondWarriorDamage, secondWarriorHp);
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }

        [Test]
        [TestCase("Ivan4o", 60, 30, "Shadow", 50, 12)]
        [TestCase("Stoqn", 54, 50, "Doodle", 12, 29)]
        public void AttackShouldThrowOperationExceptionDueToLessThan30HpOfEnemy
            (string firstWarriorName, int firstWarriorDamage, int firstWarriorHp
            , string secondWarriorName, int secondWarriorDamage, int secondWarriorHp)
        {
            Warrior warrior1 = new Warrior(firstWarriorName, firstWarriorDamage, firstWarriorHp);
            Warrior warrior2 = new Warrior(secondWarriorName, secondWarriorDamage, secondWarriorHp);
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }

        [Test]
        [TestCase("Ivan4o", 60, 30, "Shadow", 61, 100)]
        [TestCase("Stoqn", 54, 50, "Doodle", 100, 100)]
        public void AttackShouldThrowOperationExceptionDueToStrongerEnemy
            (string firstWarriorName, int firstWarriorDamage, int firstWarriorHp
            , string secondWarriorName, int secondWarriorDamage, int secondWarriorHp)
        {
            Warrior warrior1 = new Warrior(firstWarriorName, firstWarriorDamage, firstWarriorHp);
            Warrior warrior2 = new Warrior(secondWarriorName, secondWarriorDamage, secondWarriorHp);
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }
    }
}