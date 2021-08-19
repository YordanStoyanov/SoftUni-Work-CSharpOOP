using RobotServices.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotServices.Models.Procedures
{
    public class TechCheck : Procedure
    {
        public TechCheck()
        {
        }
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Energy -= 8;
            if (robot.IsChecked == true)
            {
                robot.Energy -= 8;
            }
        }
    }
}
