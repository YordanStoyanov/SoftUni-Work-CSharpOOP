using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotocycle : Motorcycle
    {
        public RaceMotocycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public override double DefaultFuelConsumption { get => base.DefaultFuelConsumption; set => base.DefaultFuelConsumption = 8; }
    }
}
