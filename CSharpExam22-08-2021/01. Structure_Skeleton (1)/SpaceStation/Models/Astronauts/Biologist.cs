﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        //Has 70 initial units of oxygen.
        private const double initialOxygen = 70;
        public Biologist(string name) : 
            base(name, initialOxygen)
        {
        }

    }
}
