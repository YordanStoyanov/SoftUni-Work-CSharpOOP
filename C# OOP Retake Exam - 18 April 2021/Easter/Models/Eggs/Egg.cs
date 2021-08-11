using Easter.Models.Eggs.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;

        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new AggregateException(string.Format(ExceptionMessages.InvalidEggName));
                }
                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get
            {
                return this.energyRequired;
            }
            private set
            {
                if (this.energyRequired <= 0)
                {
                    this.energyRequired = 0;
                }
            }
        }

        public void GetColored()
        {
            this.energyRequired -= 10;
            if (energyRequired < 0)
            {
                throw new ArgumentException();
            }
        }

        public bool IsDone()
        {
            if (this.energyRequired == 0)
            {
                return true;
            }
            return false;
        }
    }
}
