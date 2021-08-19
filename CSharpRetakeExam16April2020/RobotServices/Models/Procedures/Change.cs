using RobotServices.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotServices.Models.Procedures
{
    public class Change : Procedure
    {
        public Change()
        {
        }
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Happiness += 12;
            robot.Energy += 10;
        }
    }
}
