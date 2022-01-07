using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy
{
    public interface IDummy
    {
        public int Health { get; }
        public void TakeAttack(int attackPoints);
        public int GiveExperience();
        public bool IsDead();
    }
}
