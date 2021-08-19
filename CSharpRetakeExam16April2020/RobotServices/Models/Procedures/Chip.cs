﻿using RobotServices.Models.Robots.Contracts;
using RobotServices.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotServices.Models.Procedures
{
    public class Chip : Procedure
    {
        public Chip()
        {
        }
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            if (robot.IsChipped)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AlreadyChipped, robot.Name));    
            }
            robot.Happiness -= 5;
            robot.IsChecked = true;
            this.Robots.Add(robot);
        }
    }
}
