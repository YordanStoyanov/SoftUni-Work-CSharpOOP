using SpaceStation.Models.Planets;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : Planet
    {
        public PlanetRepository(string name) : base(name)
        {
        }
    }
}
