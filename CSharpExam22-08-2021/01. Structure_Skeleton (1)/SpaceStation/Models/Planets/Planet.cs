using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Planets
{
    public abstract class Planet : IPlanet
    {
        private string name;
        public Planet(string name)
        {
            this.Name = name;
        }
        public ICollection<string> Items => throw new NotImplementedException();

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
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidPlanetName));
                }
                this.name = value;
            }
        }
    }
}
