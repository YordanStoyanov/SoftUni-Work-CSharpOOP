using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        //Has initial 90 units of oxygen.
        private const double initialOxygen = 90;
        public Meteorologist(string name, double oxygen) : 
            base(name, initialOxygen)
        {
        }
    }
}
