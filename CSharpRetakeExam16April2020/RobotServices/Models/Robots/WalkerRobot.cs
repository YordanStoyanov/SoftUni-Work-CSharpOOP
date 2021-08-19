using System;
using System.Collections.Generic;
using System.Text;

namespace RobotServices.Models.Robots
{
    public class WalkerRobot : Robot
    {
        public WalkerRobot(string name, int energy, int happinness, int procedureTime) : 
            base(name, energy, happinness, procedureTime)
        {
        }
    }
}
