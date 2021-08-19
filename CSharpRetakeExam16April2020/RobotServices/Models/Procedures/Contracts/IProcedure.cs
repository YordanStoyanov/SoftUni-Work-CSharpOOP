using RobotServices.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotServices.Models.Procedures.Contracts
{
    public interface IProcedure
    {
        string History();
        void DoService(IRobot robot, int procedureTime);
    }
}
