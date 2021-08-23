using SpaceStation.Models.Astronauts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models
{
    public class Backpack
    {
        private IList<IAstronaut> astronauts;
        public Backpack()
        {
            this.astronauts = new List<IAstronaut>();
        }
    }
}
