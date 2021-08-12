using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers
{
    public class Driver : IDriver
    {
        private string name;
        public Driver(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, name, value));
                }
                this.name = value;
            }
        }


        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get
            {
                return this.Car != null;
            }
        }

        public IFormatProvider ExceptionMessage { get; private set; }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarInvalid));
            }
            this.Car = car;
        }

        public void WinRace()
        {
            this.NumberOfWins += 1;
        }
    }
}
