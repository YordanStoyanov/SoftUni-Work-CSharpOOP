using RobotServices.Models.Robots.Contracts;
using RobotServices.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotServices.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private const string defaultOwnerName = "Service";
        private int happinness;
        private int energy;

        public Robot(string name, int energy, int happinness, int procedureTime)
        {
            this.Owner = defaultOwnerName;
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happinness;
            this.ProcedureTime = procedureTime;
            this.IsBought = false;
            this.IsChipped = false;
            this.IsChecked = false;
        }
        public string Name { get; set; }

        public int Happiness
        {
            get
            {
                return this.happinness;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNappiness));
                }
                this.happinness = value;
            }
        }
        public int Energy
        {
            get
            {
                return this.energy;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidEnergy));
                }
                this.energy = value;
            }
        }
        public int ProcedureTime { get; set; }
        public string Owner { get; set; }
        public bool IsBought { get; set; }
        public bool IsChipped { get; set; }
        public bool IsChecked { get; set; }

        public override string ToString()
        {
            return $" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
