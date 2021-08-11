using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories;
using System;
using System.Collections.Generic;
using System.Text;


namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;
        private string bunnyType;
        private string bunnyName;
        private List<HappyBunny> happyBunny;
        private List<SleepyBunny> sleepyBunny;

        public Controller()
        {

        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType == "HappyBunny")
            {
                this.happyBunny.Add(new HappyBunny(bunnyName));
            }
             else if (bunnyType == "SleepyBunny")
            {
                this.sleepyBunny.Add(new SleepyBunny(bunnyName, 0));
            }
            else
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }
            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            throw new NotImplementedException();
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            throw new NotImplementedException();
        }

        public string ColorEgg(string eggName)
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
