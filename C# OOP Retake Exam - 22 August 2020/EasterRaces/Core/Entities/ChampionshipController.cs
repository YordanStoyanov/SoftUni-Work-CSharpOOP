using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> driverRepository;
        private readonly IRepository<IRace> racesRepository;
        private string driverName;
        private List<IDriver> drivers;
        private List<ICar> cars;
        public ChampionshipController()
        {
            drivers = new List<IDriver>();
            cars = new List<ICar>();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            IRace race = this.racesRepository.GetByName(driverName);
            return race.ToString();
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            return string.Empty;
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (type == "MuscleCar")
            {
                this.cars.Add(new MuscleCar(model, horsePower));
            }
            if (type == "SportsCar")
            {
                this.cars.Add(new SportsCar(model, horsePower));
            }
            return $"{type} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            var driverExist = this.driverRepository.GetByName(driverName);
            if (driverExist != null)
            {
                return string.Format(ExceptionMessages.DriversExists, driverName);
            }
            var driver = new Driver(driverName);
            this.driverRepository.Add(driver);
            return $"Driver {driverName} is created.";

        }

        public string CreateRace(string name, int laps)
        {
            var race = this.racesRepository.GetByName(name);
            if (race != null)
            {
                return string.Format(ExceptionMessages.RaceExists, race.Name);
            }
            race = new Race(name, laps);
            this.racesRepository.Add(race);
            return $"Driver {name} is already created.";
        }

        public string StartRace(string raceName)
        {
            var race = this.racesRepository.GetByName(raceName);

            var driver = race.Drivers.OrderByDescending(r => r.Car.CalculateRacePoints(race.Laps)).ToList();
            var first = driver[0];
            var second = driver[1];
            var third = driver[2];
            StringBuilder sb = new StringBuilder();
            sb.Append($"Driver {first} wins {first.Name} race.\r\n" +
                        $"Driver {second} is second in {second.Name} race.\r\n" +
                        $"Driver {third} is third in {third.Name} race.\r\n");
            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
