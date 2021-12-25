using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        private const int InitialPower = 100;
        public Warrior(string name) 
            : base(name)
        {
        }

        public override int Power => InitialPower;

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
