using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public virtual double DefaultFuelConsumption
        {
            get { return this.DefaultFuelConsumption; }
            set { this.DefaultFuelConsumption = 1.25; }
        }
        public virtual double FuelConsumption { get; set; }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            bool canDrive = this.Fuel - kilometers * FuelConsumption >= 0;
            if (canDrive)
            {
                this.Fuel -= kilometers * FuelConsumption;
            }
        }
    }
}
