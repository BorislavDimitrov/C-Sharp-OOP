using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : BaseHero
    {
        private const int InitialPower = 80;

        public Druid(string name)
            : base(name)
        {
        }

        public override int Power => InitialPower;
    }
}
