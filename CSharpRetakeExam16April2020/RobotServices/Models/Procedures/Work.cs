﻿using RobotServices.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotServices.Models.Procedures
{
    public class Work : Procedure
    {
        public Work()
        {
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Energy -= 6;
            robot.Happiness += 12;
        }
    }
}
