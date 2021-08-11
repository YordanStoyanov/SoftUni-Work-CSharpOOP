using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private int energyPoints = 5;
        private const int totalInitialEnergy = 50;
        public SleepyBunny(string name, int initialEnergy) : 
            base(name, initialEnergy)
        {
            this.InitialEnergy = initialEnergy;
        }
        public int InitialEnergy
        {
            get
            {
                return totalInitialEnergy;
            }
            private set
            {
                Work();
            }
        }

        public void Work()
        {
            if (this.InitialEnergy <= 35)
            {
                throw new ArgumentException();
            }
            this.InitialEnergy -= this.energyPoints;
        }
    }
}
