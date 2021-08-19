using RobotServices.Models.Garages.Contracts;
using RobotServices.Models.Robots.Contracts;
using RobotServices.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotServices.Models.Garages
{
    public class Garage : IGarage
    {
        private const int capacity = 10;
        private readonly Dictionary<string, IRobot> robots;
        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }
        public IReadOnlyDictionary<string, IRobot> Robots { get {return this.robots; } }

        public void Manufacturer(IRobot robot)
        {
            if (this.Robots.Count >= capacity)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotEnoughCapacity));
            }
            if (this.Robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot));
            }
            this.robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot));
            }
            IRobot robot = this.robots[robotName];
            robot.Owner = ownerName;
            robot.IsBought = true;
            this.robots.Remove(robotName);
        }
    }
}
