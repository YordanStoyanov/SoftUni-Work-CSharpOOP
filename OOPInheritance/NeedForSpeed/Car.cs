using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        protected const double DefaultFuelConsumption = 3;
        public Car(int horsePower, double fuel) 
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
            bool canDrive = Fuel - kilometers * FuelConsumption >= 0;
            if (canDrive)
            {
                base.Fuel -= kilometers * FuelConsumption;
            }
        }
    }
}
