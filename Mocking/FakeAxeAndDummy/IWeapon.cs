﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy
{
    public interface IWeapon
    {
        public int AttackPoints { get;}
        public int DurabilityPoints { get; }
        public void Attack(IDummy target);
    }
}
