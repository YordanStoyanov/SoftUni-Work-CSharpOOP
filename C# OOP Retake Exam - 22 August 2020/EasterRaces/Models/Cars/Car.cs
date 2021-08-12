using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars
{
    public abstract class Car : ICar
    {
        private const int minModelNameLength = 4;
        private int minHorsePower;
        private int maxHorsePower;
        private double cubicCentimeters;
        private string model;
        private int horsePower;
        //string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower
        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < minModelNameLength)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, minModelNameLength));
                }
                this.model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            private set
            {
                if (value < minHorsePower && value > maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, horsePower));
                }
                this.horsePower = value;
            }
        }

        public double CubicCentimeters
        {
            get
            {
                return this.cubicCentimeters;
            }
            private set
            {
                this.cubicCentimeters = value;
            }
        }

        public double CalculateRacePoints(int laps)
        {
            double result = cubicCentimeters / (double)horsePower * (double)laps;
            return result;
        }
    }
}
