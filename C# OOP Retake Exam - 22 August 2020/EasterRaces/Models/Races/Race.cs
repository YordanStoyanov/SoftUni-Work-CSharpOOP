using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private readonly IDictionary<string, IDriver> driversByName;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
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

        public int Laps
        {
            get
            {
                return this.laps;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, laps));
                }
                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers 
        {
            get
            {
                return this.driversByName.Values.ToList();
            }
            private set { } 
        }

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverInvalid));
            }
            if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            if (this.driversByName.ContainsKey(name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.name));
            }
        }
    }
}
