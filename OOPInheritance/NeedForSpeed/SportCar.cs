using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double DefaultFuelConsumption = 10;
        public SportCar(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption
        {
            get
            {
                return DefaultFuelConsumption;
            }
        }

        public override void Drive(double kilometers)
        {
            bool canDrive = Fuel - (kilometers * FuelConsumption) >= 0;
            if (canDrive)
            {
                this.Fuel -= kilometers * FuelConsumption;
            }
        }
    }
}
