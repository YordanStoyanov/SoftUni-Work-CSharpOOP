using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
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
            IDriver driver = new Driver(driverName);
            this.driverRepository.Add(driver);
            return string.Format(ExceptionMessages.DriversExists, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            throw new NotImplementedException();
        }

        public string StartRace(string raceName)
        {
            throw new NotImplementedException();
        }
    }
}
