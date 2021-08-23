using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxigen;

        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
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
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidAstronautName));
                }
                this.name = value;
            }
        }

        public double Oxygen
        {
            get
            {
                return this.oxigen;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidOxygen));
                }
                this.oxigen = value;
            }
        }

        public bool CanBreath { get; set; }

        public IBag Bag { get; }

        public virtual void Breath()
        {
            this.oxigen -= 10;
            if (this.oxigen < 0)
            {
                throw new ArgumentException();
            }
        }
    }
}
