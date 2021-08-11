using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class Dye : Bunny
    {
        private int power;
        public Dye(string name, int energy, int power) : 
            base(name, energy)
        {
            this.Power = power;
        }

        public int Power
        {
            get
            { 
                return this.power;
            }
            private set
            {
                if (this.power == 0)
                {
                    this.power = 0;
                }
            }
        }

        public void Use()
        {
            this.power -= 10;
        }
    }
}
