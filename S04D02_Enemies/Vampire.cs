using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S04D02_Enemies
{
    class Vampire : Enemy
    {
        private int glitterAmount;

        public Vampire(string name, int attack, int deff, int glitterAmount)
            : base(name, attack, deff, "Vampire")
        {
            this.glitterAmount = glitterAmount;
        }

        public override int Damage()
        {
            return base.Attack - this.glitterAmount*2;
        }

    }
}
