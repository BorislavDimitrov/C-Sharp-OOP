using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FightingArena.Tests
{
    public class ArenaTests
    {
        [Test]
        public void ConstructorShouldMakeEmptyArena()
        {
            Arena arena = new Arena();
            Assert.AreEqual(0, arena.Count);
        }
        [Test]
        [TestCase("SHadow", 50, 30, 10)]
        [TestCase("SkyBlue", 50 , 41, 5)]
        public void EnrollShouldAddRightUnits(string name, int damage, int hp, int count)
        {
            List<Warrior> warriors = new List<Warrior>();
            Arena arena = new Arena();
            for (int i = 0; i < count; i++)
            {
                Warrior newWarrior = new Warrior(name + $"{i}", damage + i, hp + i);
                warriors.Add(newWarrior);
                arena.Enroll(newWarrior);
            }

            List<Warrior> result = arena.Warriors.ToList();
            CollectionAssert.AreEqual(warriors, result);
        }
        
        [Test]
        public void EnrollShouldThrowInvalidOperationDueToRepeatingNames()
        {
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("Shadow", 64, 100);
            Warrior warrior2 = new Warrior("Shadow", 45, 100);
            arena.Enroll(warrior1);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior2));
        }

        [Test]
        public void CountShouldReturnRightNumber()
        {
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("Shadow", 30 , 100);
            Warrior warrior2 = new Warrior("Sky", 40, 100);
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            Assert.AreEqual(2, arena.Count);
        }

        [Test]
        public void FightShouldMake2WarriorsFightAndReturnRightValuesForHp()
        {
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("Shadow", 40, 100);
            Warrior warrior2 = new Warrior("BlueSky", 40, 100);

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            arena.Fight("Shadow", "BlueSky");
            Assert.AreEqual(60, warrior2.HP);
        }

        [Test]
        public void FightShouldThrowInvalidOperationDueToInvalidAttackerName()
        {
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("Shadow", 40, 100);
            Warrior warrior2 = new Warrior("BlueSky", 40, 100);

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Sky", "BlueSky"));
            
        }

        [Test]
        public void FightShouldThrowInvalidOperationDueToInvaliDefenderName()
        {
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("Shadow", 40, 100);
            Warrior warrior2 = new Warrior("BlueSky", 40, 100);

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Shadow", "Sky"));

        }
    }
}
