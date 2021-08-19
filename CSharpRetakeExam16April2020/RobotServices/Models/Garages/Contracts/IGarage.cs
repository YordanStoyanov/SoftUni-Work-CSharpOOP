using RobotServices.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotServices.Models.Garages.Contracts
{
    public interface IGarage
    {
        IReadOnlyDictionary<string, IRobot> Robots {get;}
        void Manufacturer(IRobot robot);
        void Sell(string robotName, string ownerName);

    }
}
