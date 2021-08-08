using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly IDictionary<string, IDriver> driverByName;
        public DriverRepository()
        {
            driverByName = new Dictionary<string, IDriver>();
        }
        public void Add(IDriver name)
        {
            if (this.driverByName.ContainsKey(name.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists));
            }
            this.driverByName.Add(name.Name, name);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.driverByName.Values.ToList();
        }

        public IDriver GetByName(string name)
        {
            IDriver driver = null;
            if (this.driverByName.ContainsKey(name))
            {
                driver = this.driverByName[name];
            }
            return driver;
        }

        public bool Remove(IDriver name)
        {
            if (this.driverByName.ContainsKey(name.Name))
            {
                return true;
                this.driverByName.Remove(name.Name);
            }
            else
            {
                return false;
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotFound));
            }
        }
    }
}
