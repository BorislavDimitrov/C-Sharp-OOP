using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin : BaseHero
    {
        private const int InitialPower = 100;
        public Paladin(string name)
            : base(name)
        {
        }

        public override int Power => 100;
    }
}
